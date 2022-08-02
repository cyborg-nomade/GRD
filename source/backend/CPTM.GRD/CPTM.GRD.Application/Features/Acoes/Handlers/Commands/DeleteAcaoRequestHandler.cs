using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Acoes;
using CPTM.GRD.Application.Contracts.Persistence.Logging;
using CPTM.GRD.Application.Exceptions;
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
    private readonly IAuthenticationService _authenticationService;

    public DeleteAcaoRequestHandler(
        IAcaoRepository acaoRepository,
        ILogAcaoRepository logAcaoRepository,
        IUserRepository userRepository,
        IAuthenticationService authenticationService)
    {
        _acaoRepository = acaoRepository;
        _logAcaoRepository = logAcaoRepository;
        _userRepository = userRepository;
        _authenticationService = authenticationService;
    }

    public async Task<Unit> Handle(DeleteAcaoRequest request, CancellationToken cancellationToken)
    {
        _authenticationService.AuthorizeByMinLevel(request.RequestUser, AccessLevel.Grg);

        var acao = await _acaoRepository.Get(request.Aid);
        if (acao == null) throw new NotFoundException(nameof(acao), request.Aid);

        var claims = _authenticationService.GetTokenClaims(request.RequestUser);

        var responsavel = await _userRepository.Get(claims.Uid);
        if (responsavel == null) throw new NotFoundException(nameof(responsavel), claims.Uid);

        var removeLog = new LogAcao(acao, TipoLogAcao.Remocao, "Remoção", responsavel);
        await _logAcaoRepository.Add(removeLog);

        await _acaoRepository.Delete(request.Aid);

        return Unit.Value;
    }
}