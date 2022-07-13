using AutoMapper;
using CPTM.GRD.Application.DTOs.Main.Reuniao;
using CPTM.GRD.Application.Features.Reunioes.Requests.Queries;
using CPTM.GRD.Application.Persistence.Contracts;
using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Handlers.Queries;

public class GetAllReunioesListRequestHandler : IRequestHandler<GetAllReunioesListRequest, List<ReuniaoListDto>>
{
    private readonly IReuniaoRepository _reuniaoRepository;
    private readonly IMapper _mapper;

    public GetAllReunioesListRequestHandler(IReuniaoRepository reuniaoRepository, IMapper mapper)
    {
        _reuniaoRepository = reuniaoRepository;
        _mapper = mapper;
    }

    public async Task<List<ReuniaoListDto>> Handle(GetAllReunioesListRequest request,
        CancellationToken cancellationToken)
    {
        var reunioes = await _reuniaoRepository.GetAll();
        return _mapper.Map<List<ReuniaoListDto>>(reunioes);
    }
}