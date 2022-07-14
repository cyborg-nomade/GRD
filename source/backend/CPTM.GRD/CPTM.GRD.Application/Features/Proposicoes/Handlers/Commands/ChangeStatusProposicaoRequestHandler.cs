using AutoMapper;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.Features.Proposicoes.Requests.Commands;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Handlers.Commands;

public class ChangeStatusProposicaoRequestHandler : IRequestHandler<ChangeStatusProposicaoRequest, ProposicaoDto>
{
    private readonly IProposicaoRepository _proposicaoRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public ChangeStatusProposicaoRequestHandler(IProposicaoRepository proposicaoRepository,
        IUserRepository userRepository, IMapper mapper)
    {
        _proposicaoRepository = proposicaoRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }


    public async Task<ProposicaoDto> Handle(ChangeStatusProposicaoRequest request, CancellationToken cancellationToken)
    {
        var savedProposicao = await _proposicaoRepository.Get(request.Pid);
        var responsavel = await _userRepository.Get(request.Uid);

        savedProposicao.ChangeStatus(request.NewStatus, request.TipoLogProposicao, responsavel);

        var updatedProposicao = await _proposicaoRepository.Update(savedProposicao);
        return _mapper.Map<ProposicaoDto>(updatedProposicao);
    }
}