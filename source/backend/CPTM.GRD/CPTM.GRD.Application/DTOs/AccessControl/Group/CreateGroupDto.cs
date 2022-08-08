using CPTM.GRD.Application.DTOs.AccessControl.Group.Interfaces;

namespace CPTM.GRD.Application.DTOs.AccessControl.Group;

public class CreateGroupDto : IGroupDto
{
    public string Sigla { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public string SiglaGerencia { get; set; } = string.Empty;
    public string Gerencia { get; set; } = string.Empty;
    public string SiglaDiretoria { get; set; } = string.Empty;
    public string Diretoria { get; set; } = string.Empty;
}