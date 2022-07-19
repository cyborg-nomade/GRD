using CPTM.GRD.Application.Contracts.Persistence.Reunioes.Children;
using CPTM.GRD.Application.DTOs.Main.Reuniao.Children.Interfaces;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.Main.Reuniao.Children.Validators.Interfaces;

public class IFullParticipanteDtoValidator : AbstractValidator<IFullParticipanteDto>
{
    public IFullParticipanteDtoValidator(IParticipanteRepository participanteRepository)
    {
        RuleFor(p => p.Id).NotNull().NotEmpty().GreaterThan(0).MustAsync(async (id, token) =>
        {
            var participanteExists = await participanteRepository.Exists(id);
            return !participanteExists;
        });
    }
}