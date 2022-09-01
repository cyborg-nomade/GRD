namespace CPTM.GRD.Application.Models.AD;

public class GrupoAd
{
    public GrupoAd() => this.Membros = new List<string>();

    public string ObjectGuid { get; set; } = string.Empty;

    public string NomeContainer { get; set; } = string.Empty;

    public string NomeDistinto { get; set; } = string.Empty;

    public DateTime DataCriacaoConta { get; set; }

    public DateTime DataAlteracaoConta { get; set; }

    public List<string> Membros { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string Descricao { get; set; } = string.Empty;

    public string Anotacoes { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string ClasseObjeto { get; set; } = string.Empty;

    public class Filtro
    {
        public Filtro() => this.CarregarMembros = true;

        public string ObjectGuid { get; set; } = string.Empty;

        public string Nome { get; set; } = string.Empty;

        public string NomeContainer { get; set; } = string.Empty;

        public DateTime DataCriacaoContaInicio { get; set; }

        public DateTime DataCriacaoContaFim { get; set; }

        public DateTime DataAlteracaoContaInicio { get; set; }

        public DateTime DataAlteracaoContaFim { get; set; }

        public bool CarregarMembros { get; set; }
    }
}