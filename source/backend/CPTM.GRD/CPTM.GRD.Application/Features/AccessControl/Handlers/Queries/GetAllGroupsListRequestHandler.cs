using AutoMapper;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.DTOs.AccessControl.Group;
using CPTM.GRD.Application.Features.AccessControl.Requests.Queries;
using MediatR;

namespace CPTM.GRD.Application.Features.AccessControl.Handlers.Queries;

public class GetAllGroupsListRequestHandler : IRequestHandler<GetAllGroupsListRequest, List<GroupDto>>
{
    private readonly IGroupRepository _groupRepository;
    private readonly IMapper _mapper;

    public GetAllGroupsListRequestHandler(IGroupRepository groupRepository, IMapper mapper)
    {
        _groupRepository = groupRepository;
        _mapper = mapper;
    }

    public async Task<List<GroupDto>> Handle(GetAllGroupsListRequest request, CancellationToken cancellationToken)
    {
        var groups = await _groupRepository.GetAll();
        return _mapper.Map<List<GroupDto>>(groups);
    }
}