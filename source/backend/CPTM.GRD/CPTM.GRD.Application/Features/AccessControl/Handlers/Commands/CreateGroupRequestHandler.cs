using AutoMapper;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.DTOs.AccessControl.Group;
using CPTM.GRD.Application.Features.AccessControl.Requests.Commands;
using MediatR;

namespace CPTM.GRD.Application.Features.AccessControl.Handlers.Commands;

public class CreateGroupRequestHandler : IRequestHandler<CreateGroupRequest, GroupDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateGroupRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GroupDto> Handle(CreateGroupRequest request, CancellationToken cancellationToken)
    {
        var addedGroup = await _unitOfWork.GroupRepository.GetOrAddBySigla(request.Sigla);

        return _mapper.Map<GroupDto>(addedGroup);
    }
}