using FluentValidation;

namespace CPTM.GRD.Application.DTOs.AccessControl.Group.Validators;

public class DiretoriaGroupDtoValidator : AbstractValidator<GroupDto>
{
    public DiretoriaGroupDtoValidator()
    {
        Include(new GroupDtoValidator());

        RuleFor(p => p.Sigla).NotNull().NotEmpty().Equal(p => p.SiglaDiretoria);
        RuleFor(p => p.SiglaGerencia).NotNull().Empty();
    }
}