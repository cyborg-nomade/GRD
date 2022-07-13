﻿using CPTM.GRD.Application.DTOs.Main.Reuniao;
using CPTM.GRD.Common;
using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Requests.Queries;

public class GetByStatusReunioesListRequest : IRequest<List<ReuniaoListDto>>
{
    public ReuniaoStatus Status { get; set; }
}