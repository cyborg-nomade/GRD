namespace GPR.Domain
{
    public class Reuniao
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

        public List<Proposicao>? ProposicoesPauta { get; set; }
        public List<Proposicao>? ProposicoesPautaPrevia { get; set; }
        public List<Participante> Participantes { get; set; } = new List<Participante>();
    }
}