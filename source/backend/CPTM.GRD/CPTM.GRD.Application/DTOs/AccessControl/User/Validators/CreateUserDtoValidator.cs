using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.DTOs.AccessControl.User.Validators.Interfaces;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.AccessControl.User.Validators;

public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
{
    public CreateUserDtoValidator(IAuthenticationService authenticationService)
    {
        Include(new IUsernameAdUserDtoValidator(authenticationService));
    }
}