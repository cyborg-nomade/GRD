using CPTM.GRD.Application.DTOs.Main.Reuniao.Children.Validators;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.Main.Proposicao.Children.Voto.Validators;

public class IVotoDtoValidator : AbstractValidator<IVotoDto>
{
    public IVotoDtoValidator()
    {
        RuleFor(p => p.Participante).NotNull().NotEmpty().SetValidator(new IParticipanteDtoValidator());
        RuleFor(p => p.VotoRd).NotNull().NotEmpty().IsInEnum();
    }
}