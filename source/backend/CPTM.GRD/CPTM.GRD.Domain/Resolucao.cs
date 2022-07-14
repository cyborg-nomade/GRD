namespace CPTM.GRD.Domain;

public class Resolucao
{
    public int Id { get; set; }
    public int NumeroResolucao { get; set; }
    public string AssinaturaResolucao { get; set; } = string.Empty;
    public string ResolucaoDiretoria { get; set; } = string.Empty;
    public string ResolucaoFilePath { get; set; } = string.Empty;
    public Proposicao Proposicao { get; set; } = new Proposicao();
}