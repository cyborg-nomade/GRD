namespace CPTM.GRD.Application.DTOs;

public class ResolucaoDto
{
    public int Id { get; set; }
    public int NumeroResolucao { get; set; }
    public string AssinaturaResolucao { get; set; } = string.Empty;
    public string ResolucaoDiretoria { get; set; } = string.Empty;
    public string ResolucaoFilePath { get; set; } = string.Empty;
    public ProposicaoDto Proposicao { get; set; } = new ProposicaoDto();
}