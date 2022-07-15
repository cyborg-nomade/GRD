using FluentValidation;

namespace CPTM.GRD.Application.DTOs.Main.Proposicao.Validators;

public class CreateProposicaoDtoValidator : AbstractValidator<CreateProposicaoDto>
{
    public CreateProposicaoDtoValidator()
    {
        RuleFor(p => p.Titulo)
            .NotEmpty().WithMessage("{PropertyName} é uma propriedade obrigatória")
            .NotNull().WithMessage("{PropertyName} é uma propriedade obrigatória");
    }
}