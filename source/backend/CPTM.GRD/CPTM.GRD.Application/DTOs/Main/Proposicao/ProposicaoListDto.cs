using CPTM.GRD.Application.DTOs.AccessControl;
using CPTM.GRD.Application.DTOs.Logging;
using CPTM.GRD.Common;

namespace CPTM.GRD.Application.DTOs.Main.Proposicao;

public class ProposicaoListDto
{
    public int Id { get; set; }
    public int IdPrd { get; set; }
    public ProposicaoStatus Status { get; set; }
    public bool Arquivada { get; set; }
    public UserDto Criador { get; set; } = new UserDto();
    public GroupDto AreaSolicitante { get; set; } = new GroupDto();
    public string Titulo { get; set; } = string.Empty;
    public ObjetoProposicao Objeto { get; set; }
    public string Moeda { get; set; } = string.Empty;
    public float ValorTotalProposicao { get; set; }
    public ReceitaDespesa ReceitaDespesa { get; set; }
}