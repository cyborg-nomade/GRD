using CPTM.GRD.Application.DTOs.AccessControl;
using CPTM.GRD.Common;

namespace CPTM.GRD.Application.DTOs.Main;

public class AndamentoDto
{
    public int Id { get; set; }
    public DateOnly Data { get; set; }
    public UserDto? User { get; set; }
    public string NomeResponsavel { get; set; } = string.Empty;
    public AndamentoStatus Status { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public ICollection<string> AnexosFilePaths { get; set; } = new List<string>();
}