using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Reunioes.Children;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.Main.Reuniao.Children.Validators;

public class ParticipanteDtoValidator : AbstractValidator<ParticipanteDto>
{
    public ParticipanteDtoValidator(IGroupRepository groupRepository, IAuthenticationService authenticationService,
        IUserRepository userRepository, IParticipanteRepository participanteRepository)
    {
        Include(new IParticipanteDtoValidator(groupRepository, authenticationService, userRepository));

        RuleFor(p => p.Id).NotNull().NotEmpty().GreaterThan(0).MustAsync(async (id, token) =>
        {
            var participanteExists = await participanteRepository.Exists(id);
            return !participanteExists;
        });
    }
}