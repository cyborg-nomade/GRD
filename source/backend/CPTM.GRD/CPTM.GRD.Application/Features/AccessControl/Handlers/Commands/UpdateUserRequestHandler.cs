using AutoMapper;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.DTOs.AccessControl;
using CPTM.GRD.Application.Features.AccessControl.Requests.Commands;
using MediatR;

namespace CPTM.GRD.Application.Features.AccessControl.Handlers.Commands;

public class UpdateUserRequestHandler : IRequestHandler<UpdateUserRequest, UserDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UpdateUserRequestHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserDto> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var savedUser = await _userRepository.Get(request.UserDto.Id);
        _mapper.Map(request.UserDto, savedUser);
        var updatedUser = await _userRepository.Update(savedUser);
        return _mapper.Map<UserDto>(updatedUser);
    }
}