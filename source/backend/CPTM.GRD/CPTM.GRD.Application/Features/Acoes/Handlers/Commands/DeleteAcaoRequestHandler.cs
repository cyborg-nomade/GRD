using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Application.Features.Acoes.Requests.Commands;
using CPTM.GRD.Common;
using CPTM.GRD.Domain.Logging;
using MediatR;

namespace CPTM.GRD.Application.Features.Acoes.Handlers.Commands;

public class DeleteAcaoRequestHandler : IRequestHandler<DeleteAcaoRequest, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthenticationService _authenticationService;

    public DeleteAcaoRequestHandler(
        IUnitOfWork unitOfWork,
        IAuthenticationService authenticationService)
    {
        _unitOfWork = unitOfWork;
        _authenticationService = authenticationService;
    }

    public async Task<Unit> Handle(DeleteAcaoRequest request, CancellationToken cancellationToken)
    {
        _authenticationService.AuthorizeByMinLevel(request.RequestUser, AccessLevel.Grg);

        var acao = await _unitOfWork.AcaoRepository.Get(request.Aid);
        if (acao == null) throw new NotFoundException(nameof(acao), request.Aid);

        var claims = _authenticationService.GetTokenClaims(request.RequestUser);

        var responsavel = await _unitOfWork.UserRepository.Get(claims.Uid);
        if (responsavel == null) throw new NotFoundException(nameof(responsavel), claims.Uid);

        var removeLog = new LogAcao(acao, TipoLogAcao.Remocao, "Remoção", responsavel);

        await _unitOfWork.LogAcaoRepository.Add(removeLog);
        await _unitOfWork.AcaoRepository.Delete(request.Aid);
        await _unitOfWork.Save();

        return Unit.Value;
    }
}