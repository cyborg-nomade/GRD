﻿using AutoMapper;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.Features.Proposicoes.Requests.Commands;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Handlers.Commands;

public class
    AnnotateInPreviaProposicaoRequestHandler : IRequestHandler<AnnotateInPreviaProposicaoRequest, ProposicaoDto>
{
    private readonly IProposicaoRepository _proposicaoRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public AnnotateInPreviaProposicaoRequestHandler(IProposicaoRepository proposicaoRepository,
        IUserRepository userRepository, IMapper mapper)
    {
        _proposicaoRepository = proposicaoRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<ProposicaoDto> Handle(AnnotateInPreviaProposicaoRequest request,
        CancellationToken cancellationToken)
    {
        var proposicao = await _proposicaoRepository.Get(request.Pid);
        var responsavel = await _userRepository.Get(request.Uid);

        proposicao.AnnotateProposicaoInPrevia(responsavel, request.Anotacao);

        var updatedProposicao = await _proposicaoRepository.Update(proposicao);

        return _mapper.Map<ProposicaoDto>(updatedProposicao);
        ;
    }
}