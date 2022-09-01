using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Application.Features.Reunioes.Requests.Commands;
using CPTM.GRD.Common;
using CPTM.GRD.Domain.Logging;
using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Handlers.Commands;

public class DeleteReuniaoRequestHandler : IRequestHandler<DeleteReuniaoRequest>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthenticationService _authenticationService;

    public DeleteReuniaoRequestHandler(
        IUnitOfWork unitOfWork,
        IAuthenticationService authenticationService)
    {
        _unitOfWork = unitOfWork;
        _authenticationService = authenticationService;
    }

    public async Task<Unit> Handle(DeleteReuniaoRequest request, CancellationToken cancellationToken)
    {
        _authenticationService.AuthorizeByMinLevel(request.RequestUser, AccessLevel.Grg);

        var reuniao = await _unitOfWork.ReuniaoRepository.Get(request.Rid);
        if (reuniao == null) throw new NotFoundException(nameof(reuniao), request.Rid);

        var claims = _authenticationService.GetTokenClaims(request.RequestUser);

        var responsavel = await _unitOfWork.UserRepository.Get(claims.Uid);
        if (responsavel == null) throw new NotFoundException(nameof(responsavel), claims.Uid);

        var removeLog = new LogReuniao(reuniao, TipoLogReuniao.Remocao, responsavel, "Remoção");

        await _unitOfWork.LogReuniaoRepository.Add(removeLog);
        await _unitOfWork.ReuniaoRepository.Delete(request.Rid);
        await _unitOfWork.Save();

        return Unit.Value;
    }
}