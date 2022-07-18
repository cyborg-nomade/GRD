using AutoMapper;
using CPTM.GRD.Application.Contracts.Persistence.Acoes;
using CPTM.GRD.Application.DTOs.Main.Acao;
using CPTM.GRD.Application.Features.Acoes.Requests.Commands;
using CPTM.GRD.Application.Util;
using CPTM.GRD.Domain.Acoes;
using MediatR;

namespace CPTM.GRD.Application.Features.Acoes.Handlers.Commands;

public class UpdateAcaoRequestHandler : IRequestHandler<UpdateAcaoRequest, AcaoDto>
{
    private readonly IAcaoRepository _acaoRepository;
    private readonly IMapper _mapper;

    public UpdateAcaoRequestHandler(IAcaoRepository acaoRepository, IMapper mapper)
    {
        _acaoRepository = acaoRepository;
        _mapper = mapper;
    }

    public async Task<AcaoDto> Handle(UpdateAcaoRequest request, CancellationToken cancellationToken)
    {
        var savedAcao = await _acaoRepository.Get(request.AcaoDto.Id);

        savedAcao.OnUpdate(Differentiator.GetDifferenceString<Acao>(savedAcao, _mapper.Map<Acao>(request.AcaoDto)));

        _mapper.Map(request.AcaoDto, savedAcao);

        var updatedAcao = await _acaoRepository.Update(savedAcao);

        return _mapper.Map<AcaoDto>(updatedAcao);
    }
}