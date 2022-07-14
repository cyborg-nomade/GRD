using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Logging;
using CPTM.GRD.Application.DTOs.Main.Reuniao;
using CPTM.GRD.Application.Features.Reunioes.Requests.Commands;
using CPTM.GRD.Common;
using CPTM.GRD.Domain.Logging;
using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Handlers.Commands;

public class
    CreatePautaDefinitivaReuniaoRequestHandler : IRequestHandler<CreatePautaDefinitivaReuniaoRequest, ReuniaoDto>
{
    private readonly IReuniaoRepository _reuniaoRepository;
    private readonly ILogReuniaoRepository _logReuniaoRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IFileCreator _fileCreator;

    public CreatePautaDefinitivaReuniaoRequestHandler(IReuniaoRepository reuniaoRepository,
        ILogReuniaoRepository logReuniaoRepository, IUserRepository userRepository, IMapper mapper,
        IFileCreator fileCreator)
    {
        _reuniaoRepository = reuniaoRepository;
        _logReuniaoRepository = logReuniaoRepository;
        _userRepository = userRepository;
        _mapper = mapper;
        _fileCreator = fileCreator;
    }

    public async Task<ReuniaoDto> Handle(CreatePautaDefinitivaReuniaoRequest request,
        CancellationToken cancellationToken)
    {
        var reuniao = await _reuniaoRepository.Get(request.Rid);

        var criacaoPautaDefinitivaLog = new LogReuniao()
        {
            Data = DateTime.Now,
            Tipo = TipoLogReuniao.EmissaoPautaDefinitiva,
            Diferenca = "Emissão Pauta Definitiva",
            ReuniaoId = $@"Número Reunião {reuniao.NumeroReuniao}",
            UsuarioResp = await _userRepository.Get(request.Uid)
        };
        await _logReuniaoRepository.Add(criacaoPautaDefinitivaLog);
        reuniao.Logs.Add(criacaoPautaDefinitivaLog);

        foreach (var proposicao in reuniao.Proposicoes)
        {
            proposicao.Status = ProposicaoStatus.EmPauta;
        }

        reuniao.PautaDefinitivaFilePath = await _fileCreator.CreatePautaDefinitiva(reuniao);

        var updatedReuniao = await _reuniaoRepository.Update(reuniao);
        return _mapper.Map<ReuniaoDto>(updatedReuniao);
    }
}