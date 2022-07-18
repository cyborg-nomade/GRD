using CPTM.GRD.Application.DTOs.AccessControl.Group.Validators;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.AccessControl.User.Validators;

public class IUserDtoValidator : AbstractValidator<IUserDto>
{
    public IUserDtoValidator()
    {
        RuleFor(p => p.Nome).NotNull().NotEmpty().MaximumLength(250);
        RuleFor(p => p.UsernameAd).NotNull().NotEmpty().MaximumLength(50);
        RuleFor(p => p.NivelAcesso).NotNull().NotEmpty().IsInEnum();
        RuleForEach(p => p.AreasAcesso).NotEmpty().SetValidator(new IGroupDtoValidator());
        RuleFor(p => p.Funcao).NotNull().NotEmpty();
    }
}