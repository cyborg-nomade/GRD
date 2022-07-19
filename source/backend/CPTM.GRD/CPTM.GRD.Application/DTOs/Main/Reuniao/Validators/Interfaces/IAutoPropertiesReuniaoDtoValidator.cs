using CPTM.GRD.Application.DTOs.Main.Reuniao.Interfaces;
using CPTM.GRD.Common;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.Main.Reuniao.Validators.Interfaces;

public class IAutoPropertiesReuniaoDtoValidator : AbstractValidator<IAutoPropertiesReuniaoDto>
{
    public IAutoPropertiesReuniaoDtoValidator()
    {
        RuleFor(p => p.Status).NotNull().NotEmpty().IsInEnum();
        RuleFor(p => p.PautaPreviaFilePath).NotNull().NotEmpty().When(p => p.Status >= ReuniaoStatus.Previa);
        RuleFor(p => p.MemoriaPreviaFilePath).NotNull().NotEmpty().When(p => p.Status >= ReuniaoStatus.Pauta);
        RuleFor(p => p.PautaDefinitivaFilePath).NotNull().NotEmpty().When(p => p.Status >= ReuniaoStatus.Pauta);
        RuleFor(p => p.RelatorioDeliberativoFilePath).NotNull().NotEmpty()
            .When(p => p.Status >= ReuniaoStatus.Realizada);
        RuleFor(p => p.AtaFilePath).NotNull().NotEmpty().When(p => p.Status >= ReuniaoStatus.Arquivada);
    }
}