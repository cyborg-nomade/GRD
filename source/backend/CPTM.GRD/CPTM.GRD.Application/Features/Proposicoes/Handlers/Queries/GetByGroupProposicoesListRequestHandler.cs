using AutoMapper;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.Features.Proposicoes.Requests.Queries;
using CPTM.GRD.Application.Persistence.Contracts;
using CPTM.GRD.Application.Persistence.Contracts.AccessControl;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Handlers.Queries;

public class
    GetByGroupProposicoesListRequestHandler : IRequestHandler<GetByGroupProposicoesListRequest, List<ProposicaoListDto>>
{
    private readonly IProposicaoRepository _proposicaoRepository;
    private readonly IGroupRepository _groupRepository;
    private readonly IMapper _mapper;

    public GetByGroupProposicoesListRequestHandler(IProposicaoRepository proposicaoRepository,
        IGroupRepository groupRepository, IMapper mapper)
    {
        _proposicaoRepository = proposicaoRepository;
        _groupRepository = groupRepository;
        _mapper = mapper;
    }

    public async Task<List<ProposicaoListDto>> Handle(GetByGroupProposicoesListRequest request,
        CancellationToken cancellationToken)
    {
        var groupsToRetrive = await _groupRepository.GetSubordinateGroups(request.Gid);
        var proposicoes = new List<ProposicaoListDto>();
        foreach (var group in groupsToRetrive)
        {
            var groupProposicoes =
                await _proposicaoRepository.GetByGroup(group.Id);
            proposicoes.AddRange(_mapper.Map<List<ProposicaoListDto>>(groupProposicoes));
        }

        return proposicoes;
    }
}