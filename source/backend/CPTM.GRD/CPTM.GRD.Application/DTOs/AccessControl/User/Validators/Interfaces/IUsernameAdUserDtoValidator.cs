using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.DTOs.AccessControl.User.Interfaces;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.AccessControl.User.Validators.Interfaces;

public class IUsernameAdUserDtoValidator : AbstractValidator<IUsernameAdUserDto>
{
    public IUsernameAdUserDtoValidator(IAuthenticationService authenticationService)
    {
        RuleFor(p => p.UsernameAd).NotNull().NotEmpty().MaximumLength(50).MustAsync(async (username, token) =>
        {
            var usernameExists = await authenticationService.ExistsAd(username);
            return usernameExists;
        });
    }
}