using AutoMapper;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.DTOs.AccessControl;
using CPTM.GRD.Application.Features.AccessControl.Requests.Queries;
using MediatR;

namespace CPTM.GRD.Application.Features.AccessControl.Handlers.Queries;

public class
    GetByGroupAndLevelUsersListRequestHandler : IRequestHandler<GetByGroupAndLevelUsersListRequest, List<UserDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetByGroupAndLevelUsersListRequestHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<List<UserDto>> Handle(GetByGroupAndLevelUsersListRequest request,
        CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetByGroupAndLevel(request.Gid, request.Level);
        return _mapper.Map<List<UserDto>>(users);
    }
}