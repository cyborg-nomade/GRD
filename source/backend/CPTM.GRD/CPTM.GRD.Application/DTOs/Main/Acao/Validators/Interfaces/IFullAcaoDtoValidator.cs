using CPTM.GRD.Application.Contracts.Persistence.Acoes;
using CPTM.GRD.Application.DTOs.Main.Acao.Interfaces;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.Main.Acao.Validators.Interfaces;

public class IFullAcaoDtoValidator : AbstractValidator<IFullAcaoDto>
{
    public IFullAcaoDtoValidator(IAcaoRepository acaoRepository)
    {
        RuleFor(p => p.Id).NotNull().NotEmpty().GreaterThan(0).MustAsync(async (id, token) =>
        {
            var acaoExists = await acaoRepository.Exists(id);
            return !acaoExists;
        });
        RuleFor(p => p.PrazoProrrogadoDias).NotNull().NotEmpty();
    }
}