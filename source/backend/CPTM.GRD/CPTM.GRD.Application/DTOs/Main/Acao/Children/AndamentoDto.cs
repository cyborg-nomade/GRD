using CPTM.GRD.Application.DTOs.AccessControl.User;
using CPTM.GRD.Application.DTOs.Main.Acao.Children.Interfaces;
using CPTM.GRD.Common;

namespace CPTM.GRD.Application.DTOs.Main.Acao.Children;

public class AndamentoDto : IAndamentoDto
{
    public int Id { get; set; }
    public DateTime Data { get; set; }
    public UserDto User { get; set; } = new UserDto();
    public AndamentoStatus Status { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public ICollection<string> AnexosFilePaths { get; set; } = new List<string>();
}