using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.DTOs.Main.Acao;
using CPTM.GRD.Application.Features.Acoes.Requests.Queries;
using MediatR;

namespace CPTM.GRD.Application.Features.Acoes.Handlers.Queries;

public class GetSubordinadoAcoesListRequestHandler : IRequestHandler<GetSubordinadoAcoesListRequest, List<AcaoListDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthenticationService _authenticationService;
    private readonly IMapper _mapper;

    public GetSubordinadoAcoesListRequestHandler(
        IUnitOfWork unitOfWork,
        IAuthenticationService authenticationService,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _authenticationService = authenticationService;
        _mapper = mapper;
    }

    public async Task<List<AcaoListDto>> Handle(GetSubordinadoAcoesListRequest request,
        CancellationToken cancellationToken)
    {
        await _authenticationService.AuthorizeByExactUser(request.RequestUser, request.Suid);
        var acoes = await _unitOfWork.AcaoRepository.GetFromSubordinados(request.Suid);
        return _mapper.Map<List<AcaoListDto>>(acoes);
    }
}