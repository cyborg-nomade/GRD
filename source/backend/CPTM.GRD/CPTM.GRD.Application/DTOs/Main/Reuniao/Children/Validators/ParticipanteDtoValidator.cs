using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Reunioes.Children;
using CPTM.GRD.Application.DTOs.Main.Reuniao.Children.Validators.Interfaces;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.Main.Reuniao.Children.Validators;

public class ParticipanteDtoValidator : AbstractValidator<ParticipanteDto>
{
    public ParticipanteDtoValidator(IGroupRepository groupRepository, IAuthenticationService authenticationService,
        IUserRepository userRepository, IParticipanteRepository participanteRepository)
    {
        Include(new IBaseParticipanteDtoValidator(groupRepository, authenticationService, userRepository));
        Include(new IFullParticipanteDtoValidator(participanteRepository));
    }
}