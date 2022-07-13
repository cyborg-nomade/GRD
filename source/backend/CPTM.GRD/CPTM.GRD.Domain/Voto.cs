using CPTM.GRD.Common;

namespace CPTM.GRD.Domain;

public class Voto
{
    public int Id { get; set; }
    public Participante Participante { get; set; } = new Participante();
    public TipoVotoRd VotoRd { get; set; }
}