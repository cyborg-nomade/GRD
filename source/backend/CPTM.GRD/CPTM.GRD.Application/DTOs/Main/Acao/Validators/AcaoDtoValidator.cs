using CPTM.GRD.Application.DTOs.Main.Acao.Children.Validators;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.Main.Acao.Validators;

public class AcaoDtoValidator : AbstractValidator<AcaoDto>
{
    public AcaoDtoValidator()
    {
        Include(new IAcaoDtoValidator());

        RuleFor(p => p.Id).NotNull().NotEmpty().GreaterThan(0);
        RuleFor(p => p.Status).NotNull().NotEmpty().IsInEnum();
        RuleFor(p => p.Arquivada).NotNull().NotEmpty();
        RuleFor(p => p.PrazoProrrogadoDias).NotNull().NotEmpty();
        RuleFor(p => p.DiasParaVencimento).NotNull().NotEmpty();
        RuleForEach(p => p.Andamentos).NotNull().NotEmpty().SetValidator(new IAndamentoDtoValidator());
    }
}