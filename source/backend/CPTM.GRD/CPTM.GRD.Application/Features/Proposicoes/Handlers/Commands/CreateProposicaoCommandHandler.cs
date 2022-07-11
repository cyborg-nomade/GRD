using AutoMapper;
using CPTM.GRD.Application.Features.Proposicoes.Requests.Commands;
using CPTM.GRD.Application.Persistence.Contracts;
using CPTM.GRD.Domain;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Handlers.Commands;

public class CreateProposicaoCommandHandler : IRequestHandler<CreateProposicaoCommand, int>
{
    private readonly IProposicaoRepository _proposicaoRepository;
    private readonly IMapper _mapper;

    public CreateProposicaoCommandHandler(IProposicaoRepository proposicaoRepository, IMapper mapper)
    {
        _proposicaoRepository = proposicaoRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateProposicaoCommand command, CancellationToken cancellationToken)
    {
        var proposicao = _mapper.Map<Proposicao>(command.ProposicaoDto);
        var addedProposicao = await _proposicaoRepository.Add(proposicao);
        return addedProposicao.Id;
    }
}