﻿using CPTM.GRD.Application.DTOs.Main.Proposicao;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Requests.Commands;

public class DiretoriaResponsavelApproveProposicaoRequest : IRequest<ProposicaoDto>
{
    public int Pid { get; init; }
    public int Uid { get; init; }
}