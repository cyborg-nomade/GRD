using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.Reunioes;
using CPTM.GRD.Application.DTOs.Main.Reuniao;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Application.Features.Reunioes.Requests.Queries;
using CPTM.GRD.Common;
using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Handlers.Queries;

public class GetReuniaoDetailRequestHandler : IRequestHandler<GetReuniaoDetailRequest, ReuniaoDto>
{
    private readonly IReuniaoRepository _reuniaoRepository;
    private readonly IMapper _mapper;
    private readonly IAuthenticationService _authenticationService;

    public GetReuniaoDetailRequestHandler(
        IReuniaoRepository reuniaoRepository,
        IMapper mapper,
        IAuthenticationService authenticationService)
    {
        _reuniaoRepository = reuniaoRepository;
        _mapper = mapper;
        _authenticationService = authenticationService;
    }

    public async Task<ReuniaoDto> Handle(GetReuniaoDetailRequest request, CancellationToken cancellationToken)
    {
        _authenticationService.AuthorizeByMinLevel(request.RequestUser, AccessLevel.Grg);

        var reuniao = await _reuniaoRepository.Get(request.Rid);
        if (reuniao == null) throw new NotFoundException(nameof(reuniao), request.Rid);
        return _mapper.Map<ReuniaoDto>(reuniao);
    }
}