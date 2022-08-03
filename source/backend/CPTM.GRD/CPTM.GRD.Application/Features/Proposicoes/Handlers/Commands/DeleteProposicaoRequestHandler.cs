using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.Logging;
using CPTM.GRD.Application.Contracts.Persistence.Proposicoes;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Application.Features.Proposicoes.Requests.Commands;
using CPTM.GRD.Common;
using CPTM.GRD.Domain.Logging;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Handlers.Commands;

public class DeleteProposicaoRequestHandler : IRequestHandler<DeleteProposicaoRequest>
{
    private readonly IProposicaoRepository _proposicaoRepository;
    private readonly ILogProposicaoRepository _logProposicaoRepository;
    private readonly IAuthenticationService _authenticationService;

    public DeleteProposicaoRequestHandler(
        IProposicaoRepository proposicaoRepository,
        ILogProposicaoRepository logProposicaoRepository,
        IAuthenticationService authenticationService)
    {
        _proposicaoRepository = proposicaoRepository;
        _logProposicaoRepository = logProposicaoRepository;
        _authenticationService = authenticationService;
    }

    public async Task<Unit> Handle(DeleteProposicaoRequest request, CancellationToken cancellationToken)
    {
        var proposicao = await _proposicaoRepository.Get(request.Pid);
        if (proposicao == null) throw new NotFoundException(nameof(proposicao), request.Pid);

        _authenticationService.AuthorizeByExactUser(request.RequestUser, proposicao.Criador);

        var removeLog = new LogProposicao(
            proposicao,
            TipoLogProposicao.Remocao,
            proposicao.Criador,
            "Remoção");
        await _logProposicaoRepository.Add(removeLog);

        await _proposicaoRepository.Delete(request.Pid);
        return Unit.Value;
    }
}