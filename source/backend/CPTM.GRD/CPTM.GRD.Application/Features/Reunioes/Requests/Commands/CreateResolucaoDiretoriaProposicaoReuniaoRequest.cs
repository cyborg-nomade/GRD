using CPTM.GRD.Application.DTOs.Main.Proposicao;
using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Requests.Commands;

public class CreateResolucaoDiretoriaProposicaoReuniaoRequest : IRequest<ProposicaoDto>
{
    public int Rid { get; set; }
    public int Pid { get; set; }
    public int Uid { get; set; }
}