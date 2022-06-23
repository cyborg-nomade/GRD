namespace GPR.Domain
{

  public class Pauta
  {
    public int Id { get; set; }
    public DateOnly DataReuniao { get; set; }
    public int NroReuniao { get; set; }
    public TimeOnly Horario { get; set; }
    public StatusPautaEnum Status { get; set; }
    public DateOnly DataReuniaoPrevia { get; set; }
    public TimeOnly HorarioPrevia { get; set; }
    public string Local { get; set; } = string.Empty;
    public TipoReuniaoEnum TipoReuniao { get; set; }

  }
}