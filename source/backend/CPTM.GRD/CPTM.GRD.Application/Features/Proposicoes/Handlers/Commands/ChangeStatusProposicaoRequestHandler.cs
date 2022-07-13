using AutoMapper;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.Features.Proposicoes.Requests.Commands;
using CPTM.GRD.Application.Persistence.Contracts;
using CPTM.GRD.Application.Persistence.Contracts.AccessControl;
using CPTM.GRD.Application.Persistence.Contracts.Logging;
using CPTM.GRD.Application.Util;
using CPTM.GRD.Common;
using CPTM.GRD.Domain.Logging;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Handlers.Commands;

public class ChangeStatusProposicaoRequestHandler : IRequestHandler<ChangeStatusProposicaoRequest, ProposicaoDto>
{
    private readonly IProposicaoRepository _proposicaoRepository;
    private readonly ILogProposicaoRepository _logProposicaoRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public ChangeStatusProposicaoRequestHandler(IProposicaoRepository proposicaoRepository,
        ILogProposicaoRepository logProposicaoRepository, IUserRepository userRepository, IMapper mapper)
    {
        _proposicaoRepository = proposicaoRepository;
        _logProposicaoRepository = logProposicaoRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }


    public async Task<ProposicaoDto> Handle(ChangeStatusProposicaoRequest request, CancellationToken cancellationToken)
    {
        var savedProposicao = await _proposicaoRepository.Get(request.Id);

        var changeStatusLog = new LogProposicao()
        {
            Data = DateTime.Now,
            Tipo = request.TipoLogProposicao,
            Diferenca = $@"Changed status from {savedProposicao.Status} to {request.NewStatus}",
            ProposicaoId = $@"IDPRD: {savedProposicao.IdPrd}",
            UsuarioResp = await _userRepository.Get(request.Uid),
        };
        await _logProposicaoRepository.Add(changeStatusLog);
        savedProposicao.Logs.Add(changeStatusLog);

        savedProposicao.Status = request.NewStatus;
        var updatedProposicao = await _proposicaoRepository.Update(savedProposicao);
        return _mapper.Map<ProposicaoDto>(updatedProposicao);
    }
}