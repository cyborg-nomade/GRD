using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.DTOs.AccessControl.Group;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Application.Features.AccessControl.Requests.Queries;
using MediatR;

namespace CPTM.GRD.Application.Features.AccessControl.Handlers.Queries;

public class GetGroupDetailRequestHandler : IRequestHandler<GetGroupDetailRequest, GroupDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthenticationService _authenticationService;
    private readonly IMapper _mapper;

    public GetGroupDetailRequestHandler(
        IUnitOfWork unitOfWork,
        IAuthenticationService authenticationService,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _authenticationService = authenticationService;
        _mapper = mapper;
    }

    public async Task<GroupDto> Handle(GetGroupDetailRequest request, CancellationToken cancellationToken)
    {
        await _authenticationService.AuthorizeByMinGroups(request.RequestUser, request.Gid);
        var group = await _unitOfWork.GroupRepository.Get(request.Gid);

        if (group == null) throw new NotFoundException(nameof(group), request.Gid);

        return _mapper.Map<GroupDto>(group);
    }
}