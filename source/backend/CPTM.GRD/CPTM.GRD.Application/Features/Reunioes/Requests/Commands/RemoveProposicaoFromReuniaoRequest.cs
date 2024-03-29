﻿using CPTM.GRD.Application.DTOs.Main.Mixed;
using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Requests.Commands;

public class RemoveProposicaoFromReuniaoRequest : BasicRequest, IRequest<AddProposicaoToReuniaoDto>
{
    public int Rid { get; init; }
    public int Pid { get; init; }
}