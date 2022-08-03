using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.Features.Proposicoes.Requests.Queries;
using CPTM.GRD.Common;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Handlers.Queries;

public class
    GetByGroupAndStatusProposicoesListRequestHandler : IRequestHandler<GetByGroupAndStatusProposicoesListRequest,
        List<ProposicaoListDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthenticationService _authenticationService;
    private readonly IMapper _mapper;

    public GetByGroupAndStatusProposicoesListRequestHandler(
        IUnitOfWork unitOfWork,
        IAuthenticationService authenticationService,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _authenticationService = authenticationService;
        _mapper = mapper;
    }

    public async Task<List<ProposicaoListDto>> Handle(GetByGroupAndStatusProposicoesListRequest request,
        CancellationToken cancellationToken)
    {
        _authenticationService.AuthorizeByMinLevel(request.RequestUser, AccessLevel.Sub);
        await _authenticationService.AuthorizeByMinGroups(request.RequestUser, request.Gid);
        var groupsToRetrive = await _unitOfWork.GroupRepository.GetSubordinateGroups(request.Gid);
        var proposicoes = new List<ProposicaoListDto>();
        foreach (var group in groupsToRetrive)
        {
            var groupProposicoes =
                await _unitOfWork.ProposicaoRepository.GetByGroupAndStatus(group.Id, request.Status, request.Arquivada);
            proposicoes.AddRange(_mapper.Map<List<ProposicaoListDto>>(groupProposicoes));
        }

        return proposicoes;
    }
}