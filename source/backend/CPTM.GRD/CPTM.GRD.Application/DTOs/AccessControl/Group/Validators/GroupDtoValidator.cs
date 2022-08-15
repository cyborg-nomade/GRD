using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.AccessControl.Group.Validators;

public class GroupDtoValidator : AbstractValidator<GroupDto>
{
    public GroupDtoValidator(IGroupRepository groupRepository)
    {
        Include(new IGroupDtoValidator());

        RuleFor(p => p.Id).NotNull().NotEmpty().GreaterThan(0).MustAsync(async (gid, _) =>
        {
            var groupExists = await groupRepository.Exists(gid);
            return groupExists;
        });
    }
}