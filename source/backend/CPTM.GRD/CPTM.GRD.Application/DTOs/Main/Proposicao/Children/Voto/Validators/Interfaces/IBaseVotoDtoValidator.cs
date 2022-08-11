using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.DTOs.AccessControl.User.Validators;
using CPTM.GRD.Application.DTOs.Main.Proposicao.Children.Voto.Interfaces;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.Main.Proposicao.Children.Voto.Validators.Interfaces;

public class IBaseVotoDtoValidator : AbstractValidator<IBaseVotoDto>
{
    public IBaseVotoDtoValidator(IAuthenticationService authenticationService,
        IUserRepository userRepository)
    {
        RuleFor(p => p.Participante).NotNull().NotEmpty()
            .SetValidator(new UserDtoValidator(authenticationService, userRepository));
        RuleFor(p => p.VotoRd).NotNull().IsInEnum();
    }
}