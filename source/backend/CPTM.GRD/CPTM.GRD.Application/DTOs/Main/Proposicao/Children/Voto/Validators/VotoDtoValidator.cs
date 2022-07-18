using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Proposicoes.Children;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.Main.Proposicao.Children.Voto.Validators;

public class VotoDtoValidator : AbstractValidator<VotoDto>
{
    public VotoDtoValidator(IGroupRepository groupRepository, IAuthenticationService authenticationService,
        IUserRepository userRepository, IVotoRepository votoRepository)
    {
        Include(new IVotoDtoValidator(groupRepository, authenticationService, userRepository));

        RuleFor(p => p.Id).NotNull().NotEmpty().GreaterThan(0).MustAsync(async (id, token) =>
        {
            var votoExists = await votoRepository.Exists(id);
            return !votoExists;
        });
    }
}