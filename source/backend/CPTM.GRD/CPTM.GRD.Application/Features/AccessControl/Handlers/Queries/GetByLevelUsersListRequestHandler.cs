using AutoMapper;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.DTOs.AccessControl.User;
using CPTM.GRD.Application.Features.AccessControl.Requests.Queries;
using MediatR;

namespace CPTM.GRD.Application.Features.AccessControl.Handlers.Queries;

public class GetByLevelUsersListRequestHandler : IRequestHandler<GetByLevelUsersListRequest, List<UserDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetByLevelUsersListRequestHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<List<UserDto>> Handle(GetByLevelUsersListRequest request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetByLevel(request.Level);
        return _mapper.Map<List<UserDto>>(users);
    }
}