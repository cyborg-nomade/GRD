using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Reunioes.Children;
using CPTM.GRD.Application.DTOs.Main.Reuniao.Children.Validators;
using CPTM.GRD.Application.DTOs.Main.Reuniao.Interfaces;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.Main.Reuniao.Validators.Interfaces;

public class IParticipanteReuniaoDtoValidator : AbstractValidator<IParticipanteReuniaoDto>
{
    public IParticipanteReuniaoDtoValidator(IGroupRepository groupRepository,
        IAuthenticationService authenticationService,
        IUserRepository userRepository, IParticipanteRepository participanteRepository)
    {
        RuleForEach(p => p.Participantes)
            .SetValidator(new ParticipanteDtoValidator(groupRepository, authenticationService, userRepository,
                participanteRepository));
        RuleForEach(p => p.ParticipantesPrevia)
            .SetValidator(new ParticipanteDtoValidator(groupRepository, authenticationService, userRepository,
                participanteRepository));
    }
}