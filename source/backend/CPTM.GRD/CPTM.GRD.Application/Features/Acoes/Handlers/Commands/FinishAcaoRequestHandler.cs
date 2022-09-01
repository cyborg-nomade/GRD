using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.DTOs.Main.Acao;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Application.Features.Acoes.Requests.Commands;
using CPTM.GRD.Common;
using MediatR;

namespace CPTM.GRD.Application.Features.Acoes.Handlers.Commands;

public class FinishAcaoRequestHandler : IRequestHandler<FinishAcaoRequest, AcaoDto>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthenticationService _authenticationService;

    public FinishAcaoRequestHandler(
        IUnitOfWork unitOfWork,
        IAuthenticationService authenticationService,
        IMapper mapper
    )
    {
        _unitOfWork = unitOfWork;
        _authenticationService = authenticationService;
        _mapper = mapper;
    }

    public async Task<AcaoDto> Handle(FinishAcaoRequest request, CancellationToken cancellationToken)
    {
        _authenticationService.AuthorizeByMinLevel(request.RequestUser, AccessLevel.Grg);

        var acao = await _unitOfWork.AcaoRepository.Get(request.Aid);
        if (acao == null) throw new NotFoundException(nameof(acao), request.Aid);

        var claims = _authenticationService.GetTokenClaims(request.RequestUser);

        var responsavel = await _unitOfWork.UserRepository.Get(claims.Uid);
        if (responsavel == null) throw new NotFoundException(nameof(responsavel), claims.Uid);

        acao.Finish(request.Status, responsavel);

        var updatedAcao = await _unitOfWork.AcaoRepository.Update(acao);
        await _unitOfWork.Save();

        return _mapper.Map<AcaoDto>(updatedAcao);
    }
}