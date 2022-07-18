using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Acoes;
using CPTM.GRD.Application.Contracts.Persistence.Proposicoes.Children;
using CPTM.GRD.Application.Contracts.Persistence.Reunioes.Children;
using CPTM.GRD.Application.DTOs.Main.Proposicao.Children.Voto.Validators;
using CPTM.GRD.Application.DTOs.Main.Reuniao.Validators;
using CPTM.GRD.Common;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.Main.Proposicao.Validators;

public class ProposicaoDtoValidator : AbstractValidator<ProposicaoDto>
{
    public ProposicaoDtoValidator(IGroupRepository groupRepository, IAuthenticationService authenticationService,
        IUserRepository userRepository, IAcaoRepository acaoRepository, IVotoRepository votoRepository,
        IParticipanteRepository participanteRepository)
    {
        Include(new IProposicaoDtoValidator(groupRepository, authenticationService, userRepository));

        RuleFor(p => p.Id).NotNull().NotEmpty().GreaterThan(0);
        RuleFor(p => p.IdPrd).NotNull().NotEmpty().GreaterThan(0);
        RuleFor(p => p.Status).NotNull().NotEmpty().IsInEnum();
        RuleFor(p => p.Arquivada).NotNull().NotEmpty();
        RuleFor(p => p.Reuniao).NotNull().NotEmpty()
            .SetValidator(new IReuniaoDtoValidator(groupRepository, authenticationService, userRepository,
                acaoRepository, votoRepository, participanteRepository))
            .When(p => p.Status >= ProposicaoStatus.InclusaEmReuniao);
        RuleFor(p => p.AnotacoesPrevia).NotNull()
            .When(p => p.Status >= ProposicaoStatus.EmPautaDefinitiva);
        RuleForEach(p => p.VotosRd).NotNull()
            .SetValidator(new VotoDtoValidator(groupRepository, authenticationService, userRepository, votoRepository))
            .When(p => p.Status > ProposicaoStatus.EmPautaDefinitiva);
        RuleFor(p => p.MotivoRetornoDiretoria).NotNull().NotEmpty()
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