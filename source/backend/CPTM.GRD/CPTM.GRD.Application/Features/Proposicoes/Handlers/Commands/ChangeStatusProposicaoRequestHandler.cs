using AutoMapper;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.Features.Proposicoes.Requests.Commands;
using CPTM.GRD.Application.Persistence.Contracts;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Handlers.Commands;

public class ChangeStatusProposicaoRequestHandler : IRequestHandler<ChangeStatusProposicaoRequest, ProposicaoDto>
{
    private readonly IProposicaoRepository _proposicaoRepository;
    private readonly IMapper _mapper;

    public ChangeStatusProposicaoRequestHandler(IProposicaoRepository proposicaoRepository, IMapper mapper)
    {
        _proposicaoRepository = proposicaoRepository;
        _mapper = mapper;
    }


    public async Task<ProposicaoDto> Handle(ChangeStatusProposicaoRequest request, CancellationToken cancellationToken)
    {
        var proposicao = await _proposicaoRepository.Get(request.Id);
        proposicao.Status = request.NewStatus;
        var updatedProposicao = await _proposicaoRepository.Update(proposicao);
        return _mapper.Map<ProposicaoDto>(updatedProposicao);
    }
}