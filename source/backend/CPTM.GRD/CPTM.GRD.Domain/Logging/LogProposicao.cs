﻿using CPTM.GRD.Common;
using CPTM.GRD.Domain.AccessControl;

namespace CPTM.GRD.Domain.Logging;

public class LogProposicao
{
    public int Id { get; set; }
    public TipoLogProposicao Tipo { get; set; }
    public string ProposicaoId { get; set; } = string.Empty;
    public string Diferenca { get; set; } = string.Empty;
    public DateTime Data { get; set; }
    public User UsuarioResp { get; set; } = new User();
}