using CPTM.GRD.Common;
using CPTM.GRD.Domain.AccessControl;

namespace CPTM.GRD.Domain.Proposicoes.Children;

public class Voto
{
    public int Id { get; set; }
    public User? Participante { get; set; } = new User();
    public TipoVotoRd VotoRd { get; set; }
}