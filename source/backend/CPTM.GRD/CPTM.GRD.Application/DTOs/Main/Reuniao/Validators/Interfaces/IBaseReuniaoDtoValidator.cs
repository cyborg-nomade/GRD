using System.Diagnostics.CodeAnalysis;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Proposicoes;
using CPTM.GRD.Application.Contracts.Persistence.Proposicoes.Children;
using CPTM.GRD.Application.Contracts.Persistence.StrictSequenceControl;
using CPTM.GRD.Application.DTOs.Main.Acao.Validators.Interfaces;
using CPTM.GRD.Application.DTOs.Main.Proposicao.Validators;
using CPTM.GRD.Application.DTOs.Main.Reuniao.Interfaces;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.Main.Reuniao.Validators.Interfaces;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class IBaseReuniaoDtoValidator : AbstractValidator<IBaseReuniaoDto>
{
    public IBaseReuniaoDtoValidator(
        IGroupRepository groupRepository,
        IAuthenticationService authenticationService,
        IUserRepository userRepository,
        IVotoRepository votoRepository,
        IProposicaoRepository proposicaoRepository,
        IProposicaoStrictSequenceControl proposicaoStrictSequence)
    {
        RuleFor(p => p.Data).NotNull().NotEmpty();
        RuleFor(p => p.Horario).NotNull().NotEmpty();
        RuleFor(p => p.DataPrevia).NotNull().NotEmpty();
        RuleFor(p => p.HorarioPrevia).NotNull().NotEmpty();
        RuleFor(p => p.Local).NotNull().NotEmpty();
        RuleFor(p => p.TipoReuniao).NotNull().IsInEnum();
        RuleForEach(p => p.Proposicoes)
            .SetValidator(new ProposicaoDtoValidator(groupRepository, authenticationService, userRepository,
                votoRepository,
                proposicaoRepository, proposicaoStrictSequence));
        RuleForEach(p => p.ProposicoesPrevia)
            .SetValidator(new ProposicaoDtoValidator(groupRepository, authenticationService, userRepository,
                votoRepository,
                proposicaoRepository, proposicaoStrictSequence));
        RuleForEach(p => p.ParticipantesIds).NotNull().NotEmpty().GreaterThan(0).MustAsync(async (id, _) =>
        {
            var userExists = await userRepository.Exists(id);
            return userExists;
        });
        RuleForEach(p => p.ParticipantesPreviaIds).NotNull().NotEmpty().GreaterThan(0).MustAsync(async (id, _) =>
        {
            var userExists = await userRepository.Exists(id);
            return userExists;
        });
        RuleForEach(p => p.Acoes)
            .SetValidator(new IBaseAcaoDtoValidator(groupRepository, authenticationService, userRepository));
    }
}