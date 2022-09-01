using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.DTOs.AccessControl.Group;
using CPTM.GRD.Application.Features.AccessControl.Requests.Commands;
using CPTM.GRD.Common;
using MediatR;

namespace CPTM.GRD.Application.Features.AccessControl.Handlers.Commands;

public class GetOrAddBySiglaGroupRequestHandler : IRequestHandler<GetOrAddBySiglaGroupRequest, GroupDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthenticationService _authenticationService;
    private readonly IMapper _mapper;

    public GetOrAddBySiglaGroupRequestHandler(
        IUnitOfWork unitOfWork,
        IAuthenticationService authenticationService,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _authenticationService = authenticationService;
        _mapper = mapper;
    }

    public async Task<GroupDto> Handle(GetOrAddBySiglaGroupRequest request, CancellationToken cancellationToken)
    {
        _authenticationService.AuthorizeByMinLevel(request.RequestUser, AccessLevel.Grg);

        var group = await _unitOfWork.GroupRepository.GetOrAddBySigla(request.Sigla);

        return _mapper.Map<GroupDto>(group);
    }
}