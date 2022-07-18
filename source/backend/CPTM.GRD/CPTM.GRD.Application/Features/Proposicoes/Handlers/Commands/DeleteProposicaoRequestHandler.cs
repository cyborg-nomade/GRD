using AutoMapper;
using CPTM.GRD.Application.Contracts.Persistence.Logging;
using CPTM.GRD.Application.Contracts.Persistence.Proposicoes;
using CPTM.GRD.Application.Features.Proposicoes.Requests.Commands;
using CPTM.GRD.Common;
using CPTM.GRD.Domain.Logging;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Handlers.Commands;

public class DeleteProposicaoRequestHandler : IRequestHandler<DeleteProposicaoRequest>
{
    private readonly IProposicaoRepository _proposicaoRepository;
    private readonly ILogProposicaoRepository _logProposicaoRepository;

    public DeleteProposicaoRequestHandler(IProposicaoRepository proposicaoRepository,
        ILogProposicaoRepository logProposicaoRepository, IMapper mapper)
    {
        _proposicaoRepository = proposicaoRepository;
        _logProposicaoRepository = logProposicaoRepository;
    }

    public async Task<Unit> Handle(DeleteProposicaoRequest request, CancellationToken cancellationToken)
    {
        var proposicaoExists = await _proposicaoRepository.Exists(request.Pid);

        if (!(proposicaoExists))
        {
            throw new Exception("Proposição não encontrada");
        }

        var proposicao = await _proposicaoRepository.Get(request.Pid);

        var removeLog = new LogProposicao(proposicao, TipoLogProposicao.Remocao,
            proposicao.Criador,
            "Remoção");
        await _logProposicaoRepository.Add(removeLog);

        await _proposicaoRepository.Delete(request.Pid);
        return Unit.Value;
    }
}