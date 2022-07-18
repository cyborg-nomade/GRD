using CPTM.GRD.Application.DTOs.AccessControl.User.Validators;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.Main.Acao.Children.Validators;

public class IAndamentoDtoValidator : AbstractValidator<IAndamentoDto>
{
    public IAndamentoDtoValidator()
    {
        RuleFor(p => p.User).NotNull().NotEmpty().SetValidator(new UserDtoValidator());
        RuleFor(p => p.Status).NotNull().NotEmpty().IsInEnum();
        RuleFor(p => p.Descricao).NotNull().NotEmpty();
    }
}