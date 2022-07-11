using AutoMapper;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.Features.Proposicoes.Requests.Queries;
using CPTM.GRD.Application.Persistence.Contracts;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Handlers.Queries;

public class GetByGroupAndStatusProposicoesListRequestHandler : IRequestHandler<GetByGroupAndStatusProposicoesListRequest, List<ProposicaoListDto>>
{
    private readonly IProposicaoRepository _proposicaoRepository;
    private readonly IMapper _mapper;

    public GetByGroupAndStatusProposicoesListRequestHandler(IProposicaoRepository proposicaoRepository, IMapper mapper)
    {
        _proposicaoRepository = proposicaoRepository;
        _mapper = mapper;
    }

    public async Task<List<ProposicaoListDto>> Handle(GetByGroupAndStatusProposicoesListRequest request, CancellationToken cancellationToken)
    {
        var proposicoes = await _proposicaoRepository.GetByGroupAndStatus(request.Gid, request.Status);
        return _mapper.Map<List<ProposicaoListDto>>(proposicoes);
    }
}