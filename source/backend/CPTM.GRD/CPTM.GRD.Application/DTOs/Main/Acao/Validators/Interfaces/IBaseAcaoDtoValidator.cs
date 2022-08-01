using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.DTOs.AccessControl.Group.Validators;
using CPTM.GRD.Application.DTOs.AccessControl.User.Validators;
using CPTM.GRD.Application.DTOs.Main.Acao.Interfaces;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.Main.Acao.Validators.Interfaces;

public class IBaseAcaoDtoValidator : AbstractValidator<IBaseAcaoDto>
{
  public IBaseAcaoDtoValidator(IGroupRepository groupRepository, IAuthenticationService authenticationService,
      IUserRepository userRepository)
  {
    RuleFor(p => p.Tipo).NotNull().IsInEnum();
    RuleFor(p => p.DiretoriaRes).NotNull().NotEmpty()
        .SetValidator(new GroupDtoValidator(groupRepository, authenticationService, userRepository));
    RuleFor(p => p.Definicao).NotNull().NotEmpty();
    RuleFor(p => p.Periodicidade).NotNull().IsInEnum();
    RuleFor(p => p.PrazoInicial).NotNull().NotEmpty().LessThanOrEqualTo(p => p.PrazoFinal)
        .GreaterThanOrEqualTo(DateTime.Now);
    RuleFor(p => p.Responsavel).NotNull().NotEmpty()
        .SetValidator(new UserDtoValidator(authenticationService, userRepository));
    RuleFor(p => p.EmailDiretor).NotNull().NotEmpty().EmailAddress();
    RuleFor(p => p.PrazoFinal).NotNull().NotEmpty().GreaterThanOrEqualTo(p => p.PrazoInicial)
        .GreaterThanOrEqualTo(DateTime.Now);
    RuleFor(p => p.AlertaVencimento).NotNull().IsInEnum();
  }
}