using FluentValidation;

namespace CPTM.GRD.Application.DTOs.AccessControl.User.Validators;

public class UserDtoValidator : AbstractValidator<UserDto>
{
    public UserDtoValidator()
    {
        Include(new IUserDtoValidator());

        RuleFor(p => p.Id).NotNull().NotEmpty().GreaterThan(0);
    }
}