using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.Proposicoes;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.Features.Proposicoes.Requests.Queries;
using CPTM.GRD.Common;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Handlers.Queries;

public class
    GetByUserAndStatusProposicoesListRequestHandler : IRequestHandler<GetByUserAndStatusProposicoesListRequest,
        List<ProposicaoListDto>>
{
    private readonly IProposicaoRepository _proposicaoRepository;
    private readonly IMapper _mapper;
    private readonly IAuthenticationService _authenticationService;

    public GetByUserAndStatusProposicoesListRequestHandler(
        IProposicaoRepository proposicaoRepository,
        IMapper mapper,
        IAuthenticationService authenticationService)
    {
        _proposicaoRepository = proposicaoRepository;
        _mapper = mapper;
        _authenticationService = authenticationService;
    }

    public async Task<List<ProposicaoListDto>> Handle(GetByUserAndStatusProposicoesListRequest request,
        CancellationToken cancellationToken)
    {
        _authenticationService.AuthorizeByMinLevel(request.RequestUser, AccessLevel.Sub);
        await _authenticationService.AuthorizeByExactUser(request.RequestUser, request.Uid);
        var proposicoes =
            await _proposicaoRepository.GetByUserAndStatus(request.Uid, request.Status, request.Arquivada);
        return _mapper.Map<List<ProposicaoListDto>>(proposicoes);
    }
}