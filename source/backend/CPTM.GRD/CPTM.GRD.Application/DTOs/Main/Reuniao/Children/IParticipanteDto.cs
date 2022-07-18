﻿using CPTM.GRD.Application.DTOs.AccessControl.Group;
using CPTM.GRD.Application.DTOs.AccessControl.User;

namespace CPTM.GRD.Application.DTOs.Main.Reuniao.Children;

public interface IParticipanteDto
{
    public UserDto User { get; set; }
    public GroupDto DiretoriaArea { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
}