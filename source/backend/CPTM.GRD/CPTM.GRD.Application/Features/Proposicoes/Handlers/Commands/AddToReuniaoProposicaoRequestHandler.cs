using AutoMapper;
using CPTM.GRD.Application.DTOs.Main.Mixed;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.DTOs.Main.Reuniao;
using CPTM.GRD.Application.Features.Proposicoes.Requests.Commands;
using CPTM.GRD.Application.Persistence.Contracts;
using CPTM.GRD.Application.Persistence.Contracts.AccessControl;
using CPTM.GRD.Application.Persistence.Contracts.Logging;
using CPTM.GRD.Common;
using CPTM.GRD.Domain.Logging;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Handlers.Commands;

public class AddToReuniaoProposicaoRequestHandler : IRequestHandler<AddToReuniaoProposicaoRequest, AddToPautaDto>
{
    private readonly IProposicaoRepository _proposicaoRepository;
    private readonly IReuniaoRepository _reuniaoRepository;
    private readonly ILogProposicaoRepository _logProposicaoRepository;
    private readonly ILogReuniaoRepository _logReuniaoRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public AddToReuniaoProposicaoRequestHandler(IProposicaoRepository proposicaoRepository,
        IReuniaoRepository reuniaoRepository, ILogProposicaoRepository logProposicaoRepository,
        ILogReuniaoRepository logReuniaoRepository, IUserRepository userRepository, IMapper mapper)
    {
        _proposicaoRepository = proposicaoRepository;
        _reuniaoRepository = reuniaoRepository;
        _logProposicaoRepository = logProposicaoRepository;
        _logReuniaoRepository = logReuniaoRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<AddToPautaDto> Handle(AddToReuniaoProposicaoRequest request, CancellationToken cancellationToken)
    {
        var proposicao = await _proposicaoRepository.Get(request.Pid);
        var reuniao = await _reuniaoRepository.Get(request.Rid);

        var proposicaoInclusaoLog = new LogProposicao()
        {
            Data = DateTime.Now,
            Tipo = TipoLogProposicao.InclusaoPauta,
            ProposicaoId = $@"IDPRD: {proposicao.IdPrd}",
            Diferenca = $@"Inclusão na pauta da RD número {reuniao.NumeroReuniao}",
            UsuarioResp = await _userRepository.Get(request.Uid),
        };
        var reuniaoInclusaoLog = new LogReuniao()
        {
            Data = DateTime.Now,
            Tipo = TipoLogReuniao.InclusaoProposicao,
            ReuniaoId = $@"Número Reunião: {reuniao.NumeroReuniao}",
            Diferenca = $@"Inclusão da Proposição IDPRD: {proposicao.IdPrd}",
            UsuarioResp = await _userRepository.Get(request.Uid),
        };
        await _logProposicaoRepository.Add(proposicaoInclusaoLog);
        await _logReuniaoRepository.Add(reuniaoInclusaoLog);
        proposicao.Logs.Add(proposicaoInclusaoLog);
        reuniao.Logs.Add(reuniaoInclusaoLog);

        proposicao.Reuniao = reuniao;
        reuniao.Proposicoes.Add(proposicao);

        var updatedProposicao = await _proposicaoRepository.Update(proposicao);
        var updatedReuniao = await _reuniaoRepository.Update(reuniao);
        return new AddToPautaDto()
        {
            ProposicaoDto = _mapper.Map<ProposicaoDto>(updatedProposicao),
            ReuniaoDto = _mapper.Map<ReuniaoDto>(updatedReuniao)
        };
    }
}