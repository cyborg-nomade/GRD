﻿using AutoMapper;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.Contracts.Persistence.StrictSequenceControl;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.Features.Proposicoes.Requests.Commands;
using CPTM.GRD.Common;
using CPTM.GRD.Domain;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Handlers.Commands;

public class CreateProposicaoRequestHandler : IRequestHandler<CreateProposicaoRequest, ProposicaoDto>
{
    private readonly IProposicaoRepository _proposicaoRepository;
    private readonly IMapper _mapper;
    private readonly IProposicaoStrictSequenceControl _sequenceControl;

    public CreateProposicaoRequestHandler(IProposicaoRepository proposicaoRepository, IMapper mapper,
        IProposicaoStrictSequenceControl sequenceControl)
    {
        _proposicaoRepository = proposicaoRepository;
        _mapper = mapper;
        _sequenceControl = sequenceControl;
    }

    public async Task<ProposicaoDto> Handle(CreateProposicaoRequest request, CancellationToken cancellationToken)
    {
        var proposicao = _mapper.Map<Proposicao>(request.CreateProposicaoDto);
        proposicao.IdPrd = await _sequenceControl.GetNextIdPrd();

        proposicao.GenerateProposicaoLog(TipoLogProposicao.Criacao, proposicao.Criador, "Salvamento inicial");

        var addedProposicao = await _proposicaoRepository.Add(proposicao);

        return _mapper.Map<ProposicaoDto>(addedProposicao);
    }
}