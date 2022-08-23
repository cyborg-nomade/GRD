using System.Diagnostics.CodeAnalysis;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.DTOs.Main.Proposicao.Children.Voto.Interfaces;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.Main.Proposicao.Children.Voto.Validators.Interfaces;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class IBaseVotoDtoValidator : AbstractValidator<IBaseVotoDto>
{
    public IBaseVotoDtoValidator(IUserRepository userRepository)
    {
        RuleFor(p => p.ParticipanteId).NotNull().NotEmpty().GreaterThan(0).MustAsync(async (id, _) =>
        {
            var userExists = await userRepository.Exists(id);
            return userExists;
        });
        RuleFor(p => p.VotoRd).NotNull().IsInEnum();
    }
}