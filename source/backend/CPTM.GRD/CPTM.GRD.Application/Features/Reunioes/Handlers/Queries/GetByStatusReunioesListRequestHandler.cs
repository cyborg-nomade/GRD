using AutoMapper;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.Contracts.Persistence.Reunioes;
using CPTM.GRD.Application.DTOs.Main.Reuniao;
using CPTM.GRD.Application.Features.Reunioes.Requests.Queries;
using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Handlers.Queries;

public class
    GetByStatusReunioesListRequestHandler : IRequestHandler<GetByStatusReunioesListRequest, List<ReuniaoListDto>>
{
    private readonly IReuniaoRepository _reuniaoRepository;
    private readonly IMapper _mapper;

    public GetByStatusReunioesListRequestHandler(IReuniaoRepository reuniaoRepository, IMapper mapper)
    {
        _reuniaoRepository = reuniaoRepository;
        _mapper = mapper;
    }

    public async Task<List<ReuniaoListDto>> Handle(GetByStatusReunioesListRequest request,
        CancellationToken cancellationToken)
    {
        var reunioes = await _reuniaoRepository.GetByStatus(request.Status);
        return _mapper.Map<List<ReuniaoListDto>>(reunioes);
    }
}