using AutoMapper;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.DTOs.AccessControl.Group;
using CPTM.GRD.Application.Features.AccessControl.Requests.Queries;
using MediatR;

namespace CPTM.GRD.Application.Features.AccessControl.Handlers.Queries;

public class GetByUserGroupsListRequestHandler : IRequestHandler<GetByUserGroupsListRequest, List<GroupDto>>
{
    private readonly IGroupRepository _groupRepository;
    private readonly IMapper _mapper;

    public GetByUserGroupsListRequestHandler(IGroupRepository groupRepository, IMapper mapper)
    {
        _groupRepository = groupRepository;
        _mapper = mapper;
    }

    public async Task<List<GroupDto>> Handle(GetByUserGroupsListRequest request, CancellationToken cancellationToken)
    {
        var groups = await _groupRepository.GetByUser(request.Uid);
        return _mapper.Map<List<GroupDto>>(groups);
    }
}