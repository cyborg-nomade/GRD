using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Acoes;
using CPTM.GRD.Application.Contracts.Persistence.Logging;
using CPTM.GRD.Application.Features.Acoes.Requests.Commands;
using CPTM.GRD.Common;
using CPTM.GRD.Domain.Logging;
using MediatR;

namespace CPTM.GRD.Application.Features.Acoes.Handlers.Commands;

public class DeleteAcaoRequestHandler : IRequestHandler<DeleteAcaoRequest, Unit>
{
    private readonly IAcaoRepository _acaoRepository;
    private readonly ILogAcaoRepository _logAcaoRepository;
    private readonly IUserRepository _userRepository;

    public DeleteAcaoRequestHandler(IAcaoRepository acaoRepository, ILogAcaoRepository logAcaoRepository,
        IUserRepository userRepository)
    {
        _acaoRepository = acaoRepository;
        _logAcaoRepository = logAcaoRepository;
        _userRepository = userRepository;
    }

    public async Task<Unit> Handle(DeleteAcaoRequest request, CancellationToken cancellationToken)
    {
        var acao = await _acaoRepository.Get(request.Aid);

        var removeLog = new LogAcao(acao, TipoLogAcao.Remocao, "Remoção");
        await _logAcaoRepository.Add(removeLog);

        await _acaoRepository.Delete(request.Aid);

        return Unit.Value;
    }
}