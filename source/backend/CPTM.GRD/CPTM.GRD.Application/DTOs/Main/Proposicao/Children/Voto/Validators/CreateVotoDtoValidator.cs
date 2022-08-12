using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.DTOs.Main.Proposicao.Children.Voto.Validators.Interfaces;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.Main.Proposicao.Children.Voto.Validators;

public class CreateVotoDtoValidator : AbstractValidator<CreateVotoDto>
{
    public CreateVotoDtoValidator(IAuthenticationService authenticationService,
        IUserRepository userRepository)
    {
        Include(new IBaseVotoDtoValidator(userRepository));
    }
}