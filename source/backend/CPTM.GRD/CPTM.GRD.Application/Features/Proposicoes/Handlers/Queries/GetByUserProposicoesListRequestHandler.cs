﻿using AutoMapper;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.Features.Proposicoes.Requests.Queries;
using CPTM.GRD.Application.Persistence.Contracts;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Handlers.Queries;

public class
    GetByUserProposicoesListRequestHandler : IRequestHandler<GetByUserProposicoesListRequest, List<ProposicaoListDto>>
{
    private readonly IProposicaoRepository _proposicaoRepository;
    private readonly IMapper _mapper;

    public GetByUserProposicoesListRequestHandler(IProposicaoRepository proposicaoRepository, IMapper mapper)
    {
        _proposicaoRepository = proposicaoRepository;
        _mapper = mapper;
    }

    public async Task<List<ProposicaoListDto>> Handle(GetByUserProposicoesListRequest request,
        CancellationToken cancellationToken)
    {
        var proposicoes = await _proposicaoRepository.GetByUser(request.Uid);
        return _mapper.Map<List<ProposicaoListDto>>(proposicoes);
    }
}