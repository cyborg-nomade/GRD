﻿using CPTM.GRD.Application.DTOs.AccessControl.User;
using MediatR;

namespace CPTM.GRD.Application.Features.AccessControl.Requests.Queries;

public class GetByGroupUsersListRequest : IRequest<List<UserDto>>
{
    public int Gid { get; set; }
}