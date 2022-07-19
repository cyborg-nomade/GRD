using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Acoes;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.Main.Acao.Validators;

public class UpdateAcaoDtoValidator : AbstractValidator<UpdateAcaoDto>
{
    public UpdateAcaoDtoValidator(IGroupRepository groupRepository, IAuthenticationService authenticationService,
        IUserRepository userRepository, IAcaoRepository acaoRepository)
    {
        Include(new IAcaoDtoValidator(groupRepository, authenticationService, userRepository));

        RuleFor(p => p.Id).NotNull().NotEmpty().GreaterThan(0).MustAsync(async (id, token) =>
        {
            var acaoExists = await acaoRepository.Exists(id);
            return !acaoExists;
        });
        RuleFor(p => p.PrazoProrrogadoDias).NotNull().NotEmpty();
    }
}