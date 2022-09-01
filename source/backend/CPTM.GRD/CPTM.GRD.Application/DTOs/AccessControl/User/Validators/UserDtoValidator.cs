using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.DTOs.AccessControl.User.Validators.Interfaces;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.AccessControl.User.Validators;

public class UserDtoValidator : AbstractValidator<UserDto>
{
    public UserDtoValidator(IAuthenticationService authenticationService, IUserRepository userRepository)
    {
        Include(new IBaseUserDtoValidator());
        Include(new IUsernameAdUserDtoValidator(authenticationService));
        Include(new IFullUserDtoValidator(userRepository));
    }
}