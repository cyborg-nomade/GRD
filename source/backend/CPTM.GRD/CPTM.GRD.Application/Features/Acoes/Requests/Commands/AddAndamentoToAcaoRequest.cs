using CPTM.GRD.Application.DTOs.Main.Acao;
using CPTM.GRD.Application.DTOs.Main.Acao.Children;
using MediatR;

namespace CPTM.GRD.Application.Features.Acoes.Requests.Commands;

public class AddAndamentoToAcaoRequest : IRequest<AcaoDto>
{
    public int Aid { get; init; }
    public AndamentoDto AndamentoDto { get; init; } = new AndamentoDto();
}