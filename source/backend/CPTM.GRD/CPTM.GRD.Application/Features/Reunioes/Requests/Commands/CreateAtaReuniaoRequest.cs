﻿using CPTM.GRD.Application.DTOs.Main.Reuniao;
using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Requests.Commands;

public class CreateAtaReuniaoRequest : BasicRequest, IRequest<ReuniaoDto>
{
    public int Rid { get; init; }
}