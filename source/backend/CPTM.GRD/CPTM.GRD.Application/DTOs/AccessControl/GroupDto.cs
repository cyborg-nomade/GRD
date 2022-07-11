namespace CPTM.GRD.Application.DTOs.AccessControl;

public class GroupDto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string SiglaGerencia { get; set; } = string.Empty;
    public string Gerencia { get; set; } = string.Empty;
    public string SiglaDiretoria { get; set; } = string.Empty;
    public string Diretoria { get; set; } = string.Empty;
    public UserDto Relator { get; set; } = new UserDto();
}