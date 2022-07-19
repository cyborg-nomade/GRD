﻿using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Acoes;
using CPTM.GRD.Application.Contracts.Persistence.Proposicoes;
using CPTM.GRD.Application.Contracts.Persistence.Proposicoes.Children;
using CPTM.GRD.Application.Contracts.Persistence.Reunioes;
using CPTM.GRD.Application.Contracts.Persistence.Reunioes.Children;
using CPTM.GRD.Application.Contracts.Persistence.StrictSequenceControl;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.DTOs.Main.Proposicao.Validators;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Application.Features.Proposicoes.Requests.Commands;
using CPTM.GRD.Application.Util;
using CPTM.GRD.Domain.Proposicoes;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Handlers.Commands;

public class UpdateProposicaoRequestHandler : IRequestHandler<UpdateProposicaoRequest, ProposicaoDto>
{
    private readonly IProposicaoRepository _proposicaoRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IGroupRepository _groupRepository;
    private readonly IAuthenticationService _authenticationService;
    private readonly IAcaoRepository _acaoRepository;
    private readonly IVotoRepository _votoRepository;
    private readonly IParticipanteRepository _participanteRepository;
    private readonly IReuniaoRepository _reuniaoRepository;
    private readonly IReuniaoStrictSequenceControl _reuniaoStrictSequence;
    private readonly IProposicaoStrictSequenceControl _proposicaoStrictSequence;

    public UpdateProposicaoRequestHandler(IProposicaoRepository proposicaoRepository, IUserRepository userRepository,
        IMapper mapper, IGroupRepository groupRepository, IAuthenticationService authenticationService,
        IAcaoRepository acaoRepository, IVotoRepository votoRepository, IParticipanteRepository participanteRepository,
        IReuniaoRepository reuniaoRepository, IReuniaoStrictSequenceControl reuniaoStrictSequence,
        IProposicaoStrictSequenceControl proposicaoStrictSequence)
    {
        _proposicaoRepository = proposicaoRepository;
        _userRepository = userRepository;
        _mapper = mapper;
        _groupRepository = groupRepository;
        _authenticationService = authenticationService;
        _acaoRepository = acaoRepository;
        _votoRepository = votoRepository;
        _participanteRepository = participanteRepository;
        _reuniaoRepository = reuniaoRepository;
        _reuniaoStrictSequence = reuniaoStrictSequence;
        _proposicaoStrictSequence = proposicaoStrictSequence;
    }

    public async Task<ProposicaoDto> Handle(UpdateProposicaoRequest request, CancellationToken cancellationToken)
    {
        var proposicaoDtoValidator = new UpdateProposicaoDtoValidator(_groupRepository, _authenticationService,
            _userRepository, _proposicaoRepository, _proposicaoStrictSequence);
        var proposicaoDtoValidationResult =
            await proposicaoDtoValidator.ValidateAsync(request.UpdateProposicaoDto, cancellationToken);

        if (!proposicaoDtoValidationResult.IsValid)
        {
            throw new ValidationException(proposicaoDtoValidationResult);
        }

        var savedProposicao = await _proposicaoRepository.Get(request.UpdateProposicaoDto.Id);
        if (savedProposicao == null)
            throw new NotFoundException(nameof(savedProposicao), request.UpdateProposicaoDto.Id);
        var responsavel = await _userRepository.Get(request.Uid);
        if (responsavel == null) throw new NotFoundException(nameof(responsavel), request.Uid);

        savedProposicao.OnUpdate(responsavel,
            Differentiator.GetDifferenceString<Proposicao>(savedProposicao,
                _mapper.Map<Proposicao>(request.UpdateProposicaoDto)));

        _mapper.Map(request.UpdateProposicaoDto, savedProposicao);
        var updatedProposicao = await _proposicaoRepository.Update(savedProposicao);

        return _mapper.Map<ProposicaoDto>(updatedProposicao);
    }
}