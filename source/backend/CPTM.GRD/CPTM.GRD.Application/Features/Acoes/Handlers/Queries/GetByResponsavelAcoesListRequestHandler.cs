using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.DTOs.Main.Acao;
using CPTM.GRD.Application.Features.Acoes.Requests.Queries;
using MediatR;

namespace CPTM.GRD.Application.Features.Acoes.Handlers.Queries;

public class
    GetByResponsavelAcoesListRequestHandler : IRequestHandler<GetByResponsavelAcoesListRequest, List<AcaoListDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthenticationService _authenticationService;
    private readonly IMapper _mapper;

    public GetByResponsavelAcoesListRequestHandler(
        IUnitOfWork unitOfWork,
        IAuthenticationService authenticationService,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _authenticationService = authenticationService;
        _mapper = mapper;
    }

    public async Task<List<AcaoListDto>> Handle(GetByResponsavelAcoesListRequest request,
        CancellationToken cancellationToken)
    {
        await _authenticationService.AuthorizeByExactUser(request.RequestUser, request.Reid);
        var acoes = await _unitOfWork.AcaoRepository.GetByResponsavel(request.Reid);
        return _mapper.Map<List<AcaoListDto>>(acoes);
    }
}