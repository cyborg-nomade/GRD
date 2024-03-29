﻿using CPTM.GRD.Application.DTOs.AccessControl.Group;
using CPTM.GRD.Application.DTOs.AccessControl.User;
using CPTM.GRD.Common;

namespace CPTM.GRD.Application.DTOs.Main.Acao.Interfaces;

public interface IBaseAcaoDto
{
    public TipoAcao Tipo { get; set; }
    public GroupDto DiretoriaRes { get; set; }
    public string Definicao { get; set; }
    public TipoPeriodicidadeAcao Periodicidade { get; set; }
    public DateTime PrazoInicial { get; set; }
    public UserDto Responsavel { get; set; }
    public string EmailDiretor { get; set; }
    public string? NumeroContrato { get; set; }
    public string? Fornecedor { get; set; }
    public DateTime PrazoFinal { get; set; }
    public TipoAlertaVencimento AlertaVencimento { get; set; }
}