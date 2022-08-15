namespace CPTM.GRD.Persistence.ConfigurationTables
{
    public class GrdConfiguracao
    {
        public string Parametro { get; set; } = null!;
        public string? TxDescricao { get; set; }
        public string? Valor { get; set; }
        public int IdCodusuarioCadastro { get; set; }
        public DateTime DtCadastro { get; set; }
        public int? IdCodusuarioAlteracao { get; set; }
        public DateTime? DtAlteracao { get; set; }
    }
}