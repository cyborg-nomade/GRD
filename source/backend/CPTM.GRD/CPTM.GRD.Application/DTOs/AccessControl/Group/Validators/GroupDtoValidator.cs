using FluentValidation;

namespace CPTM.GRD.Application.DTOs.AccessControl.Group.Validators;

public class GroupDtoValidator : AbstractValidator<GroupDto>
{
    public GroupDtoValidator()
    {
        Include(new IGroupDtoValidator());

        RuleFor(p => p.Id).NotNull().NotEmpty().GreaterThan(0);
    }
}