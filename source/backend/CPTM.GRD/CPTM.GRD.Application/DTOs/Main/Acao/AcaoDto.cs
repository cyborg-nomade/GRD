using CPTM.GRD.Application.DTOs.AccessControl.Group;
using CPTM.GRD.Application.DTOs.AccessControl.User;
using CPTM.GRD.Application.DTOs.Main.Acao.Children;
using CPTM.GRD.Common;

namespace CPTM.GRD.Application.DTOs.Main.Acao;

public class AcaoDto : UpdateAcaoDto, IAcaoDto
{
    public int Id { get; set; }
    public AcaoStatus Status { get; set; }
    public bool Arquivada { get; set; }
    public int DiasParaVencimento { get; set; }
    public ICollection<AndamentoDto> Andamentos { get; set; } = new List<AndamentoDto>();
}