using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Proposicoes.Children;
using CPTM.GRD.Application.DTOs.Main.Proposicao.Children.Voto.Validators.Interfaces;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.Main.Proposicao.Children.Voto.Validators;

public class VotoDtoValidator : AbstractValidator<VotoDto>
{
    public VotoDtoValidator(IUserRepository userRepository, IVotoRepository votoRepository)
    {
        Include(new IBaseVotoDtoValidator(userRepository));
        Include(new IFullVotoDtoValidator(votoRepository));
    }
}