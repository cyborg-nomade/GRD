using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.DTOs.AccessControl.Group;
using CPTM.GRD.Application.Features.AccessControl.Requests.Queries;
using MediatR;

namespace CPTM.GRD.Application.Features.AccessControl.Handlers.Queries;

public class GetByUserGroupsListRequestHandler : IRequestHandler<GetByUserGroupsListRequest, List<GroupDto>>
{
    private readonly IGroupRepository _groupRepository;
    private readonly IAuthenticationService _authenticationService;
    private readonly IMapper _mapper;

    public GetByUserGroupsListRequestHandler(
        IGroupRepository groupRepository,
        IAuthenticationService authenticationService,
        IMapper mapper)
    {
        _groupRepository = groupRepository;
        _authenticationService = authenticationService;
        _mapper = mapper;
    }

    public async Task<List<GroupDto>> Handle(GetByUserGroupsListRequest request, CancellationToken cancellationToken)
    {
        await _authenticationService.AuthorizeByUserLevelAndGroup(request.RequestUser, request.Uid);
        var groups = await _groupRepository.GetByUser(request.Uid);
        return _mapper.Map<List<GroupDto>>(groups);
    }
}