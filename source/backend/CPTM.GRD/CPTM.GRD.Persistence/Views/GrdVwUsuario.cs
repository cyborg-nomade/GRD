namespace CPTM.GRD.Persistence.Views
{
    public class GrdVwUsuario
    {
        public int IdCodusuario { get; set; }
        public string TxUsername { get; set; } = null!;
        public string? TxNomeusuario { get; set; }
        public string? TxApelido { get; set; }
        public string? TxEmpresa { get; set; }
        public int? IdMix { get; set; }
        public string? Matricula { get; set; }
        public string? MatriculaAntiga { get; set; }
        public string? TxMatricAlternativa { get; set; }
        public string? TxSiglaArea { get; set; }
        public string? TxEstrutura { get; set; }
        public DateTime? DtNascimento { get; set; }
        public DateTime? DtAdmissao { get; set; }
        public DateTime? DtDemissao { get; set; }
        public DateTime? DtAtualizacao { get; set; }
        public DateTime? DtExpiracao { get; set; }
        public DateTime? DtDesligamentoTerceiro { get; set; }
        public string? Cpf { get; set; }
        public string? Rg { get; set; }
        public decimal? CdFuncionario { get; set; }
        public string? CdTipoFuncionario { get; set; }
        public string? TxTipoFuncionario { get; set; }
        public string? TxSite { get; set; }
        public string? TxBilheteServico { get; set; }
        public int? IdCargo { get; set; }
        public string? TxCargo { get; set; }
        public int? IdFuncao { get; set; }
        public string? TxFuncao { get; set; }
        public string? CdSexo { get; set; }
        public string? TxTelefone { get; set; }
        public string? TxTelefoneCelular { get; set; }
        public string? TxFax { get; set; }
        public string? TxEndereco { get; set; }
        public string? TxCep { get; set; }
        public string? TxCidade { get; set; }
        public string? TxEstado { get; set; }
        public string? TxEmail { get; set; }
        public int? IdCodusuarioGestorAd { get; set; }
        public string? CdStatusEmpregado { get; set; }
        public string? TxStatusEmpregado { get; set; }
        public int? IdChefePonto { get; set; }
        public string? TxTipoChefe { get; set; }
        public bool? FlEmpregado { get; set; }
        public bool? FlAtivo { get; set; }
        public bool? FlAtivoAd { get; set; }
        public bool? FlAtvNrm { get; set; }
    }
}