using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.DTOs.Main.Acao.Validators.Interfaces;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.Main.Acao.Validators;

public class CreateAcaoDtoValidator : AbstractValidator<CreateAcaoDto>
{
    public CreateAcaoDtoValidator(IGroupRepository groupRepository, IAuthenticationService authenticationService,
        IUserRepository userRepository)
    {
        Include(new IBaseAcaoDtoValidator(groupRepository, authenticationService, userRepository));
    }
}