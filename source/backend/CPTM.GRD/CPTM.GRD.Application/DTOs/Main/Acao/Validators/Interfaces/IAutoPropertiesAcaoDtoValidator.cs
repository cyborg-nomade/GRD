using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.DTOs.Main.Acao.Children.Validators;
using CPTM.GRD.Application.DTOs.Main.Acao.Interfaces;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.Main.Acao.Validators.Interfaces;

public class IAutoPropertiesAcaoDtoValidator : AbstractValidator<IAutoPropertiesAcaoDto>
{
  public IAutoPropertiesAcaoDtoValidator(IAuthenticationService authenticationService,
      IUserRepository userRepository)
  {
    RuleFor(p => p.Status).NotNull().IsInEnum();
    RuleFor(p => p.Arquivada).NotNull().NotEmpty();
    RuleFor(p => p.DiasParaVencimento).NotNull().NotEmpty();
    RuleForEach(p => p.Andamentos).NotNull().NotEmpty()
        .SetValidator(new IAndamentoDtoValidator(authenticationService, userRepository));
  }
}