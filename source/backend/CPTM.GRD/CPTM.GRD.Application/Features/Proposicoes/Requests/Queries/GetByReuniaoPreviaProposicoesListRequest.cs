﻿using CPTM.GRD.Application.DTOs.Main.Proposicao;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Requests.Queries;

public class GetByReuniaoPreviaProposicoesListRequest : IRequest<List<ProposicaoListDto>>
{
    public int Rid { get; set; }
}