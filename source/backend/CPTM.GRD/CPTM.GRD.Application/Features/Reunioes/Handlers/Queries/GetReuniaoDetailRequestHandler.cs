using AutoMapper;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.DTOs.Main.Reuniao;
using CPTM.GRD.Application.Features.Reunioes.Requests.Queries;
using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Handlers.Queries;

public class GetReuniaoDetailRequestHandler : IRequestHandler<GetReuniaoDetailRequest, ReuniaoDto>
{
    private readonly IReuniaoRepository _reuniaoRepository;
    private readonly IMapper _mapper;

    public GetReuniaoDetailRequestHandler(IReuniaoRepository reuniaoRepository, IMapper mapper)
    {
        _reuniaoRepository = reuniaoRepository;
        _mapper = mapper;
    }

    public async Task<ReuniaoDto> Handle(GetReuniaoDetailRequest request, CancellationToken cancellationToken)
    {
        var reuniao = await _reuniaoRepository.Get(request.Id);
        return _mapper.Map<ReuniaoDto>(reuniao);
    }
}