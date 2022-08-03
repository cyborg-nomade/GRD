using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.Acoes;
using CPTM.GRD.Application.DTOs.Main.Acao;
using CPTM.GRD.Application.Features.Acoes.Requests.Queries;
using MediatR;

namespace CPTM.GRD.Application.Features.Acoes.Handlers.Queries;

public class
    GetByResponsavelAcoesListRequestHandler : IRequestHandler<GetByResponsavelAcoesListRequest, List<AcaoListDto>>
{
    private readonly IAcaoRepository _acaoRepository;
    private readonly IAuthenticationService _authenticationService;
    private readonly IMapper _mapper;

    public GetByResponsavelAcoesListRequestHandler(
        IAcaoRepository acaoRepository,
        IAuthenticationService authenticationService,
        IMapper mapper)
    {
        _acaoRepository = acaoRepository;
        _authenticationService = authenticationService;
        _mapper = mapper;
    }

    public async Task<List<AcaoListDto>> Handle(GetByResponsavelAcoesListRequest request,
        CancellationToken cancellationToken)
    {
        await _authenticationService.AuthorizeByExactUser(request.RequestUser, request.Reid);
        var acoes = await _acaoRepository.GetByResponsavel(request.Reid);
        return _mapper.Map<List<AcaoListDto>>(acoes);
    }
}