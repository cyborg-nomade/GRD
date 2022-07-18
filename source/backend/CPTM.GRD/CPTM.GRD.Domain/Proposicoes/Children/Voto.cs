using CPTM.GRD.Common;
using CPTM.GRD.Domain.Reunioes.Children;

namespace CPTM.GRD.Domain.Proposicoes.Children;

public class Voto
{
    public int Id { get; set; }
    public Participante Participante { get; set; } = new Participante();
    public TipoVotoRd VotoRd { get; set; }
}