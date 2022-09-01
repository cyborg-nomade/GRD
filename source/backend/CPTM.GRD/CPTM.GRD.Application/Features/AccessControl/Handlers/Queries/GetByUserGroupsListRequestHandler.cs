using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.DTOs.AccessControl.Group;
using CPTM.GRD.Application.Features.AccessControl.Requests.Queries;
using MediatR;

namespace CPTM.GRD.Application.Features.AccessControl.Handlers.Queries;

public class GetByUserGroupsListRequestHandler : IRequestHandler<GetByUserGroupsListRequest, List<GroupDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthenticationService _authenticationService;
    private readonly IMapper _mapper;

    public GetByUserGroupsListRequestHandler(
        IUnitOfWork unitOfWork,
        IAuthenticationService authenticationService,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _authenticationService = authenticationService;
        _mapper = mapper;
    }

    public async Task<List<GroupDto>> Handle(GetByUserGroupsListRequest request, CancellationToken cancellationToken)
    {
        await _authenticationService.AuthorizeByUserLevelAndGroup(request.RequestUser, request.Uid);
        var groups = await _unitOfWork.GroupRepository.GetByUser(request.Uid);
        return _mapper.Map<List<GroupDto>>(groups);
    }
}