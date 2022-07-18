﻿using CPTM.GRD.Application.DTOs.AccessControl.User;

namespace CPTM.GRD.Application.DTOs.AccessControl.Group;

public interface IGroupDto
{
    public string Sigla { get; set; }
    public string Nome { get; set; }
    public string SiglaGerencia { get; set; }
    public string Gerencia { get; set; }
    public string SiglaDiretoria { get; set; }
    public string Diretoria { get; set; }
    public UserDto Relator { get; set; }
}