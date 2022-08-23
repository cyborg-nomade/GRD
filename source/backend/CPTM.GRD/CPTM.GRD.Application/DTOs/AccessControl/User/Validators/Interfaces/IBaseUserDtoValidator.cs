using System.Diagnostics.CodeAnalysis;
using CPTM.GRD.Application.DTOs.AccessControl.Group.Validators;
using CPTM.GRD.Application.DTOs.AccessControl.User.Interfaces;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.AccessControl.User.Validators.Interfaces;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class IBaseUserDtoValidator : AbstractValidator<IBaseUserDto>
{
    public IBaseUserDtoValidator()
    {
        RuleFor(p => p.Nome).NotNull().NotEmpty().MaximumLength(250);
        RuleFor(p => p.NivelAcesso).NotNull().IsInEnum();
        RuleForEach(p => p.AreasAcesso).NotNull().NotEmpty()
            .SetValidator(new IGroupDtoValidator());
        RuleFor(p => p.Funcao).NotNull().NotEmpty();
        RuleFor(p => p.Email).NotNull().NotEmpty().EmailAddress();
    }
}