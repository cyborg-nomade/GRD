﻿using AutoMapper;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.DTOs.AccessControl;
using CPTM.GRD.Application.Features.AccessControl.Requests.Queries;
using MediatR;

namespace CPTM.GRD.Application.Features.AccessControl.Handlers.Queries;

public class GetGroupDetailRequestHandler : IRequestHandler<GetGroupDetailRequest, GroupDto>
{
    private readonly IGroupRepository _groupRepository;
    private readonly IMapper _mapper;

    public GetGroupDetailRequestHandler(IGroupRepository groupRepository, IMapper mapper)
    {
        _groupRepository = groupRepository;
        _mapper = mapper;
    }

    public async Task<GroupDto> Handle(GetGroupDetailRequest request, CancellationToken cancellationToken)
    {
        var group = await _groupRepository.Get(request.Gid);
        return _mapper.Map<GroupDto>(group);
    }
}