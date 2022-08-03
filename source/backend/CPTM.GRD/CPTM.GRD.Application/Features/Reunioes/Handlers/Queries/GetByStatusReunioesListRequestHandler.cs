using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.Reunioes;
using CPTM.GRD.Application.DTOs.Main.Reuniao;
using CPTM.GRD.Application.Features.Reunioes.Requests.Queries;
using CPTM.GRD.Common;
using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Handlers.Queries;

public class
    GetByStatusReunioesListRequestHandler : IRequestHandler<GetByStatusReunioesListRequest, List<ReuniaoListDto>>
{
    private readonly IReuniaoRepository _reuniaoRepository;
    private readonly IMapper _mapper;
    private readonly IAuthenticationService _authenticationService;

    public GetByStatusReunioesListRequestHandler(IReuniaoRepository reuniaoRepository, IMapper mapper,
        IAuthenticationService authenticationService)
    {
        _reuniaoRepository = reuniaoRepository;
        _mapper = mapper;
        _authenticationService = authenticationService;
    }

    public async Task<List<ReuniaoListDto>> Handle(GetByStatusReunioesListRequest request,
        CancellationToken cancellationToken)
    {
        _authenticationService.AuthorizeByMinLevel(request.RequestUser, AccessLevel.Grg);

        var reunioes = await _reuniaoRepository.GetByStatus(request.Status);
        return _mapper.Map<List<ReuniaoListDto>>(reunioes);
    }
}