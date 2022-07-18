using CPTM.GRD.Application.DTOs.AccessControl.Group;
using CPTM.GRD.Application.DTOs.AccessControl.User;
using CPTM.GRD.Common;

namespace CPTM.GRD.Application.DTOs.Main.Acao;

public class AcaoListDto
{
    public int Id { get; set; }
    public TipoAcao Tipo { get; set; }
    public GroupDto DiretoriaRes { get; set; } = new GroupDto();
    public string Definicao { get; set; } = string.Empty;
    public DateOnly PrazoInicial { get; set; }
    public AcaoStatus Status { get; set; }
    public bool Arquivada { get; set; }
    public UserDto Responsavel { get; set; } = new UserDto();
    public DateOnly PrazoFinal { get; set; }
}