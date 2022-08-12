using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Proposicoes.Children;
using CPTM.GRD.Application.DTOs.Main.Proposicao.Children.Voto.Validators;
using CPTM.GRD.Application.DTOs.Main.Proposicao.Interfaces;
using CPTM.GRD.Common;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.Main.Proposicao.Validators.Interfaces;

public class IAutoPropertiesProposicaoDtoValidator : AbstractValidator<IAutoPropertiesProposicaoDto>
{
    public IAutoPropertiesProposicaoDtoValidator(IUserRepository userRepository,
        IVotoRepository votoRepository)
    {
        RuleFor(p => p.Status).NotNull().IsInEnum();
        RuleFor(p => p.Arquivada).NotNull().NotEmpty();
        RuleFor(p => p.AnotacoesPrevia).NotNull()
            .When(p => p.Status >= ProposicaoStatus.EmPautaDefinitiva);
        RuleForEach(p => p.VotosRd).NotNull()
            .SetValidator(new VotoDtoValidator(userRepository, votoRepository))
            .When(p => p.Status > ProposicaoStatus.EmPautaDefinitiva);
        RuleFor(p => p.MotivoRetornoDiretoriaResp).NotNull().NotEmpty()
            .When(p => p.Status == ProposicaoStatus.ReprovadoDiretoriaResp);
        RuleFor(p => p.MotivoRetornoGrg).NotNull().NotEmpty()
            .When(p => p.Status == ProposicaoStatus.RetornadoPelaGrgADiretoriaResp);
        RuleFor(p => p.MotivoRetornoRd).NotNull().NotEmpty()
            .When(p => p.Status is ProposicaoStatus.AprovadaRdAguardandoAjustes
                or ProposicaoStatus.SuspensaRdAguardandoAjustes);
        RuleFor(p => p.Deliberacao).NotNull().NotEmpty()
            .When(p => p.Status is ProposicaoStatus.AprovadaRd
                or ProposicaoStatus.ReprovadaRd);
        // TODO: Como vai funcionar a resolução?
        //RuleFor(p => p.Resolucao).NotNull().NotEmpty().SetValidator(new ResolucaoDtoValidator())
        //    .When(p => p.Status >= ProposicaoStatus.AprovadaRd);
        RuleFor(p => p.Deliberacao).NotNull().NotEmpty()
            .When(p => p.Status >= ProposicaoStatus.InclusaEmReuniao);
        RuleFor(p => p.ResolucaoDiretoriaFilePath).NotNull().NotEmpty()
            .When(p => p.Status >= ProposicaoStatus.AprovadaRd);
    }
}