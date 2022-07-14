using CPTM.GRD.Application.DTOs.AccessControl;

namespace CPTM.GRD.Application.DTOs.Main;

public class ParticipanteDto
{
    public int Id { get; set; }
    public UserDto User { get; set; } = new UserDto();
    public string DiretoriaArea { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}