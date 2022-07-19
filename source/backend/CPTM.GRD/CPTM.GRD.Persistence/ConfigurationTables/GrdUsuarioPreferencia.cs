namespace CPTM.GRD.Persistence.ConfigurationTables
{
    public partial class GrdUsuarioPreferencia
    {
        public int IdCodUsuario { get; set; }
        public string TxCategoria { get; set; } = null!;
        public string? TxValor { get; set; }
    }
}