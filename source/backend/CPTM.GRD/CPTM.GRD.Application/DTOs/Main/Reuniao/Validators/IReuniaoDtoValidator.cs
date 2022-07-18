using CPTM.GRD.Application.DTOs.Main.Acao.Validators;
using CPTM.GRD.Application.DTOs.Main.Proposicao.Validators;
using CPTM.GRD.Application.DTOs.Main.Reuniao.Children.Validators;
using FluentValidation;

namespace CPTM.GRD.Application.DTOs.Main.Reuniao.Validators;

public class IReuniaoDtoValidator : AbstractValidator<IReuniaoDto>
{
    public IReuniaoDtoValidator()
    {
        RuleFor(p => p.Data).NotNull().NotEmpty();
        RuleFor(p => p.Horario).NotNull().NotEmpty();
        RuleFor(p => p.DataPrevia).NotNull().NotEmpty();
        RuleFor(p => p.HorarioPrevia).NotNull().NotEmpty();
        RuleFor(p => p.Local).NotNull().NotEmpty();
        RuleFor(p => p.TipoReuniao).NotNull().NotEmpty().IsInEnum();
        RuleForEach(p => p.Proposicoes).SetValidator(new ProposicaoDtoValidator());
        RuleForEach(p => p.ProposicoesPrevia).SetValidator(new ProposicaoDtoValidator());
        RuleFor(p => p.Participantes).NotNull().NotEmpty();
        RuleForEach(p => p.Participantes).SetValidator(new ParticipanteDtoValidator());
        RuleForEach(p => p.ParticipantesPrevia).SetValidator(new ParticipanteDtoValidator());
        RuleForEach(p => p.Acoes).SetValidator(new AcaoDtoValidator());
    }
}