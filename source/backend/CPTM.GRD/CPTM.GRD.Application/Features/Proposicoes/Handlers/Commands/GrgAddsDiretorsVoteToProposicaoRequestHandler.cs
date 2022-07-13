using AutoMapper;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.Features.Proposicoes.Requests.Commands;
using CPTM.GRD.Application.Persistence.Contracts;
using CPTM.GRD.Application.Persistence.Contracts.AccessControl;
using CPTM.GRD.Application.Persistence.Contracts.Logging;
using CPTM.GRD.Domain;
using CPTM.GRD.Domain.Logging;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Handlers.Commands;

public class
    GrgAddsDiretorsVoteToProposicaoRequestHandler : IRequestHandler<GrgAddsDiretorsVoteToProposicaoRequest,
        ProposicaoDto>
{
    private readonly IProposicaoRepository _proposicaoRepository;
    private readonly ILogProposicaoRepository _logProposicaoRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GrgAddsDiretorsVoteToProposicaoRequestHandler(IProposicaoRepository proposicaoRepository,
        ILogProposicaoRepository logProposicaoRepository, IUserRepository userRepository, IMapper mapper)
    {
        _proposicaoRepository = proposicaoRepository;
        _logProposicaoRepository = logProposicaoRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<ProposicaoDto> Handle(GrgAddsDiretorsVoteToProposicaoRequest request,
        CancellationToken cancellationToken)
    {
        var proposicao = await _proposicaoRepository.Get(request.Pid);

        foreach (var vote in request.Votes)
        {
            var diretor = await _userRepository.Get(vote.ParticipanteDto.User.Id);
            var voteLog = new LogProposicao()
            {
                Data = DateTime.Now,
                ProposicaoId = $@"IDPRD: {proposicao.IdPrd}",
                Diferenca = $@"Voto de Diretor {diretor.Nome} em RD: {vote.VotoRd}",
                Tipo = LogProposicao.ConvertFromTipoVoto(vote.VotoRd),
                UsuarioResp = diretor,
            };
            await _logProposicaoRepository.Add(voteLog);
            proposicao.Logs.Add(voteLog);

            var newVote = new Voto()
            {
                Participante = _mapper.Map<Participante>(vote.ParticipanteDto),
                VotoRd = vote.VotoRd,
            };
            proposicao.VotosRd.Add(newVote);
        }

        proposicao.CalculateNewProposicaoStatusFromVotes();

        var updatedProposicao = await _proposicaoRepository.Update(proposicao);

        return _mapper.Map<ProposicaoDto>(updatedProposicao);
    }
}