using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Common;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Requests.Commands;

public class AddDiretorVoteToProposicaoRequest : IRequest<ProposicaoDto>
{
    public int Pid { get; set; }
    public int Did { get; set; }
    public TipoLogProposicao Vote { get; set; }
}