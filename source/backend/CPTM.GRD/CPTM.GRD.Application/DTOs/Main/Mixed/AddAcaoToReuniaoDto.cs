using CPTM.GRD.Application.DTOs.Main.Acao;
using CPTM.GRD.Application.DTOs.Main.Reuniao;

namespace CPTM.GRD.Application.DTOs.Main.Mixed;

public class AddAcaoToReuniaoDto
{
    public AcaoDto AcaoDto { get; set; } = new AcaoDto();
    public ReuniaoDto ReuniaoDto { get; set; } = new ReuniaoDto();
}