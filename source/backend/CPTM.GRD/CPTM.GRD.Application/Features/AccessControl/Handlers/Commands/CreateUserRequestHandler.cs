using AutoMapper;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.DTOs.AccessControl.User;
using CPTM.GRD.Application.Features.AccessControl.Requests.Commands;
using CPTM.GRD.Domain.AccessControl;
using MediatR;

namespace CPTM.GRD.Application.Features.AccessControl.Handlers.Commands;

public class CreateUserRequestHandler : IRequestHandler<CreateUserRequest, UserDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public CreateUserRequestHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserDto> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(request.CreateUserDto);
        var addedUser = await _userRepository.Add(user);
        return _mapper.Map<UserDto>(addedUser);
    }
}