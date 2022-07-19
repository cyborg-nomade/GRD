using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Proposicoes;
using CPTM.GRD.Application.Contracts.Persistence.StrictSequenceControl;
using CPTM.GRD.Application.DTOs.Main.Proposicao.Validators.Interfaces;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.Main.Proposicao.Validators;

public class UpdateProposicaoDtoValidator : AbstractValidator<UpdateProposicaoDto>
{
    public UpdateProposicaoDtoValidator(IGroupRepository groupRepository, IAuthenticationService authenticationService,
        IUserRepository userRepository, IProposicaoRepository proposicaoRepository,
        IProposicaoStrictSequenceControl strictSequence)
    {
        Include(new IBaseProposicaoDtoValidator(groupRepository, authenticationService, userRepository));
        Include(new IFullProposicaoDtoValidator(proposicaoRepository, strictSequence));
    }
}