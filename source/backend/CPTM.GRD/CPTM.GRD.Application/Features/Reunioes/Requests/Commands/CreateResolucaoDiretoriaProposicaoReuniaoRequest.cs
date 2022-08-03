using CPTM.GRD.Application.DTOs.Main.Proposicao;
using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Requests.Commands;

public class CreateResolucaoDiretoriaProposicaoReuniaoRequest : BasicRequest, IRequest<ProposicaoDto>
{
    public int Rid { get; init; }
    public int Pid { get; init; }
    public int Uid { get; init; }
}