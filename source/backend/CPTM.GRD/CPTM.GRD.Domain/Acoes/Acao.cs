using CPTM.GRD.Common;
using CPTM.GRD.Domain.AccessControl;
using CPTM.GRD.Domain.Acoes.Children;
using CPTM.GRD.Domain.Logging;
using CPTM.GRD.Domain.Reunioes;

namespace CPTM.GRD.Domain.Acoes;

public class Acao
{
    public int Id { get; set; }
    public TipoAcao Tipo { get; set; }
    public Group DiretoriaRes { get; set; } = new Group();
    public string Definicao { get; set; } = string.Empty;
    public TipoPeriodicidadeAcao Periodicidade { get; set; }
    public DateTime PrazoInicial { get; set; }
    public AcaoStatus Status { get; set; }
    public bool Arquivada { get; set; }
    public User Responsavel { get; set; } = new User();
    public string EmailDiretor { get; set; } = string.Empty;
    public string? NumeroContrato { get; set; }
    public string? Fornecedor { get; set; }
    public int PrazoProrrogadoDias { get; set; }
    public DateTime PrazoFinal { get; set; }
    public int DiasParaVencimento { get; set; }
    public TipoAlertaVencimento AlertaVencimento { get; set; }
    public ICollection<Andamento>? Andamentos { get; set; } = new List<Andamento>();
    public ICollection<Reuniao> Reunioes { get; set; } = new List<Reuniao>();
    public ICollection<LogAcao>? Logs { get; set; } = new List<LogAcao>();

    private Acao GenerateAcaoLog(TipoLogAcao tipoLogAcao, string diferenca, User responsavel)
    {
        Logs.Add(new LogAcao(this, tipoLogAcao, diferenca, responsavel));
        return this;
    }

    private Acao ChangeStatus(AcaoStatus newStatus, TipoLogAcao tipoLogAcao, User responsavel)
    {
        GenerateAcaoLog(tipoLogAcao, $@"Mudança de status de {Status} para {newStatus}", responsavel);
        Status = newStatus;
        return this;
    }

    private Acao CalculateDiasParaVencimento()
    {
        DiasParaVencimento = (int)(PrazoFinal - PrazoInicial).TotalDays;
        return this;
    }

    internal Acao AddToReuniao(Reuniao reuniao, User responsavel)
    {
        GenerateAcaoLog(TipoLogAcao.Criacao, "Salvamento inicial", responsavel);
        Reunioes.Add(reuniao);
        ChangeStatus(AcaoStatus.EmAndamento, TipoLogAcao.Criacao, responsavel);
        return this;
    }

    internal Acao RemoveFromReuniao(Reuniao reuniao, User responsavel)
    {
        GenerateAcaoLog(TipoLogAcao.RemocaoDeReuniao, $@"Remoção da pauta da RD número {reuniao.NumeroReuniao}",
            responsavel);
        Reunioes.Remove(reuniao);
        ChangeStatus(AcaoStatus.EmAndamento, TipoLogAcao.RemocaoDeReuniao, responsavel);
        return this;
    }

    public Acao OnUpdate(string diferenca, User responsavel)
    {
        GenerateAcaoLog(TipoLogAcao.Edicao, diferenca, responsavel);
        return this;
    }

    public Acao AddAndamento(Andamento newAndamento)
    {
        GenerateAcaoLog(TipoLogAcao.InclusaoAndamento, $@"Novo Andamento: {newAndamento.Descricao}", newAndamento.User);
        Andamentos.Add(newAndamento);
        return this;
    }

    public Acao FollowUp(Reuniao reuniao, User responsavel)
    {
        ChangeStatus(AcaoStatus.EmAcompanhamento, TipoLogAcao.Edicao, responsavel);
        reuniao.FollowUpAcao(this);
        Reunioes.Add(reuniao);
        return this;
    }

    public Acao Finish(AcaoStatus status, User responsavel)
    {
        ChangeStatus(status, TipoLogAcao.Finalizacao, responsavel);
        return this;
    }
}