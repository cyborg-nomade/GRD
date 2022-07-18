using AutoMapper;
using CPTM.GRD.Application.Contracts.Persistence.Proposicoes;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.Features.Proposicoes.Requests.Queries;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Handlers.Queries;

public class
    GetByReuniaoPreviaProposicoesListRequestHandler : IRequestHandler<GetByReuniaoPreviaProposicoesListRequest,
        List<ProposicaoListDto>>
{
    private readonly IProposicaoRepository _proposicaoRepository;
    private readonly IMapper _mapper;

    public GetByReuniaoPreviaProposicoesListRequestHandler(IProposicaoRepository proposicaoRepository, IMapper mapper)
    {
        _proposicaoRepository = proposicaoRepository;
        _mapper = mapper;
    }

    public async Task<List<ProposicaoListDto>> Handle(GetByReuniaoPreviaProposicoesListRequest request,
        CancellationToken cancellationToken)
    {
        var proposicoes = await _proposicaoRepository.GetByReuniaoPrevia(request.Rid);
        return _mapper.Map<List<ProposicaoListDto>>(proposicoes);
    }
}