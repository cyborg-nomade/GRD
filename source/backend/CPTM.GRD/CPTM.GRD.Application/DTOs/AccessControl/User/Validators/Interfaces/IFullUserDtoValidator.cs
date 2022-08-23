using System.Diagnostics.CodeAnalysis;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.DTOs.AccessControl.User.Interfaces;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.AccessControl.User.Validators.Interfaces;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class IFullUserDtoValidator : AbstractValidator<IFullUserDto>
{
    public IFullUserDtoValidator(IUserRepository userRepository)
    {
        RuleFor(p => p.Id).NotNull().NotEmpty().GreaterThan(0).MustAsync(async (id, _) =>
        {
            var userExists = await userRepository.Exists(id);
            return userExists;
        });
    }
}