using CPTM.GRD.Common;

namespace CPTM.GRD.Application.DTOs.Main.Reuniao;

public class ReuniaoListDto
{
    public int Id { get; set; }
    public int NumeroReuniao { get; set; }
    public DateTime Data { get; set; }
    public DateTime Horario { get; set; }
    public ReuniaoStatus Status { get; set; }
    public DateTime DataPrevia { get; set; }
    public DateTime HorarioPrevia { get; set; }
    public string Local { get; set; } = string.Empty;
    public TipoReuniao TipoReuniao { get; set; }
}