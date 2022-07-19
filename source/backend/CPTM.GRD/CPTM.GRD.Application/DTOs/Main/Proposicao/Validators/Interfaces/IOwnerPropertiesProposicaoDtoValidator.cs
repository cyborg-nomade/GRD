using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.DTOs.AccessControl.Group.Validators;
using CPTM.GRD.Application.DTOs.AccessControl.User.Validators;
using CPTM.GRD.Application.DTOs.Main.Proposicao.Interfaces;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.Main.Proposicao.Validators.Interfaces;

public class IOwnerPropertiesProposicaoDtoValidator : AbstractValidator<IOwnerPropertiesProposicaoDto>
{
    public IOwnerPropertiesProposicaoDtoValidator(IAuthenticationService authenticationService,
        IUserRepository userRepository, IGroupRepository groupRepository)
    {
        RuleFor(p => p.Criador).NotNull().NotEmpty()
            .SetValidator(new UserDtoValidator(authenticationService, userRepository));
        RuleFor(p => p.AreaSolicitante).NotNull().NotEmpty()
            .SetValidator(new GroupDtoValidator(groupRepository, authenticationService, userRepository));
    }
}