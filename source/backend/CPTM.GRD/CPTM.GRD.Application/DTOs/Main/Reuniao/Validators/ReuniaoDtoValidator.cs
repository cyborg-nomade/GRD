﻿using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Proposicoes;
using CPTM.GRD.Application.Contracts.Persistence.Proposicoes.Children;
using CPTM.GRD.Application.Contracts.Persistence.Reunioes;
using CPTM.GRD.Application.Contracts.Persistence.StrictSequenceControl;
using CPTM.GRD.Application.DTOs.Main.Reuniao.Validators.Interfaces;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.Main.Reuniao.Validators;

public class ReuniaoDtoValidator : AbstractValidator<ReuniaoDto>
{
    public ReuniaoDtoValidator(IGroupRepository groupRepository, IAuthenticationService authenticationService,
        IUserRepository userRepository, IVotoRepository votoRepository, IReuniaoRepository reuniaoRepository,
        IReuniaoStrictSequenceControl reuniaoStrictSequence, IProposicaoRepository proposicaoRepository,
        IProposicaoStrictSequenceControl proposicaoStrictSequence)
    {
        Include(new IBaseReuniaoDtoValidator(groupRepository, authenticationService, userRepository,
            votoRepository, proposicaoRepository,
            proposicaoStrictSequence));

        Include(new IFullReuniaoDtoValidator(reuniaoRepository, reuniaoStrictSequence));
        Include(new IAutoPropertiesReuniaoDtoValidator());
    }
}