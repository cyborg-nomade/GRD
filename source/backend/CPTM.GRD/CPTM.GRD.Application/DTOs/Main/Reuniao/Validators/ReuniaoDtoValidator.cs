﻿using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Acoes;
using CPTM.GRD.Application.Contracts.Persistence.Proposicoes;
using CPTM.GRD.Application.Contracts.Persistence.Proposicoes.Children;
using CPTM.GRD.Application.Contracts.Persistence.Reunioes;
using CPTM.GRD.Application.Contracts.Persistence.Reunioes.Children;
using CPTM.GRD.Application.Contracts.Persistence.StrictSequenceControl;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.Main.Reuniao.Validators;

public class ReuniaoDtoValidator : AbstractValidator<ReuniaoDto>
{
    public ReuniaoDtoValidator(IGroupRepository groupRepository, IAuthenticationService authenticationService,
        IUserRepository userRepository, IAcaoRepository acaoRepository, IVotoRepository votoRepository,
        IParticipanteRepository participanteRepository, IReuniaoRepository reuniaoRepository,
        IReuniaoStrictSequenceControl reuniaoStrictSequence, IProposicaoRepository proposicaoRepository,
        IProposicaoStrictSequenceControl proposicaoStrictSequence)
    {
        Include(new IReuniaoDtoValidator(groupRepository, authenticationService, userRepository, acaoRepository,
            votoRepository, participanteRepository, reuniaoRepository, reuniaoStrictSequence, proposicaoRepository,
            proposicaoStrictSequence));

        RuleFor(p => p.Id).NotNull().NotEmpty().GreaterThan(0).MustAsync(async (id, token) =>
        {
            var reuniaoExists = await reuniaoRepository.Exists(id);
            return !reuniaoExists;
        });
        RuleFor(p => p.NumeroReuniao).NotNull().NotEmpty().GreaterThan(0).MustAsync(async (nr, token) =>
        {
            var numeroReuniaoIsValid = await reuniaoStrictSequence.IsValid(nr);
            return !numeroReuniaoIsValid;
        });
    }
}