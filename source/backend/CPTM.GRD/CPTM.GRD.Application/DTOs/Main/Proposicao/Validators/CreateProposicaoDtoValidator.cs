using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.DTOs.Main.Proposicao.Validators.Interfaces;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.Main.Proposicao.Validators;

public class CreateProposicaoDtoValidator : AbstractValidator<CreateProposicaoDto>
{
    public CreateProposicaoDtoValidator(IGroupRepository groupRepository, IAuthenticationService authenticationService,
        IUserRepository userRepository)
    {
        Include(new IBaseProposicaoDtoValidator(groupRepository, authenticationService, userRepository));
        Include(new IOwnerPropertiesProposicaoDtoValidator(authenticationService, userRepository, groupRepository));
    }
}