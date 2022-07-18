using CPTM.GRD.Application.DTOs.AccessControl.Group;
using CPTM.GRD.Application.DTOs.AccessControl.User.Validators;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.AccessControl.Group.Validators;

public class IGroupDtoValidator : AbstractValidator<IGroupDto>
{
    public IGroupDtoValidator()
    {
        RuleFor(p => p.Sigla).NotNull().NotEmpty().MaximumLength(4);
        RuleFor(p => p.Nome).NotNull().NotEmpty().MaximumLength(100);
        RuleFor(p => p.SiglaGerencia).NotNull().NotEmpty().MaximumLength(4);
        RuleFor(p => p.Gerencia).NotNull().NotEmpty().MaximumLength(100);
        RuleFor(p => p.SiglaDiretoria).NotNull().NotEmpty().MaximumLength(4);
        RuleFor(p => p.Diretoria).NotNull().NotEmpty().MaximumLength(100);
        RuleFor(p => p.SiglaDiretoria).NotNull().NotEmpty().MaximumLength(4);
        RuleFor(p => p.Diretoria).NotNull().NotEmpty().MaximumLength(100);
        RuleFor(p => p.Relator).NotNull().NotEmpty().SetValidator(new IUserDtoValidator());
    }
}