using CPTM.GRD.Application.Contracts.Persistence.Proposicoes.Children;
using CPTM.GRD.Application.DTOs.Main.Proposicao.Children.Voto.Interfaces;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.Main.Proposicao.Children.Voto.Validators.Interfaces;

public class IFullVotoDtoValidator : AbstractValidator<IFullVotoDto>
{
    public IFullVotoDtoValidator(IVotoRepository votoRepository)
    {
        RuleFor(p => p.Id).NotNull().NotEmpty().GreaterThan(0).MustAsync(async (id, token) =>
        {
            var votoExists = await votoRepository.Exists(id);
            return !votoExists;
        });
    }
}