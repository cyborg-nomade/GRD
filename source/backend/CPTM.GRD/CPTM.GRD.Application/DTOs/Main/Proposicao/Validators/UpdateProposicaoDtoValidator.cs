using CPTM.GRD.Application.Contracts.Persistence.Proposicoes;
using CPTM.GRD.Application.Contracts.Persistence.StrictSequenceControl;
using CPTM.GRD.Application.DTOs.Main.Proposicao.Validators.Interfaces;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.Main.Proposicao.Validators;

public class UpdateProposicaoDtoValidator : AbstractValidator<UpdateProposicaoDto>
{
    public UpdateProposicaoDtoValidator(IProposicaoRepository proposicaoRepository,
        IProposicaoStrictSequenceControl strictSequence)
    {
        Include(new IBaseProposicaoDtoValidator());
        Include(new IFullProposicaoDtoValidator(proposicaoRepository, strictSequence));
    }
}