﻿using CPTM.GRD.Common;

namespace CPTM.GRD.Application.DTOs.Main.Proposicao.Children.Voto.Interfaces;

public interface IBaseVotoDto
{
    public int ParticipanteId { get; set; }
    public TipoVotoRd VotoRd { get; set; }
}