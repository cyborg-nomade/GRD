using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.Proposicoes;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.Features.Proposicoes.Requests.Queries;
using CPTM.GRD.Common;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Handlers.Queries;

public class
    GetByReuniaoPreviaProposicoesListRequestHandler : IRequestHandler<GetByReuniaoPreviaProposicoesListRequest,
        List<ProposicaoListDto>>
{
    private readonly IProposicaoRepository _proposicaoRepository;
    private readonly IMapper _mapper;
    private readonly IAuthenticationService _authenticationService;

    public GetByReuniaoPreviaProposicoesListRequestHandler(
        IProposicaoRepository proposicaoRepository,
        IMapper mapper,
        IAuthenticationService authenticationService)
    {
        _proposicaoRepository = proposicaoRepository;
        _mapper = mapper;
        _authenticationService = authenticationService;
    }

    public async Task<List<ProposicaoListDto>> Handle(GetByReuniaoPreviaProposicoesListRequest request,
        CancellationToken cancellationToken)
    {
        _authenticationService.AuthorizeByMinLevel(request.RequestUser, AccessLevel.Grg);
        var proposicoes = await _proposicaoRepository.GetByReuniaoPrevia(request.Rid);
        return _mapper.Map<List<ProposicaoListDto>>(proposicoes);
    }
}