using AutoMapper;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Proposicoes;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.Features.Proposicoes.Requests.Commands;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Handlers.Commands;

public class
    DiretoriaResponsavelRepproveProposicaoRequestHandler : IRequestHandler<DiretoriaResponsavelRepproveProposicaoRequest
        , ProposicaoDto>
{
    private readonly IProposicaoRepository _proposicaoRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public DiretoriaResponsavelRepproveProposicaoRequestHandler(IProposicaoRepository proposicaoRepository,
        IUserRepository userRepository, IMapper mapper)
    {
        _proposicaoRepository = proposicaoRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<ProposicaoDto> Handle(DiretoriaResponsavelRepproveProposicaoRequest request,
        CancellationToken cancellationToken)
    {
        var proposicaoExists = await _proposicaoRepository.Exists(request.Pid);
        var responsavelExists = await _userRepository.Exists(request.Uid);

        if (!(proposicaoExists || responsavelExists))
        {
            throw new Exception("Proposição ou responsável não encontrado");
        }

        var proposicao = await _proposicaoRepository.Get(request.Pid);
        var responsavel = await _userRepository.Get(request.Uid);

        proposicao.DiretoriaResponsavelRepproveProposicao(responsavel, request.MotivoReprovacao);

        var updatedProposicao = await _proposicaoRepository.Update(proposicao);

        return _mapper.Map<ProposicaoDto>(updatedProposicao);
    }
}