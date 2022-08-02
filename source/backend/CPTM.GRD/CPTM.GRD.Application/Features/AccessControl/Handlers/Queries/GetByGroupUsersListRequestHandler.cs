using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.DTOs.AccessControl.User;
using CPTM.GRD.Application.Features.AccessControl.Requests.Queries;
using MediatR;

namespace CPTM.GRD.Application.Features.AccessControl.Handlers.Queries;

public class GetByGroupUsersListRequestHandler : IRequestHandler<GetByGroupUsersListRequest, List<UserDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthenticationService _authenticationService;
    private readonly IMapper _mapper;

    public GetByGroupUsersListRequestHandler(
        IUserRepository userRepository,
        IAuthenticationService authenticationService,
        IMapper mapper)
    {
        _userRepository = userRepository;
        _authenticationService = authenticationService;
        _mapper = mapper;
    }

    public async Task<List<UserDto>> Handle(GetByGroupUsersListRequest request, CancellationToken cancellationToken)
    {
        await _authenticationService.AuthorizeByMinGroups(request.RequestUser, request.Gid);
        var users = await _userRepository.GetByGroup(request.Gid);
        return _mapper.Map<List<UserDto>>(users);
    }
}