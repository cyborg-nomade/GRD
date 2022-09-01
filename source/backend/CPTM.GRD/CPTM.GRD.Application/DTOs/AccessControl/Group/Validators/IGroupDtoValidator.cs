using System.Diagnostics.CodeAnalysis;
using CPTM.GRD.Application.DTOs.AccessControl.Group.Interfaces;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.AccessControl.Group.Validators;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class IGroupDtoValidator : AbstractValidator<IGroupDto>
{
    public IGroupDtoValidator()
    {
        RuleFor(p => p.Sigla).NotNull().NotEmpty().MaximumLength(4);
        RuleFor(p => p.Nome).NotNull().NotEmpty().MaximumLength(100);
        RuleFor(p => p.SiglaGerencia).NotNull().MaximumLength(4);
        RuleFor(p => p.Gerencia).NotNull().MaximumLength(100);
        RuleFor(p => p.SiglaDiretoria).NotNull().NotEmpty().MaximumLength(4);
        RuleFor(p => p.Diretoria).NotNull().NotEmpty().MaximumLength(100);
        RuleFor(p => p.SiglaDiretoria).NotNull().NotEmpty().MaximumLength(4);
        RuleFor(p => p.Diretoria).NotNull().NotEmpty().MaximumLength(100);
        //RuleFor(p => p.Relator).NotNull().NotEmpty()
        //    .SetValidator(new UserDtoValidator(authenticationService, userRepository));
    }
}