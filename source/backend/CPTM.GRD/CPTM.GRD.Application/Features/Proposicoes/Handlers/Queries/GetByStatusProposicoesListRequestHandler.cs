using AutoMapper;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.Features.Proposicoes.Requests.Queries;
using CPTM.GRD.Application.Persistence.Contracts;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Handlers.Queries;

public class
    GetByStatusProposicoesListRequestHandler : IRequestHandler<GetByStatusProposicoesListRequest,
        List<ProposicaoListDto>>
{
    private readonly IProposicaoRepository _proposicaoRepository;
    private readonly IMapper _mapper;

    public GetByStatusProposicoesListRequestHandler(IProposicaoRepository proposicaoRepository, IMapper mapper)
    {
        _proposicaoRepository = proposicaoRepository;
        _mapper = mapper;
    }

    public async Task<List<ProposicaoListDto>> Handle(GetByStatusProposicoesListRequest request,
        CancellationToken cancellationToken)
    {
        var proposicoes = await _proposicaoRepository.GetByStatus(request.Status, request.Arquivada);
        return _mapper.Map<List<ProposicaoListDto>>(proposicoes);
    }
}