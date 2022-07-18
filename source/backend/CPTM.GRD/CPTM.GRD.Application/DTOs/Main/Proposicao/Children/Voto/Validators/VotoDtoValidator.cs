using FluentValidation;

namespace CPTM.GRD.Application.DTOs.Main.Proposicao.Children.Voto.Validators;

public class VotoDtoValidator : AbstractValidator<VotoDto>
{
    public VotoDtoValidator()
    {
        Include(new IVotoDtoValidator());

        RuleFor(p => p.Id).NotNull().NotEmpty().GreaterThan(0);
    }
}