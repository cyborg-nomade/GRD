namespace CPTM.GRD.Domain.AccessControl;

public class Group
{
    public int Id { get; init; }
    public string Sigla { get; init; } = string.Empty;
    public string Nome { get; init; } = string.Empty;
    public string SiglaGerencia { get; init; } = string.Empty;
    public string Gerencia { get; init; } = string.Empty;
    public string SiglaDiretoria { get; init; } = string.Empty;
    public string Diretoria { get; init; } = string.Empty;
    public ICollection<User> Users { get; set; } = new List<User>();

    public bool CheckIsDiretoria()
    {
        return Sigla == SiglaDiretoria && SiglaGerencia == SiglaDiretoria;
    }

    public bool CheckIsGerencia()
    {
        return Sigla == SiglaGerencia && SiglaDiretoria != SiglaGerencia;
    }
}