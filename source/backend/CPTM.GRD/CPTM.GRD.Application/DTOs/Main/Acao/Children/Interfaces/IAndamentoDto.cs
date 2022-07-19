using CPTM.GRD.Application.DTOs.AccessControl.User;
using CPTM.GRD.Common;

namespace CPTM.GRD.Application.DTOs.Main.Acao.Children.Interfaces;

public interface IAndamentoDto
{
    public UserDto User { get; set; }
    public AndamentoStatus Status { get; set; }
    public string Descricao { get; set; }
    public ICollection<string> AnexosFilePaths { get; set; }
}