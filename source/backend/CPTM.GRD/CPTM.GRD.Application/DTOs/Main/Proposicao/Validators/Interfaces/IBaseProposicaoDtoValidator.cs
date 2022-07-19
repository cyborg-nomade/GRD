using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.DTOs.AccessControl.Group.Validators;
using CPTM.GRD.Application.DTOs.AccessControl.User.Validators;
using CPTM.GRD.Application.DTOs.Main.Proposicao.Interfaces;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.Main.Proposicao.Validators.Interfaces;

public class IBaseProposicaoDtoValidator : AbstractValidator<IBaseProposicaoDto>
{
    public IBaseProposicaoDtoValidator(IGroupRepository groupRepository, IAuthenticationService authenticationService,
        IUserRepository userRepository)
    {
        RuleFor(p => p.Titulo).NotNull().NotEmpty().MaximumLength(250);
        RuleFor(p => p.Objeto).NotNull().NotEmpty().IsInEnum();
        RuleFor(p => p.DescricaoProposicao).NotNull().NotEmpty();
        RuleFor(p => p.PossuiParecerJuridico).NotNull().NotEmpty();
        RuleFor(p => p.ResumoGeralResolucao).NotNull().NotEmpty();
        RuleFor(p => p.ObservacoesCustos).NotNull().NotEmpty();
        RuleFor(p => p.CompetenciasConformeNormas).NotNull().NotEmpty();
        RuleFor(p => p.DataBaseValor).NotNull().NotEmpty();
        RuleFor(p => p.Moeda).NotNull().NotEmpty().MaximumLength(15);
        RuleFor(p => p.ValorOriginalContrato).NotNull().NotEmpty();
        RuleFor(p => p.ValorTotalProposicao).NotNull().NotEmpty();
        RuleFor(p => p.ReceitaDespesa).NotNull().NotEmpty().IsInEnum();

        // TODO: RULES DEPENDING ON OBJETO
        RuleFor(p => p.NumeroContrato).NotNull().NotEmpty().MaximumLength(15);
        RuleFor(p => p.Termo).NotNull().NotEmpty();
        RuleFor(p => p.Fornecedor).NotNull().NotEmpty();
        RuleFor(p => p.ValorAtualContrato).NotNull().NotEmpty();
        RuleFor(p => p.NumeroReservaVerba).NotNull().NotEmpty().MaximumLength(15);
        RuleFor(p => p.ValorReservaVerba).NotNull().NotEmpty();
        RuleFor(p => p.InicioVigenciaReserva).NotNull().NotEmpty().LessThanOrEqualTo(p => p.FimVigenciaReserva);
        RuleFor(p => p.FimVigenciaReserva).NotNull().NotEmpty().GreaterThanOrEqualTo(p => p.InicioVigenciaReserva);
        // END

        RuleFor(p => p.NumeroProposicao).NotNull().NotEmpty().MaximumLength(15);
        RuleFor(p => p.ProtoloExpediente).NotNull().NotEmpty().MaximumLength(15);

        // ALSO DEPENDS ON OBJETO
        RuleFor(p => p.NumeroProcessoLicit).NotNull().NotEmpty().MaximumLength(15);
        RuleFor(p => p.SinteseProcessoFilePath).NotNull().NotEmpty();
        RuleFor(p => p.NotaTecnicaFilePath).NotNull().NotEmpty();
        RuleFor(p => p.PrdFilePath).NotNull().NotEmpty();
        RuleFor(p => p.ParecerJuridicoFilePath).NotNull().NotEmpty();
        RuleFor(p => p.TrFilePath).NotNull().NotEmpty();
        RuleFor(p => p.RelatorioTecnicoFilePath).NotNull().NotEmpty();
        RuleFor(p => p.PlanilhaQuantFilePath).NotNull().NotEmpty();
        RuleFor(p => p.EditalFilePath).NotNull().NotEmpty();
        RuleFor(p => p.ReservaVerbaFilePath).NotNull().NotEmpty();
        RuleFor(p => p.ScFilePath).NotNull().NotEmpty();
        RuleFor(p => p.RavFilePath).NotNull().NotEmpty();
        RuleFor(p => p.CronogramaFisFinFilePath).NotNull().NotEmpty();
        RuleFor(p => p.PcaFilePath).NotNull().NotEmpty();
        RuleForEach(p => p.OutrosFilePath).NotNull().NotEmpty();
        // END
    }
}