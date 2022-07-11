using AutoMapper;
using CPTM.GRD.Application.DTOs.Lists;
using CPTM.GRD.Application.Features.Proposicoes.Requests.Queries;
using CPTM.GRD.Application.Persistence.Contracts;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Handlers.Queries;

public class GetProposicaoListRequestHandler : IRequestHandler<GetProposicaoListRequest, List<ProposicaoListDto>>
{
    private readonly IProposicaoRepository _proposicaoRepository;
    private readonly IMapper _mapper;

    public GetProposicaoListRequestHandler(IProposicaoRepository proposicaoRepository, IMapper mapper)
    {
        _proposicaoRepository = proposicaoRepository;
        _mapper = mapper;
    }

    public async Task<List<ProposicaoListDto>> Handle(GetProposicaoListRequest request, CancellationToken cancellationToken)
    {
        var proposicoes = await _proposicaoRepository.GetAll();
        return _mapper.Map<List<ProposicaoListDto>>(proposicoes);
    }
}