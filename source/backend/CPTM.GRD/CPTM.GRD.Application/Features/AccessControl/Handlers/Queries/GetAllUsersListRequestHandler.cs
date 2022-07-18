using AutoMapper;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.DTOs.AccessControl.User;
using CPTM.GRD.Application.Features.AccessControl.Requests.Queries;
using MediatR;

namespace CPTM.GRD.Application.Features.AccessControl.Handlers.Queries;

public class GetAllUsersListRequestHandler : IRequestHandler<GetAllUsersListRequest, List<UserDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetAllUsersListRequestHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<List<UserDto>> Handle(GetAllUsersListRequest request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAll();
        return _mapper.Map<List<UserDto>>(users);
    }
}