using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Features.AccessControl.Requests.Commands;
using MediatR;

namespace CPTM.GRD.Application.Features.AccessControl.Handlers.Commands;

public class DeleteUserRequestHandler : IRequestHandler<DeleteUserRequest, Unit>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserRequestHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Unit> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
    {
        var userExists = await _userRepository.Exists(request.Uid);

        if (!userExists)
        {
            throw new Exception("Usuário não encontrado");
        }

        await _userRepository.Delete(request.Uid);
        return Unit.Value;
    }
}