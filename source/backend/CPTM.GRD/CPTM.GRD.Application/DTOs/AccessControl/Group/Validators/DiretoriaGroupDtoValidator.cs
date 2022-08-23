using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.AccessControl.Group.Validators;

public class DiretoriaGroupDtoValidator : AbstractValidator<GroupDto>
{
    public DiretoriaGroupDtoValidator(IGroupRepository groupRepository)
    {
        Include(new GroupDtoValidator(groupRepository));

        RuleFor(p => p.Sigla).NotNull().NotEmpty().Equal(p => p.SiglaDiretoria);
        RuleFor(p => p.SiglaGerencia).NotNull().Empty();
    }
}