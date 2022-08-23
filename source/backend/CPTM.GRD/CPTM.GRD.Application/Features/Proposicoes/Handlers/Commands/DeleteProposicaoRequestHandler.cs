using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Application.Features.Proposicoes.Requests.Commands;
using CPTM.GRD.Common;
using CPTM.GRD.Domain.AccessControl;
using CPTM.GRD.Domain.Logging;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Handlers.Commands;

public class DeleteProposicaoRequestHandler : IRequestHandler<DeleteProposicaoRequest>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthenticationService _authenticationService;

    public DeleteProposicaoRequestHandler(
        IUnitOfWork unitOfWork,
        IAuthenticationService authenticationService)
    {
        _unitOfWork = unitOfWork;
        _authenticationService = authenticationService;
    }

    public async Task<Unit> Handle(DeleteProposicaoRequest request, CancellationToken cancellationToken)
    {
        var proposicao = await _unitOfWork.ProposicaoRepository.Get(request.Pid);
        if (proposicao == null) throw new NotFoundException(nameof(proposicao), request.Pid);

        var responsavel = new User();
        if (proposicao.Criador != null)
        {
            _authenticationService.AuthorizeByExactUser(request.RequestUser, proposicao.Criador);
        }
        else
        {
            var claims = _authenticationService.GetTokenClaims(request.RequestUser);

            responsavel = await _unitOfWork.UserRepository.Get(claims.Uid);
            if (responsavel == null) throw new NotFoundException(nameof(responsavel), claims.Uid);
        }

        var removeLog = new LogProposicao(
            proposicao,
            TipoLogProposicao.Remocao,
            proposicao.Criador ?? responsavel,
            "Remoção");

        await _unitOfWork.LogProposicaoRepository.Add(removeLog);
        await _unitOfWork.ProposicaoRepository.Delete(request.Pid);
        await _unitOfWork.Save();

        return Unit.Value;
    }
}