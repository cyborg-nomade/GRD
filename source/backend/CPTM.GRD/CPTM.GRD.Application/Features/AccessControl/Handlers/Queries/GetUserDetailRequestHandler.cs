using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.DTOs.AccessControl.User;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Application.Features.AccessControl.Requests.Queries;
using MediatR;

namespace CPTM.GRD.Application.Features.AccessControl.Handlers.Queries;

public class GetUserDetailRequestHandler : IRequestHandler<GetUserDetailRequest, UserDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthenticationService _authenticationService;
    private readonly IMapper _mapper;

    public GetUserDetailRequestHandler(
        IUserRepository userRepository,
        IAuthenticationService authenticationService,
        IMapper mapper)
    {
        _userRepository = userRepository;
        _authenticationService = authenticationService;
        _mapper = mapper;
    }

    public async Task<UserDto> Handle(GetUserDetailRequest request, CancellationToken cancellationToken)
    {
        await _authenticationService.AuthorizeByUserLevelAndGroup(request.RequestUser, request.Uid);
        var user = await _userRepository.Get(request.Uid);
        if (user == null) throw new NotFoundException(nameof(user), request.Uid);
        return _mapper.Map<UserDto>(user);
    }
}