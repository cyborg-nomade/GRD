using CPTM.GRD.Application.DTOs.Main.Acao;
using CPTM.GRD.Application.DTOs.Main.Reuniao;

namespace CPTM.GRD.Application.DTOs.Main.Mixed;

public class AddAcaoToReuniaoDto
{
    public AcaoDto AcaoDto { get; init; } = new AcaoDto();
    public ReuniaoDto ReuniaoDto { get; init; } = new ReuniaoDto();
}