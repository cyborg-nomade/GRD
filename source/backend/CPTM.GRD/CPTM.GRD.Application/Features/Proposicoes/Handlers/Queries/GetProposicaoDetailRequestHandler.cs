using AutoMapper;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.Features.Proposicoes.Requests.Queries;
using CPTM.GRD.Application.Persistence.Contracts;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Handlers.Queries;

public class GetProposicaoDetailRequestHandler : IRequestHandler<GetProposicaoDetailRequest, ProposicaoDto>
{
    private readonly IProposicaoRepository _proposicaoRepository;
    private readonly IMapper _mapper;

    public GetProposicaoDetailRequestHandler(IProposicaoRepository proposicaoRepository, IMapper mapper)
    {
        _proposicaoRepository = proposicaoRepository;
        _mapper = mapper;
    }

    public async Task<ProposicaoDto> Handle(GetProposicaoDetailRequest request, CancellationToken cancellationToken)
    {
        var proposicao = await _proposicaoRepository.Get(request.Id);
        return _mapper.Map<ProposicaoDto>(proposicao);
    }
}