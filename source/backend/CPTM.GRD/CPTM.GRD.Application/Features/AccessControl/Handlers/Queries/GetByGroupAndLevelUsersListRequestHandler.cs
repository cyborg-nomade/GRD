using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.DTOs.AccessControl.User;
using CPTM.GRD.Application.Features.AccessControl.Requests.Queries;
using MediatR;

namespace CPTM.GRD.Application.Features.AccessControl.Handlers.Queries;

public class
    GetByGroupAndLevelUsersListRequestHandler : IRequestHandler<GetByGroupAndLevelUsersListRequest, List<UserDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthenticationService _authenticationService;
    private readonly IMapper _mapper;

    public GetByGroupAndLevelUsersListRequestHandler(
        IUserRepository userRepository,
        IAuthenticationService authenticationService,
        IMapper mapper)
    {
        _userRepository = userRepository;
        _authenticationService = authenticationService;
        _mapper = mapper;
    }

    public async Task<List<UserDto>> Handle(GetByGroupAndLevelUsersListRequest request,
        CancellationToken cancellationToken)
    {
        await _authenticationService.AuthorizeByMinLevelAndGroup(request.RequestUser, request.Gid, request.Level);
        var users = await _userRepository.GetByGroupAndLevel(request.Gid, request.Level);
        return _mapper.Map<List<UserDto>>(users);
    }
}