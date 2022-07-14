﻿using CPTM.GRD.Application.DTOs.AccessControl;
using MediatR;

namespace CPTM.GRD.Application.Features.AccessControl.Requests.Commands;

public class CreateUserRequest : IRequest<UserDto>
{
    public CreateUserDto CreateUserDto { get; set; } = new CreateUserDto();
}