using CPTM.GRD.Application.DTOs.Main.Proposicao.Children.Voto;
using CPTM.GRD.Application.DTOs.Main.Reuniao;
using CPTM.GRD.Common;

namespace CPTM.GRD.Application.DTOs.Main.Proposicao.Interfaces;

public interface IAutoPropertiesProposicaoDto
{
    public ProposicaoStatus Status { get; set; }
    public bool Arquivada { get; set; }
    public ReuniaoDto? Reuniao { get; set; }
    public string? AnotacoesPrevia { get; set; }
    public List<VotoDto>? VotosRd { get; set; }
    public string? MotivoRetornoDiretoriaResp { get; set; }
    public string? MotivoRetornoGrg { get; set; }
    public string? AjustesRd { get; set; }
    public string? Deliberacao { get; set; }
    public bool IsExtraPauta { get; set; }
    public string? ResolucaoDiretoriaFilePath { get; set; }
}