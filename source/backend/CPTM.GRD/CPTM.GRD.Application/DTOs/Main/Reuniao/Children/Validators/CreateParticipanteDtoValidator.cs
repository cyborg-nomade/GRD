using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.DTOs.Main.Reuniao.Children.Validators.Interfaces;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.Main.Reuniao.Children.Validators;

public class CreateParticipanteDtoValidator : AbstractValidator<CreateParticipanteDto>
{
    public CreateParticipanteDtoValidator(IGroupRepository groupRepository,
        IAuthenticationService authenticationService, IUserRepository userRepository)
    {
        Include(new IBaseParticipanteDtoValidator(groupRepository, authenticationService, userRepository));
    }
}