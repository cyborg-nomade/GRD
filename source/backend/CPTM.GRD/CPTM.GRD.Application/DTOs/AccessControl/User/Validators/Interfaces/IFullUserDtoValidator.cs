using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.DTOs.AccessControl.User.Interfaces;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.AccessControl.User.Validators.Interfaces;

public class IFullUserDtoValidator : AbstractValidator<IFullUserDto>
{
  public IFullUserDtoValidator(IUserRepository userRepository)
  {
    RuleFor(p => p.Id).NotNull().NotEmpty().GreaterThan(0).MustAsync(async (id, token) =>
    {
      var userExists = await userRepository.Exists(id);
      return userExists;
    });
  }
}