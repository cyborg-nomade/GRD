using AutoMapper;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.DTOs.AccessControl;
using CPTM.GRD.Application.Features.AccessControl.Requests.Queries;
using MediatR;

namespace CPTM.GRD.Application.Features.AccessControl.Handlers.Queries;

public class GetByGroupUsersListRequestHandler : IRequestHandler<GetByGroupUsersListRequest, List<UserDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetByGroupUsersListRequestHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<List<UserDto>> Handle(GetByGroupUsersListRequest request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetByGroup(request.Gid);
        return _mapper.Map<List<UserDto>>(users);
    }
}