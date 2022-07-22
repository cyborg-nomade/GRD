namespace CPTM.GRD.Application.Models;

public class UsuarioAD
{
    public UsuarioAD()
    {
        this.MembroDe = new List<string>();
        this.ListasDeContato = new List<string>();
        this.Subordinados = new List<string>();
    }

    public string ObjectGUID { get; set; } = string.Empty;

    public string Login { get; set; }

    public string NomeLogon { get; set; }

    public string OpcoesConta { get; set; }

    public string NomeContainer { get; set; }

    public string NomeDistinto { get; set; }

    public DateTime DataExpiracaoConta { get; set; }

    public DateTime DataCriacaoConta { get; set; }

    public DateTime DataAlteracaoConta { get; set; }

    public DateTime DataUltimaAlteracaoSenha { get; set; }

    public List<string> MembroDe { get; set; }

    public bool ContaBloqueada { get; set; }

    public bool ContaDesabilitada { get; set; }

    public bool AlterarSenhaProximoLogon { get; set; }

    public DateTime DataExpiracaoSenha { get; set; }

    public bool SenhaNuncaExpira { get; set; }

    public string ScriptLogon { get; set; }

    public string DiretorioBase { get; set; }

    public string UnidadeBase { get; set; }

    public string NomeExibicao { get; set; }

    public string Nome { get; set; }

    public string NomePrimeiro { get; set; }

    public string NomeAbreviatura { get; set; }

    public string NomeUltimo { get; set; }

    public string Descricao { get; set; }

    public string Anotacoes { get; set; }

    public string Email { get; set; }

    public bool OcultarEmailListaContatosExchange { get; set; }

    public List<string> ListasDeContato { get; set; }

    public byte[] Foto { get; set; }

    public DateTime DataUltimoLogon { get; set; }

    public DateTime DataUltimoLogoff { get; set; }

    public string PaisSigla { get; set; }

    public string PaisNome { get; set; }

    public string PaisCodigo { get; set; }

    public string Cidade { get; set; }

    public string Estado { get; set; }

    public string CodigoPostal { get; set; }

    public string Endereco { get; set; }

    public string CaixaPostal { get; set; }

    public string Titulo { get; set; }

    public string Escritorio { get; set; }

    public string Departamento { get; set; }

    public string Empresa { get; set; }

    public string GestorLogin { get; set; }

    public string GestorNomeDistinto { get; set; }

    public List<string> Subordinados { get; set; }

    public string ClasseObjeto { get; set; }

    public string TelefoneComercial { get; set; }

    public string TelefoneResidencial { get; set; }

    public string TelefoneCelular { get; set; }

    public string Fax { get; set; }

    public string TelefoneIP { get; set; } = string.Empty;

    public string Pager { get; set; }

    public string TelefoneResidencialOutro { get; set; }

    public class Filtro
    {
        public string ObjectGUID { get; set; } = string.Empty;

        public string Login { get; set; } = string.Empty;

        public string NomeContainer { get; set; } = string.Empty;

        public string NomeDistinto { get; set; } = string.Empty;

        public DateTime DataCriacaoContaInicio { get; set; }

        public DateTime DataCriacaoContaFim { get; set; }

        public DateTime DataAlteracaoContaInicio { get; set; }

        public DateTime DataAlteracaoContaFim { get; set; }

        public DateTime DataExpiracaoContaInicio { get; set; }

        public DateTime DataExpiracaoContaFim { get; set; }

        public bool SomenteMixAD { get; set; }

        public string Pager { get; set; } = string.Empty;

        public string TelefoneIP { get; set; } = string.Empty;

        public string PagerDiferente { get; set; } = string.Empty;
    }
}