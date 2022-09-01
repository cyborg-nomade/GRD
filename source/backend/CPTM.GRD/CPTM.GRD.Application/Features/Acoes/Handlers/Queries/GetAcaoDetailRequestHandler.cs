using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.DTOs.Main.Acao;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Application.Features.Acoes.Requests.Queries;
using MediatR;

namespace CPTM.GRD.Application.Features.Acoes.Handlers.Queries;

public class GetAcaoDetailRequestHandler : IRequestHandler<GetAcaoDetailRequest, AcaoDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthenticationService _authenticationService;
    private readonly IMapper _mapper;

    public GetAcaoDetailRequestHandler(
        IUnitOfWork unitOfWork,
        IAuthenticationService authenticationService,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _authenticationService = authenticationService;
        _mapper = mapper;
    }

    public async Task<AcaoDto> Handle(GetAcaoDetailRequest request, CancellationToken cancellationToken)
    {
        var acao = await _unitOfWork.AcaoRepository.Get(request.Aid);
        if (acao == null) throw new NotFoundException(nameof(acao), request.Aid);

        if (acao.Responsavel == null) throw new NotFoundException(nameof(acao.Responsavel), nameof(acao));
        await _authenticationService.AuthorizeByUserLevelAndGroup(request.RequestUser, acao.Responsavel.Id);

        return _mapper.Map<AcaoDto>(acao);
    }
}