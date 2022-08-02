using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.DTOs.AccessControl.Group;
using CPTM.GRD.Application.Features.AccessControl.Requests.Queries;
using CPTM.GRD.Common;
using MediatR;

namespace CPTM.GRD.Application.Features.AccessControl.Handlers.Queries;

public class GetAllGroupsListRequestHandler : IRequestHandler<GetAllGroupsListRequest, List<GroupDto>>
{
    private readonly IGroupRepository _groupRepository;
    private readonly IAuthenticationService _authenticationService;
    private readonly IMapper _mapper;

    public GetAllGroupsListRequestHandler(
        IGroupRepository groupRepository,
        IAuthenticationService authenticationService,
        IMapper mapper)
    {
        _groupRepository = groupRepository;
        _authenticationService = authenticationService;
        _mapper = mapper;
    }

    public async Task<List<GroupDto>> Handle(GetAllGroupsListRequest request, CancellationToken cancellationToken)
    {
        _authenticationService.AuthorizeByMinLevel(request.RequestUser, AccessLevel.Grg);
        var groups = await _groupRepository.GetAll();
        return _mapper.Map<List<GroupDto>>(groups);
    }
}