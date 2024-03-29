﻿using CPTM.GRD.Application.DTOs.Main.Proposicao;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Requests.Queries;

public class GetByReuniaoProposicoesListRequest : BasicRequest, IRequest<List<ProposicaoListDto>>
{
    public int Rid { get; init; }
}