using System.Diagnostics.CodeAnalysis;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.DTOs.AccessControl.Group.Validators;
using CPTM.GRD.Application.DTOs.AccessControl.User.Validators;
using CPTM.GRD.Application.DTOs.Main.Proposicao.Interfaces;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.Main.Proposicao.Validators.Interfaces;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class IOwnerPropertiesProposicaoDtoValidator : AbstractValidator<IOwnerPropertiesProposicaoDto>
{
    public IOwnerPropertiesProposicaoDtoValidator(IAuthenticationService authenticationService,
        IUserRepository userRepository, IGroupRepository groupRepository)
    {
        RuleFor(p => p.Criador).NotNull().NotEmpty()
            .SetValidator(new UserDtoValidator(authenticationService, userRepository));
        RuleFor(p => p.Area).NotNull().NotEmpty()
            .SetValidator(new GroupDtoValidator(groupRepository));
    }
}