using AutoMapper;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Proposicoes;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Application.Features.Proposicoes.Requests.Commands;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Handlers.Commands;

public class
    GrgApproveAjustesRdProposicaoRequestHandler : IRequestHandler<GrgApproveAjustesRdProposicaoRequest, ProposicaoDto>
{
    private readonly IProposicaoRepository _proposicaoRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GrgApproveAjustesRdProposicaoRequestHandler(IProposicaoRepository proposicaoRepository,
        IUserRepository userRepository, IMapper mapper)
    {
        _proposicaoRepository = proposicaoRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<ProposicaoDto> Handle(GrgApproveAjustesRdProposicaoRequest request,
        CancellationToken cancellationToken)
    {
        var proposicaoExists = await _proposicaoRepository.Exists(request.Pid);

        if (!proposicaoExists)
        {
            throw new NotFoundException("Proposição", proposicaoExists);
        }

        var responsavelExists = await _userRepository.Exists(request.Uid);

        if (!responsavelExists)
        {
            throw new NotFoundException("Usuário", responsavelExists);
        }

        var proposicao = await _proposicaoRepository.Get(request.Pid);
        var responsavel = await _userRepository.Get(request.Uid);

        proposicao.GrgApproveProposicaoAjustesRd(responsavel);

        var updatedProposicao = await _proposicaoRepository.Update(proposicao);

        return _mapper.Map<ProposicaoDto>(updatedProposicao);
        ;
    }
}