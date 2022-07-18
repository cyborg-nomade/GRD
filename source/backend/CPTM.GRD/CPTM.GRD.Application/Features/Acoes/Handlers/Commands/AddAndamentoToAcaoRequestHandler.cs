using AutoMapper;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.DTOs.Main.Acao;
using CPTM.GRD.Application.Features.Acoes.Requests.Commands;
using CPTM.GRD.Domain.Acoes.Children;
using MediatR;

namespace CPTM.GRD.Application.Features.Acoes.Handlers.Commands;

public class AddAndamentoToAcaoRequestHandler : IRequestHandler<AddAndamentoToAcaoRequest, AcaoDto>
{
    private readonly IAcaoRepository _acaoRepository;
    private readonly IMapper _mapper;

    public AddAndamentoToAcaoRequestHandler(IAcaoRepository acaoRepository, IMapper mapper)
    {
        _acaoRepository = acaoRepository;
        _mapper = mapper;
    }

    public async Task<AcaoDto> Handle(AddAndamentoToAcaoRequest request, CancellationToken cancellationToken)
    {
        var acao = await _acaoRepository.Get(request.Aid);
        var andamento = _mapper.Map<Andamento>(request.AndamentoDto);

        acao.AddAndamento(andamento);

        var updatedAcao = await _acaoRepository.Update(acao);
        return _mapper.Map<AcaoDto>(updatedAcao);
    }
}