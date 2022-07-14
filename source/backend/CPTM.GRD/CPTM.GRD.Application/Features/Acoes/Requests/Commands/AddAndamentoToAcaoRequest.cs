using CPTM.GRD.Application.DTOs.Main;
using CPTM.GRD.Application.DTOs.Main.Acao;
using MediatR;

namespace CPTM.GRD.Application.Features.Acoes.Requests.Commands;

public class AddAndamentoToAcaoRequest : IRequest<AcaoDto>
{
    public int Aid { get; set; }
    public AndamentoDto AndamentoDto { get; set; } = new AndamentoDto();
}