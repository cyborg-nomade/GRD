using FluentValidation;

namespace CPTM.GRD.Application.DTOs.Main.Reuniao.Children.Validators;

public class ParticipanteDtoValidator : AbstractValidator<ParticipanteDto>
{
    public ParticipanteDtoValidator()
    {
        Include(new IParticipanteDtoValidator());

        RuleFor(p => p.Id).NotNull().NotEmpty().GreaterThan(0);
    }
}