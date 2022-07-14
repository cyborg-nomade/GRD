using AutoMapper;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.DTOs.Main.Acao;
using CPTM.GRD.Application.Features.Acoes.Requests.Commands;
using MediatR;

namespace CPTM.GRD.Application.Features.Acoes.Handlers.Commands;

public class ChangeStatusAcaoRequestHandler : IRequestHandler<ChangeStatusAcaoRequest, AcaoDto>
{
    private readonly IAcaoRepository _acaoRepository;
    private readonly IMapper _mapper;

    public ChangeStatusAcaoRequestHandler(IAcaoRepository acaoRepository, IMapper mapper)
    {
        _acaoRepository = acaoRepository;
        _mapper = mapper;
    }

    public async Task<AcaoDto> Handle(ChangeStatusAcaoRequest request, CancellationToken cancellationToken)
    {
        var savedAcao = await _acaoRepository.Get(request.Aid);

        savedAcao.ChangeStatus(request.NewStatus, request.TipoLogAcao);

        var updatedAcao = await _acaoRepository.Update(savedAcao);

        return _mapper.Map<AcaoDto>(updatedAcao);
    }
}