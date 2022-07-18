namespace CPTM.GRD.Domain.AccessControl;

public class Group
{
    public int Id { get; set; }
    public string Sigla { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public string SiglaGerencia { get; set; } = string.Empty;
    public string Gerencia { get; set; } = string.Empty;
    public string SiglaDiretoria { get; set; } = string.Empty;
    public string Diretoria { get; set; } = string.Empty;
    public User Relator { get; set; } = new User();

    public bool CheckIsDiretoria()
    {
        return Sigla == SiglaDiretoria && SiglaGerencia == string.Empty;
    }

    public bool CheckIsGerencia()
    {
        return Sigla == SiglaGerencia;
    }
}