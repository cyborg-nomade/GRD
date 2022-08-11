using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.DTOs.AccessControl.User;
using CPTM.GRD.Application.Features.AccessControl.Requests.Queries;
using MediatR;

namespace CPTM.GRD.Application.Features.AccessControl.Handlers.Queries;

public class
    GetByGroupAndLevelUsersListRequestHandler : IRequestHandler<GetByGroupAndLevelUsersListRequest, List<UserDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthenticationService _authenticationService;
    private readonly IMapper _mapper;

    public GetByGroupAndLevelUsersListRequestHandler(IUnitOfWork unitOfWork,
        IAuthenticationService authenticationService,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _authenticationService = authenticationService;
        _mapper = mapper;
    }

    public async Task<List<UserDto>> Handle(GetByGroupAndLevelUsersListRequest request,
        CancellationToken cancellationToken)
    {
        await _authenticationService.AuthorizeByMinLevelAndGroup(request.RequestUser, request.Gid, request.Level);
        var users = await _unitOfWork.UserRepository.GetByGroupAndLevel(request.Gid, request.Level);
        return _mapper.Map<List<UserDto>>(users);
    }
}