﻿using CPTM.GRD.Application.DTOs.Main.Reuniao;
using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Requests.Commands;

public class CreateReuniaoRequest : BasicRequest, IRequest<ReuniaoDto>
{
    public CreateReuniaoDto CreateReuniaoDto { get; init; } = new CreateReuniaoDto();
}