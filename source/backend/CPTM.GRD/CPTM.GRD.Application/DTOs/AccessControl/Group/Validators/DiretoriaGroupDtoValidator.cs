using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.AccessControl.Group.Validators;

public class DiretoriaGroupDtoValidator : AbstractValidator<GroupDto>
{
    public DiretoriaGroupDtoValidator(IGroupRepository groupRepository, IAuthenticationService authenticationService,
        IUserRepository userRepository)
    {
        Include(new GroupDtoValidator(groupRepository, authenticationService, userRepository));

        RuleFor(p => p.Sigla).NotNull().NotEmpty().Equal(p => p.SiglaDiretoria);
        RuleFor(p => p.SiglaGerencia).NotNull().Empty();
    }
}