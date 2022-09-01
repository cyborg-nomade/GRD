using CPTM.GRD.Common;

namespace CPTM.GRD.Application.DTOs.Main.Reuniao.Interfaces;

public interface IAutoPropertiesReuniaoDto
{
    public ReuniaoStatus Status { get; set; }
    public string PautaPreviaFilePath { get; set; }
    public string MemoriaPreviaFilePath { get; set; }
    public string PautaDefinitivaFilePath { get; set; }
    public string RelatorioDeliberativoFilePath { get; set; }
    public string AtaFilePath { get; set; }
}