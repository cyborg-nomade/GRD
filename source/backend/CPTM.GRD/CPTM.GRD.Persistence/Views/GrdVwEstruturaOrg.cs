namespace CPTM.GRD.Persistence.Views
{
    public partial class GrdVwEstruturaOrg
    {
        public string IdEstrutura { get; set; } = null!;
        public string? TxNome { get; set; }
        public string? TxNomeReduzido { get; set; }
        public string? TxLogradouro { get; set; }
        public string? TxNumero { get; set; }
        public string? TxComplemento { get; set; }
        public string? CdCentroCusto { get; set; }
        public string? TxBairro { get; set; }
        public string? TxCidade { get; set; }
        public string? TxEstado { get; set; }
        public string? TxEnderecoCompleto { get; set; }
        public string? TxSigla { get; set; }
        public decimal? NrNivel { get; set; }
        public string? DepSigla { get; set; }
        public string? GerSigla { get; set; }
        public string? GgSigla { get; set; }
        public string? DirSigla { get; set; }
        public string? CdTipoEstrutura { get; set; }
        public string? TxTipoEstrutura { get; set; }
        public decimal? FlAtivo { get; set; }
    }
}