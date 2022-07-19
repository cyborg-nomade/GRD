using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.DTOs.AccessControl.User.Validators;
using CPTM.GRD.Application.DTOs.Main.Acao.Children.Interfaces;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.Main.Acao.Children.Validators;

public class IAndamentoDtoValidator : AbstractValidator<IAndamentoDto>
{
    public IAndamentoDtoValidator(IAuthenticationService authenticationService, IUserRepository userRepository)
    {
        RuleFor(p => p.User).NotNull().NotEmpty()
            .SetValidator(new UserDtoValidator(authenticationService, userRepository));
        RuleFor(p => p.Status).NotNull().NotEmpty().IsInEnum();
        RuleFor(p => p.Descricao).NotNull().NotEmpty();
    }
}