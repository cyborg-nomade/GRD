using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.DTOs.AccessControl.Group.Validators;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.AccessControl.User.Validators;

public class IUserDtoValidator : AbstractValidator<IUserDto>
{
    public IUserDtoValidator(IAuthenticationService authenticationService, IUserRepository userRepository)
    {
        RuleFor(p => p.Nome).NotNull().NotEmpty().MaximumLength(250);
        RuleFor(p => p.NivelAcesso).NotNull().NotEmpty().IsInEnum();
        RuleForEach(p => p.AreasAcesso).NotNull().NotEmpty()
            .SetValidator(new IGroupDtoValidator(authenticationService, userRepository));
        RuleFor(p => p.Funcao).NotNull().NotEmpty();
    }
}