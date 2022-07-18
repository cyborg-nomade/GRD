using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Acoes;
using CPTM.GRD.Application.Contracts.Persistence.Proposicoes.Children;
using CPTM.GRD.Application.Contracts.Persistence.Reunioes;
using CPTM.GRD.Application.Contracts.Persistence.Reunioes.Children;
using CPTM.GRD.Application.Contracts.Persistence.StrictSequenceControl;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.Main.Reuniao.Validators;

public class ReuniaoDtoValidator : AbstractValidator<ReuniaoDto>
{
    public ReuniaoDtoValidator(IGroupRepository groupRepository, IAuthenticationService authenticationService,
        IUserRepository userRepository, IAcaoRepository acaoRepository, IVotoRepository votoRepository,
        IParticipanteRepository participanteRepository, IReuniaoRepository reuniaoRepository,
        IReuniaoStrictSequenceControl strictSequence)
    {
        Include(new IReuniaoDtoValidator(groupRepository, authenticationService, userRepository, acaoRepository,
            votoRepository, participanteRepository));

        RuleFor(p => p.Id).NotNull().NotEmpty().GreaterThan(0).MustAsync(async (id, token) =>
        {
            var reuniaoExists = await reuniaoRepository.Exists(id);
            return !reuniaoExists;
        });
        RuleFor(p => p.NumeroReuniao).NotNull().NotEmpty().GreaterThan(0).MustAsync(async (nr, token) =>
        {
            var numeroReuniaoIsValid = await strictSequence.IsValid(nr);
            return !numeroReuniaoIsValid;
        });
    }
}