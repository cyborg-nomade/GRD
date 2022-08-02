using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Application.Features.AccessControl.Requests.Commands;
using CPTM.GRD.Common;
using MediatR;

namespace CPTM.GRD.Application.Features.AccessControl.Handlers.Commands;

public class DeleteUserRequestHandler : IRequestHandler<DeleteUserRequest, Unit>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthenticationService _authenticationService;

    public DeleteUserRequestHandler(IUserRepository userRepository,
        IAuthenticationService authenticationService)
    {
        _userRepository = userRepository;
        _authenticationService = authenticationService;
    }

    public async Task<Unit> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
    {
        _authenticationService.AuthorizeByMinLevel(request.RequestUser, AccessLevel.Gerente);

        var userExists = await _userRepository.Exists(request.Uid);

        if (!userExists)
        {
            throw new NotFoundException("Usuário", userExists);
        }

        var user = await _userRepository.Get(request.Uid);

        await _userRepository.Delete(request.Uid);
        return Unit.Value;
    }
}