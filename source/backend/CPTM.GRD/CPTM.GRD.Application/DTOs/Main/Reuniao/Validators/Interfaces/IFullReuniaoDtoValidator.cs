using CPTM.GRD.Application.Contracts.Persistence.Reunioes;
using CPTM.GRD.Application.Contracts.Persistence.StrictSequenceControl;
using CPTM.GRD.Application.DTOs.Main.Reuniao.Interfaces;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.Main.Reuniao.Validators.Interfaces;

public class IFullReuniaoDtoValidator : AbstractValidator<IFullReuniaoDto>
{
    public IFullReuniaoDtoValidator(IReuniaoRepository reuniaoRepository,
        IReuniaoStrictSequenceControl reuniaoStrictSequence)
    {
        RuleFor(p => p.Id).NotNull().NotEmpty().GreaterThan(0).MustAsync(async (id, token) =>
        {
            var reuniaoExists = await reuniaoRepository.Exists(id);
            return !reuniaoExists;
        });
        RuleFor(p => p.NumeroReuniao).NotNull().NotEmpty().GreaterThan(0).MustAsync(async (nr, token) =>
        {
            var numeroReuniaoIsValid = await reuniaoStrictSequence.IsValid(nr);
            return !numeroReuniaoIsValid;
        });
    }
}