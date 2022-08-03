﻿using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Proposicoes;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Application.Features.Proposicoes.Requests.Commands;
using CPTM.GRD.Common;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Handlers.Commands;

public class
    AnnotateInPreviaProposicaoRequestHandler : IRequestHandler<AnnotateInPreviaProposicaoRequest, ProposicaoDto>
{
    private readonly IProposicaoRepository _proposicaoRepository;
    private readonly IUserRepository _userRepository;
    private readonly IAuthenticationService _authenticationService;
    private readonly IMapper _mapper;

    public AnnotateInPreviaProposicaoRequestHandler(
        IProposicaoRepository proposicaoRepository,
        IUserRepository userRepository,
        IAuthenticationService authenticationService,
        IMapper mapper)
    {
        _proposicaoRepository = proposicaoRepository;
        _userRepository = userRepository;
        _authenticationService = authenticationService;
        _mapper = mapper;
    }

    public async Task<ProposicaoDto> Handle(AnnotateInPreviaProposicaoRequest request,
        CancellationToken cancellationToken)
    {
        _authenticationService.AuthorizeByMinLevel(request.RequestUser, AccessLevel.Grg);

        var proposicao = await _proposicaoRepository.Get(request.Pid);
        if (proposicao == null) throw new NotFoundException(nameof(proposicao), request.Pid);

        var claims = _authenticationService.GetTokenClaims(request.RequestUser);

        var responsavel = await _userRepository.Get(claims.Uid);
        if (responsavel == null) throw new NotFoundException(nameof(responsavel), claims.Uid);

        proposicao.AnnotateProposicaoInPrevia(responsavel, request.Anotacao);

        var updatedProposicao = await _proposicaoRepository.Update(proposicao);

        return _mapper.Map<ProposicaoDto>(updatedProposicao);
    }
}