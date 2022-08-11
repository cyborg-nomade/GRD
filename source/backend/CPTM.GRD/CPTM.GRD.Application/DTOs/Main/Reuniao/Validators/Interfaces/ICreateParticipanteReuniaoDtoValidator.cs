using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.DTOs.Main.Reuniao.Children.Validators;
using CPTM.GRD.Application.DTOs.Main.Reuniao.Interfaces;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.Main.Reuniao.Validators.Interfaces;

public class ICreateParticipanteReuniaoDtoValidator : AbstractValidator<ICreateParticipanteReuniaoDto>
{
    public ICreateParticipanteReuniaoDtoValidator(IGroupRepository groupRepository,
        IAuthenticationService authenticationService,
        IUserRepository userRepository)
    {
        RuleForEach(p => p.Participantes)
            .SetValidator(new CreateParticipanteDtoValidator(groupRepository, authenticationService, userRepository));
        RuleForEach(p => p.ParticipantesPrevia)
            .SetValidator(new CreateParticipanteDtoValidator(groupRepository, authenticationService, userRepository));
    }
}