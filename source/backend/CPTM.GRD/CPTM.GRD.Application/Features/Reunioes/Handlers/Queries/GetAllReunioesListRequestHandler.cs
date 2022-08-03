using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.Reunioes;
using CPTM.GRD.Application.DTOs.Main.Reuniao;
using CPTM.GRD.Application.Features.Reunioes.Requests.Queries;
using CPTM.GRD.Common;
using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Handlers.Queries;

public class GetAllReunioesListRequestHandler : IRequestHandler<GetAllReunioesListRequest, List<ReuniaoListDto>>
{
    private readonly IReuniaoRepository _reuniaoRepository;
    private readonly IAuthenticationService _authenticationService;
    private readonly IMapper _mapper;

    public GetAllReunioesListRequestHandler(
        IReuniaoRepository reuniaoRepository,
        IAuthenticationService authenticationService,
        IMapper mapper)
    {
        _reuniaoRepository = reuniaoRepository;
        _authenticationService = authenticationService;
        _mapper = mapper;
    }

    public async Task<List<ReuniaoListDto>> Handle(GetAllReunioesListRequest request,
        CancellationToken cancellationToken)
    {
        _authenticationService.AuthorizeByMinLevel(request.RequestUser, AccessLevel.Grg);

        var reunioes = await _reuniaoRepository.GetAll();
        return _mapper.Map<List<ReuniaoListDto>>(reunioes);
    }
}