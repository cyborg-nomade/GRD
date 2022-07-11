using AutoMapper;
using CPTM.GRD.Application.DTOs.Lists;
using CPTM.GRD.Application.Features.Proposicoes.Requests.Queries;
using CPTM.GRD.Application.Persistence.Contracts;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Handlers.Queries;

public class GetByUserAndStatusProposicoesListRequestHandler : IRequestHandler<GetByUserAndStatusProposicoesListRequest, List<ProposicaoListDto>>
{
    private readonly IProposicaoRepository _proposicaoRepository;
    private readonly IMapper _mapper;

    public GetByUserAndStatusProposicoesListRequestHandler(IProposicaoRepository proposicaoRepository, IMapper mapper)
    {
        _proposicaoRepository = proposicaoRepository;
        _mapper = mapper;
    }

    public async Task<List<ProposicaoListDto>> Handle(GetByUserAndStatusProposicoesListRequest request, CancellationToken cancellationToken)
    {
        var proposicoes = await _proposicaoRepository.GetByUserAndStatus(request.Uid,request.Status);
        return _mapper.Map<List<ProposicaoListDto>>(proposicoes);
    }
}