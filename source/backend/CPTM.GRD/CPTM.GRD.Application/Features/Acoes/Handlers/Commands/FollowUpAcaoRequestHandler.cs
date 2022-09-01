using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.DTOs.Main.Acao;
using CPTM.GRD.Application.DTOs.Main.Mixed;
using CPTM.GRD.Application.DTOs.Main.Reuniao;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Application.Features.Acoes.Requests.Commands;
using CPTM.GRD.Common;
using MediatR;

namespace CPTM.GRD.Application.Features.Acoes.Handlers.Commands;

public class FollowUpAcaoRequestHandler : IRequestHandler<FollowUpAcaoRequest, AddAcaoToReuniaoDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthenticationService _authenticationService;
    private readonly IMapper _mapper;

    public FollowUpAcaoRequestHandler(
        IUnitOfWork unitOfWork,
        IAuthenticationService authenticationService,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _authenticationService = authenticationService;
        _mapper = mapper;
    }

    public async Task<AddAcaoToReuniaoDto> Handle(FollowUpAcaoRequest request, CancellationToken cancellationToken)
    {
        _authenticationService.AuthorizeByMinLevel(request.RequestUser, AccessLevel.Grg);

        var acao = await _unitOfWork.AcaoRepository.Get(request.Aid);
        if (acao == null) throw new NotFoundException(nameof(acao), request.Aid);

        var reuniao = await _unitOfWork.ReuniaoRepository.Get(request.Rid);
        if (reuniao == null) throw new NotFoundException(nameof(reuniao), request.Rid);

        var claims = _authenticationService.GetTokenClaims(request.RequestUser);

        var responsavel = await _unitOfWork.UserRepository.Get(claims.Uid);
        if (responsavel == null) throw new NotFoundException(nameof(responsavel), claims.Uid);

        acao.FollowUp(reuniao, responsavel);

        var updatedAcao = await _unitOfWork.AcaoRepository.Update(acao);
        await _unitOfWork.Save();

        return new AddAcaoToReuniaoDto()
        {
            AcaoDto = _mapper.Map<AcaoDto>(updatedAcao),
            ReuniaoDto = _mapper.Map<ReuniaoDto>(reuniao)
        };
    }
}