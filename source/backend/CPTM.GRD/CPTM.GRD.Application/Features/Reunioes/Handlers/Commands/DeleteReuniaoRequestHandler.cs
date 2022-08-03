using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Logging;
using CPTM.GRD.Application.Contracts.Persistence.Reunioes;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Application.Features.Reunioes.Requests.Commands;
using CPTM.GRD.Common;
using CPTM.GRD.Domain.Logging;
using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Handlers.Commands;

public class DeleteReuniaoRequestHandler : IRequestHandler<DeleteReuniaoRequest>
{
    private readonly IReuniaoRepository _reuniaoRepository;
    private readonly ILogReuniaoRepository _logReuniaoRepository;
    private readonly IUserRepository _userRepository;
    private readonly IAuthenticationService _authenticationService;

    public DeleteReuniaoRequestHandler(
        IReuniaoRepository reuniaoRepository,
        ILogReuniaoRepository logReuniaoRepository,
        IUserRepository userRepository,
        IAuthenticationService authenticationService)
    {
        _reuniaoRepository = reuniaoRepository;
        _logReuniaoRepository = logReuniaoRepository;
        _userRepository = userRepository;
        _authenticationService = authenticationService;
    }

    public async Task<Unit> Handle(DeleteReuniaoRequest request, CancellationToken cancellationToken)
    {
        _authenticationService.AuthorizeByMinLevel(request.RequestUser, AccessLevel.Grg);

        var reuniao = await _reuniaoRepository.Get(request.Rid);
        if (reuniao == null) throw new NotFoundException(nameof(reuniao), request.Rid);

        var claims = _authenticationService.GetTokenClaims(request.RequestUser);

        var responsavel = await _userRepository.Get(claims.Uid);
        if (responsavel == null) throw new NotFoundException(nameof(responsavel), claims.Uid);

        var removeLog = new LogReuniao(reuniao, TipoLogReuniao.Remocao, responsavel, "Remoção");
        await _logReuniaoRepository.Add(removeLog);

        await _reuniaoRepository.Delete(request.Rid);

        return Unit.Value;
    }
}