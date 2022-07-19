using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Acoes;
using CPTM.GRD.Application.DTOs.Main.Acao.Validators.Interfaces;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.Main.Acao.Validators;

public class UpdateAcaoDtoValidator : AbstractValidator<UpdateAcaoDto>
{
    public UpdateAcaoDtoValidator(IGroupRepository groupRepository, IAuthenticationService authenticationService,
        IUserRepository userRepository, IAcaoRepository acaoRepository)
    {
        Include(new IBaseAcaoDtoValidator(groupRepository, authenticationService, userRepository));
        Include(new IFullAcaoDtoValidator(acaoRepository));
    }
}