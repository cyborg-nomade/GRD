using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.Features.Proposicoes.Requests.Queries;
using CPTM.GRD.Common;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Handlers.Queries;

public class
    GetByUserProposicoesListRequestHandler : IRequestHandler<GetByUserProposicoesListRequest, List<ProposicaoListDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IAuthenticationService _authenticationService;

    public GetByUserProposicoesListRequestHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IAuthenticationService authenticationService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _authenticationService = authenticationService;
    }

    public async Task<List<ProposicaoListDto>> Handle(GetByUserProposicoesListRequest request,
        CancellationToken cancellationToken)
    {
        _authenticationService.AuthorizeByMinLevel(request.RequestUser, AccessLevel.Sub);
        await _authenticationService.AuthorizeByExactUser(request.RequestUser, request.Uid);
        var proposicoes = await _unitOfWork.ProposicaoRepository.GetByUser(request.Uid);
        return _mapper.Map<List<ProposicaoListDto>>(proposicoes);
    }
}