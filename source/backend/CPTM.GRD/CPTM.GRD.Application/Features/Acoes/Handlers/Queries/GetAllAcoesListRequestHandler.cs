using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.Acoes;
using CPTM.GRD.Application.DTOs.Main.Acao;
using CPTM.GRD.Application.Features.Acoes.Requests.Queries;
using CPTM.GRD.Common;
using MediatR;

namespace CPTM.GRD.Application.Features.Acoes.Handlers.Queries;

public class GetAllAcoesListRequestHandler : IRequestHandler<GetAllAcoesListRequest, List<AcaoListDto>>
{
    private readonly IAcaoRepository _acaoRepository;
    private readonly IAuthenticationService _authenticationService;
    private readonly IMapper _mapper;

    public GetAllAcoesListRequestHandler(
        IAcaoRepository acaoRepository,
        IAuthenticationService authenticationService,
        IMapper mapper)
    {
        _acaoRepository = acaoRepository;
        _authenticationService = authenticationService;
        _mapper = mapper;
    }

    public async Task<List<AcaoListDto>> Handle(GetAllAcoesListRequest request, CancellationToken cancellationToken)
    {
        _authenticationService.AuthorizeByMinLevel(request.RequestUser, AccessLevel.Grg);
        var acoes = await _acaoRepository.GetAll();
        return _mapper.Map<List<AcaoListDto>>(acoes);
    }
}