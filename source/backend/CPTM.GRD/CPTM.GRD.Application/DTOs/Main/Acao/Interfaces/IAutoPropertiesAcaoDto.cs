using CPTM.GRD.Application.DTOs.Main.Acao.Children;
using CPTM.GRD.Common;

namespace CPTM.GRD.Application.DTOs.Main.Acao.Interfaces;

public interface IAutoPropertiesAcaoDto
{
    public AcaoStatus Status { get; set; }
    public bool Arquivada { get; set; }
    public int DiasParaVencimento { get; set; }
    public ICollection<AndamentoDto> Andamentos { get; set; }
}