using AutoMapper;
using CPTM.GRD.Application.Contracts.Persistence.Acoes;
using CPTM.GRD.Application.DTOs.Main.Acao;
using CPTM.GRD.Application.Features.Acoes.Requests.Queries;
using MediatR;

namespace CPTM.GRD.Application.Features.Acoes.Handlers.Queries;

public class GetAcaoDetailRequestHandler : IRequestHandler<GetAcaoDetailRequest, AcaoDto>
{
    private readonly IAcaoRepository _acaoRepository;
    private readonly IMapper _mapper;

    public GetAcaoDetailRequestHandler(IAcaoRepository acaoRepository, IMapper mapper)
    {
        _acaoRepository = acaoRepository;
        _mapper = mapper;
    }

    public async Task<AcaoDto> Handle(GetAcaoDetailRequest request, CancellationToken cancellationToken)
    {
        var acao = await _acaoRepository.Get(request.Aid);
        return _mapper.Map<AcaoDto>(acao);
    }
}