using AutoMapper;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.Features.Proposicoes.Requests.Commands;
using CPTM.GRD.Application.Persistence.Contracts;
using CPTM.GRD.Application.Persistence.Contracts.AccessControl;
using CPTM.GRD.Application.Persistence.Contracts.Logging;
using CPTM.GRD.Domain.Logging;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Handlers.Commands;

public class
    AddDiretorVoteToProposicaoRequestHandler : IRequestHandler<AddDiretorVoteToProposicaoRequest, ProposicaoDto>
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
        var diretor = await _userRepository.Get(request.Did);
        var voteLog = new LogProposicao()
        {
            Data = DateTime.Now,
            Proposicao = proposicao,
            Diferenca = $@"Voto de Diretor {diretor.Nome} em RD: {request.Vote}",
            Tipo = request.Vote,
            UsuarioResp = diretor,
        };
        await _logProposicaoRepository.Add(voteLog);
        proposicao.Logs.Add(voteLog);
        var votes = proposicao.Logs;
        await _proposicaoRepository.Update(proposicao);
        return new ProposicaoDto();
    }
}