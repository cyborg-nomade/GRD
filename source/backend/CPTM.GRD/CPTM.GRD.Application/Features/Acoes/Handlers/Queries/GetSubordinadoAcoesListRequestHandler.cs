using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.Acoes;
using CPTM.GRD.Application.DTOs.Main.Acao;
using CPTM.GRD.Application.Features.Acoes.Requests.Queries;
using MediatR;

namespace CPTM.GRD.Application.Features.Acoes.Handlers.Queries;

public class GetSubordinadoAcoesListRequestHandler : IRequestHandler<GetSubordinadoAcoesListRequest, List<AcaoListDto>>
{
    private readonly IAcaoRepository _acaoRepository;
    private readonly IAuthenticationService _authenticationService;
    private readonly IMapper _mapper;

    public GetSubordinadoAcoesListRequestHandler(
        IAcaoRepository acaoRepository,
        IAuthenticationService authenticationService,
        IMapper mapper)
    {
        _acaoRepository = acaoRepository;
        _authenticationService = authenticationService;
        _mapper = mapper;
    }

    public async Task<List<AcaoListDto>> Handle(GetSubordinadoAcoesListRequest request,
        CancellationToken cancellationToken)
    {
        await _authenticationService.AuthorizeByExactUser(request.RequestUser, request.Suid);
        var acoes = await _acaoRepository.GetFromSubordinados(request.Suid);
        return _mapper.Map<List<AcaoListDto>>(acoes);
    }
}