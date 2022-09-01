using System.Diagnostics.CodeAnalysis;
using CPTM.GRD.Application.Contracts.Persistence.Proposicoes;
using CPTM.GRD.Application.Contracts.Persistence.StrictSequenceControl;
using CPTM.GRD.Application.DTOs.Main.Proposicao.Interfaces;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.Main.Proposicao.Validators.Interfaces;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class IFullProposicaoDtoValidator : AbstractValidator<IFullProposicaoDto>
{
    public IFullProposicaoDtoValidator(IProposicaoRepository proposicaoRepository,
        IProposicaoStrictSequenceControl strictSequence)
    {
        RuleFor(p => p.Id).NotNull().NotEmpty().GreaterThan(0).MustAsync(async (id, _) =>
        {
            var proposicaoExists = await proposicaoRepository.Exists(id);
            return proposicaoExists;
        });
        RuleFor(p => p.IdPrd).NotNull().NotEmpty().GreaterThan(0).MustAsync(async (idprd, _) =>
        {
            var idPrdIsValid = await strictSequence.IsValid(idprd);
            return idPrdIsValid;
        });
    }
}