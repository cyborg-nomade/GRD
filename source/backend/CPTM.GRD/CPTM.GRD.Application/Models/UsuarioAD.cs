namespace CPTM.GRD.Application.Models;

public class UsuarioAD
{
    public string ObjectGUID { get; set; } = string.Empty;

    public string Login { get; set; } = string.Empty;

    public string NomeLogon { get; set; } = string.Empty;

    public string OpcoesConta { get; set; } = string.Empty;

    public string NomeContainer { get; set; } = string.Empty;

    public string NomeDistinto { get; set; } = string.Empty;

    public DateTime DataExpiracaoConta { get; set; }

    public DateTime DataCriacaoConta { get; set; }

    public DateTime DataAlteracaoConta { get; set; }

    public DateTime DataUltimaAlteracaoSenha { get; set; }

    public List<string> MembroDe { get; set; } = new List<string>();

    public bool ContaBloqueada { get; set; }

    public bool ContaDesabilitada { get; set; }

    public bool AlterarSenhaProximoLogon { get; set; }

    public DateTime DataExpiracaoSenha { get; set; }

    public bool SenhaNuncaExpira { get; set; }

    public string ScriptLogon { get; set; } = string.Empty;

    public string DiretorioBase { get; set; } = string.Empty;

    public string UnidadeBase { get; set; } = string.Empty;

    public string NomeExibicao { get; set; } = string.Empty;

    public string Nome { get; set; } = string.Empty;

    public string NomePrimeiro { get; set; } = string.Empty;

    public string NomeAbreviatura { get; set; } = string.Empty;

    public string NomeUltimo { get; set; } = string.Empty;

    public string Descricao { get; set; } = string.Empty;

    public string Anotacoes { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public bool OcultarEmailListaContatosExchange { get; set; }

    public List<string> ListasDeContato { get; set; } = new List<string>();

    public byte[]? Foto { get; set; }

    public DateTime DataUltimoLogon { get; set; }

    public DateTime DataUltimoLogoff { get; set; }

    public string PaisSigla { get; set; } = string.Empty;

    public string PaisNome { get; set; } = string.Empty;

    public string PaisCodigo { get; set; } = string.Empty;

    public string Cidade { get; set; } = string.Empty;

    public string Estado { get; set; } = string.Empty;

    public string CodigoPostal { get; set; } = string.Empty;

    public string Endereco { get; set; } = string.Empty;

    public string CaixaPostal { get; set; } = string.Empty;

    public string Titulo { get; set; } = string.Empty;

    public string Escritorio { get; set; } = string.Empty;

    public string Departamento { get; set; } = string.Empty;

    public string Empresa { get; set; } = string.Empty;

    public string GestorLogin { get; set; } = string.Empty;

    public string GestorNomeDistinto { get; set; } = string.Empty;

    public List<string> Subordinados { get; set; } = new List<string>();

    public string ClasseObjeto { get; set; } = string.Empty;

    public string TelefoneComercial { get; set; } = string.Empty;

    public string TelefoneResidencial { get; set; } = string.Empty;

    public string TelefoneCelular { get; set; } = string.Empty;

    public string Fax { get; set; } = string.Empty;

    public string TelefoneIP { get; set; } = string.Empty;

    public string Pager { get; set; } = string.Empty;

    public string TelefoneResidencialOutro { get; set; } = string.Empty;

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