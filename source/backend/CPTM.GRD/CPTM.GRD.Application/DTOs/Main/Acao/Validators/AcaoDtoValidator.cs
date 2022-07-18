using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Acoes;
using CPTM.GRD.Application.DTOs.Main.Acao.Children.Validators;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.Main.Acao.Validators;

public class AcaoDtoValidator : AbstractValidator<AcaoDto>
{
    public AcaoDtoValidator(IGroupRepository groupRepository, IAuthenticationService authenticationService,
        IUserRepository userRepository, IAcaoRepository acaoRepository)
    {
        Include(new IAcaoDtoValidator(groupRepository, authenticationService, userRepository));

        RuleFor(p => p.Id).NotNull().NotEmpty().GreaterThan(0).MustAsync(async (id, token) =>
        {
            var acaoExists = await acaoRepository.Exists(id);
            return !acaoExists;
        });
        RuleFor(p => p.Status).NotNull().NotEmpty().IsInEnum();
        RuleFor(p => p.Arquivada).NotNull().NotEmpty();
        RuleFor(p => p.PrazoProrrogadoDias).NotNull().NotEmpty();
        RuleFor(p => p.DiasParaVencimento).NotNull().NotEmpty();
        RuleForEach(p => p.Andamentos).NotNull().NotEmpty()
            .SetValidator(new IAndamentoDtoValidator(authenticationService, userRepository));
    }
}