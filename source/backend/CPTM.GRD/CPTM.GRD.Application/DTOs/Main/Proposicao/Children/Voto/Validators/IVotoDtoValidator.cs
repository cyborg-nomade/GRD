using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.DTOs.Main.Reuniao.Children.Validators;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.Main.Proposicao.Children.Voto.Validators;

public class IVotoDtoValidator : AbstractValidator<IVotoDto>
{
    public IVotoDtoValidator(IGroupRepository groupRepository, IAuthenticationService authenticationService,
        IUserRepository userRepository)
    {
        RuleFor(p => p.Participante).NotNull().NotEmpty()
            .SetValidator(new IParticipanteDtoValidator(groupRepository, authenticationService, userRepository));
        RuleFor(p => p.VotoRd).NotNull().NotEmpty().IsInEnum();
    }
}