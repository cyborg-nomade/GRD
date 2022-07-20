using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Acoes;
using CPTM.GRD.Application.Contracts.Persistence.Proposicoes;
using CPTM.GRD.Application.Contracts.Persistence.Proposicoes.Children;
using CPTM.GRD.Application.Contracts.Persistence.Reunioes;
using CPTM.GRD.Application.Contracts.Persistence.Reunioes.Children;
using CPTM.GRD.Application.Contracts.Persistence.StrictSequenceControl;
using CPTM.GRD.Application.DTOs.Main.Proposicao.Validators.Interfaces;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.Main.Proposicao.Validators;

public class ProposicaoDtoValidator : AbstractValidator<ProposicaoDto>
{
    public ProposicaoDtoValidator(IGroupRepository groupRepository, IAuthenticationService authenticationService,
        IUserRepository userRepository, IAcaoRepository acaoRepository, IVotoRepository votoRepository,
        IParticipanteRepository participanteRepository, IReuniaoRepository reuniaoRepository,
        IReuniaoStrictSequenceControl reuniaoStrictSequence, IProposicaoRepository proposicaoRepository,
        IProposicaoStrictSequenceControl proposicaoStrictSequence)
    {
        Include(new IBaseProposicaoDtoValidator(groupRepository, authenticationService, userRepository));
        Include(new IFullProposicaoDtoValidator(proposicaoRepository, proposicaoStrictSequence));
        Include(new IOwnerPropertiesProposicaoDtoValidator(authenticationService, userRepository, groupRepository));
        Include(new IAutoPropertiesProposicaoDtoValidator(groupRepository, authenticationService, userRepository,
            acaoRepository, votoRepository, participanteRepository, reuniaoRepository, reuniaoStrictSequence,
            proposicaoRepository, proposicaoStrictSequence));
    }
}