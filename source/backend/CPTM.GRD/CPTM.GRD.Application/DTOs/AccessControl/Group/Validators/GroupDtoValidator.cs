using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.AccessControl.Group.Validators;

public class GroupDtoValidator : AbstractValidator<GroupDto>
{
  public GroupDtoValidator(IGroupRepository groupRepository, IAuthenticationService authenticationService,
      IUserRepository userRepository)
  {
    Include(new IGroupDtoValidator(authenticationService, userRepository));

    RuleFor(p => p.Id).NotNull().NotEmpty().GreaterThan(0).MustAsync(async (gid, token) =>
    {
      var groupExists = await groupRepository.Exists(gid);
      return groupExists;
    });
  }
}