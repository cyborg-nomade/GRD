using AutoMapper;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Logging;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.Features.Proposicoes.Requests.Commands;
using CPTM.GRD.Domain;
using CPTM.GRD.Domain.Logging;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Handlers.Commands;

public class
    AddDiretorVoteToProposicaoRequestHandler : IRequestHandler<AddDiretorVoteToProposicaoRequest,
        ProposicaoDto>
{
    private readonly IProposicaoRepository _proposicaoRepository;
    private readonly ILogProposicaoRepository _logProposicaoRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public AddDiretorVoteToProposicaoRequestHandler(IProposicaoRepository proposicaoRepository,
        ILogProposicaoRepository logProposicaoRepository, IUserRepository userRepository, IMapper mapper)
    {
        _proposicaoRepository = proposicaoRepository;
        _logProposicaoRepository = logProposicaoRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<ProposicaoDto> Handle(AddDiretorVoteToProposicaoRequest request,
        CancellationToken cancellationToken)
    {
        var proposicao = await _proposicaoRepository.Get(request.Pid);

        foreach (var voteWithAjustes in request.VotesWithAjustes)
        {
            var diretor = await _userRepository.Get(voteWithAjustes.VotoDto.Participante.User.Id);
            var votoRd = _mapper.Map<Voto>(voteWithAjustes.VotoDto);
            var ajustes = voteWithAjustes.Ajustes;

            proposicao.AddDiretorVote(diretor, votoRd, ajustes);
        }

        proposicao.CalculateNewProposicaoStatusFromVotes();

        var updatedProposicao = await _proposicaoRepository.Update(proposicao);

        return _mapper.Map<ProposicaoDto>(updatedProposicao);
    }
}