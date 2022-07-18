using FluentValidation;

namespace CPTM.GRD.Application.DTOs.Main.Reuniao.Validators;

public class ReuniaoDtoValidator : AbstractValidator<ReuniaoDto>
{
    public ReuniaoDtoValidator()
    {
        Include(new IReuniaoDtoValidator());

        RuleFor(p => p.Id).NotNull().NotEmpty().GreaterThan(0);
        RuleFor(p => p.NumeroReuniao).NotNull().NotEmpty().GreaterThan(0);
    }
}