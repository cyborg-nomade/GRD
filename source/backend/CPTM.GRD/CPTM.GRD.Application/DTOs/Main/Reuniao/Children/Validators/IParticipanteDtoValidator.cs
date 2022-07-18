using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.DTOs.AccessControl.Group.Validators;
using CPTM.GRD.Application.DTOs.AccessControl.User.Validators;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.Main.Reuniao.Children.Validators;

public class IParticipanteDtoValidator : AbstractValidator<IParticipanteDto>
{
    public IParticipanteDtoValidator(IGroupRepository groupRepository, IAuthenticationService authenticationService,
        IUserRepository userRepository)
    {
        RuleFor(p => p.User).NotNull().NotEmpty()
            .SetValidator(new UserDtoValidator(authenticationService, userRepository));
        RuleFor(p => p.DiretoriaArea).NotNull().NotEmpty()
            .SetValidator(new DiretoriaGroupDtoValidator(groupRepository, authenticationService, userRepository));
        RuleFor(p => p.Nome).NotNull().NotEmpty().MaximumLength(50);
        RuleFor(p => p.Email).NotNull().NotEmpty().EmailAddress();
    }
}