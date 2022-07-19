using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Acoes;
using CPTM.GRD.Application.Contracts.Persistence.Proposicoes;
using CPTM.GRD.Application.Contracts.Persistence.Proposicoes.Children;
using CPTM.GRD.Application.Contracts.Persistence.Reunioes;
using CPTM.GRD.Application.Contracts.Persistence.Reunioes.Children;
using CPTM.GRD.Application.Contracts.Persistence.StrictSequenceControl;
using CPTM.GRD.Application.DTOs.Main.Acao.Validators;
using CPTM.GRD.Application.DTOs.Main.Acao.Validators.Interfaces;
using CPTM.GRD.Application.DTOs.Main.Proposicao.Validators;
using CPTM.GRD.Application.DTOs.Main.Reuniao.Children.Validators;
using CPTM.GRD.Application.DTOs.Main.Reuniao.Children.Validators.Interfaces;
using CPTM.GRD.Application.DTOs.Main.Reuniao.Interfaces;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.Main.Reuniao.Validators.Interfaces;

public class IBaseReuniaoDtoValidator : AbstractValidator<IBaseReuniaoDto>
{
    public IBaseReuniaoDtoValidator(IGroupRepository groupRepository,
        IAuthenticationService authenticationService,
        IUserRepository userRepository,
        IAcaoRepository acaoRepository,
        IVotoRepository votoRepository,
        IParticipanteRepository participanteRepository,
        IReuniaoRepository reuniaoRepository,
        IReuniaoStrictSequenceControl reuniaoStrictSequence, IProposicaoRepository proposicaoRepository,
        IProposicaoStrictSequenceControl proposicaoStrictSequence)
    {
        RuleFor(p => p.Data).NotNull().NotEmpty();
        RuleFor(p => p.Horario).NotNull().NotEmpty();
        RuleFor(p => p.DataPrevia).NotNull().NotEmpty();
        RuleFor(p => p.HorarioPrevia).NotNull().NotEmpty();
        RuleFor(p => p.Local).NotNull().NotEmpty();
        RuleFor(p => p.TipoReuniao).NotNull().NotEmpty().IsInEnum();
        RuleForEach(p => p.Proposicoes)
            .SetValidator(new ProposicaoDtoValidator(groupRepository, authenticationService, userRepository,
                acaoRepository, votoRepository, participanteRepository, reuniaoRepository, reuniaoStrictSequence,
                proposicaoRepository, proposicaoStrictSequence));
        RuleForEach(p => p.ProposicoesPrevia)
            .SetValidator(new ProposicaoDtoValidator(groupRepository, authenticationService, userRepository,
                acaoRepository, votoRepository, participanteRepository, reuniaoRepository, reuniaoStrictSequence,
                proposicaoRepository, proposicaoStrictSequence));
        RuleFor(p => p.Participantes).NotNull().NotEmpty();
        RuleForEach(p => p.Participantes)
            .SetValidator(new IBaseParticipanteDtoValidator(groupRepository, authenticationService, userRepository));
        RuleForEach(p => p.ParticipantesPrevia)
            .SetValidator(new IBaseParticipanteDtoValidator(groupRepository, authenticationService, userRepository));
        RuleForEach(p => p.Acoes)
            .SetValidator(new IBaseAcaoDtoValidator(groupRepository, authenticationService, userRepository));
    }
}