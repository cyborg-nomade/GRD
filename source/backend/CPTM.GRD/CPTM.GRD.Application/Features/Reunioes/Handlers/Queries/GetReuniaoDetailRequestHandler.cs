using AutoMapper;
using CPTM.GRD.Application.DTOs.Main.Reuniao;
using CPTM.GRD.Application.Features.Reunioes.Requests.Queries;
using CPTM.GRD.Application.Persistence.Contracts;
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