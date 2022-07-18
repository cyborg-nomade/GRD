using CPTM.GRD.Application.DTOs.AccessControl.Group.Validators;
using CPTM.GRD.Application.DTOs.AccessControl.User.Validators;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.Main.Reuniao.Children.Validators;

public class IParticipanteDtoValidator : AbstractValidator<IParticipanteDto>
{
    public IParticipanteDtoValidator()
    {
        RuleFor(p => p.User).NotNull().NotEmpty().SetValidator(new UserDtoValidator());
        RuleFor(p => p.DiretoriaArea).NotNull().NotEmpty().SetValidator(new DiretoriaGroupDtoValidator());
        RuleFor(p => p.Nome).NotNull().NotEmpty().MaximumLength(50);
        RuleFor(p => p.Email).NotNull().NotEmpty().EmailAddress();
    }
}