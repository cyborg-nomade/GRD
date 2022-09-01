using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.DTOs.AccessControl.User.Validators.Interfaces;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.AccessControl.User.Validators;

public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
{
    public UpdateUserDtoValidator(IUserRepository userRepository)
    {
        Include(new IBaseUserDtoValidator());
        Include(new IFullUserDtoValidator(userRepository));
    }
}