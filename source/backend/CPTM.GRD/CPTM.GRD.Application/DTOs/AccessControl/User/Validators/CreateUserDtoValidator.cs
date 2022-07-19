using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.AccessControl.User.Validators;

public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
{
    public CreateUserDtoValidator(IAuthenticationService authenticationService, IUserRepository userRepository)
    {
        Include(new IUserDtoValidator(authenticationService, userRepository));

        RuleFor(p => p.UsernameAd).NotNull().NotEmpty().MaximumLength(50).MustAsync(async (username, token) =>
        {
            var usernameExists = await authenticationService.ExistsAd(username);
            return !usernameExists;
        });
    }
}