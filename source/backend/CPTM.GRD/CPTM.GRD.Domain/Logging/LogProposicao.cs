﻿using CPTM.GRD.Domain.AccessControl;

namespace CPTM.GRD.Domain.Logging;

public class LogProposicao
{
    public int Id { get; set; }
    public TipoLogProposicao Tipo { get; set; }
    public Proposicao Proposicao { get; set; } = new Proposicao();
    public Proposicao Diferenca { get; set; } = new Proposicao();
    public DateTime Data { get; set; }
    public User UsuarioResp { get; set; } = new User();
}