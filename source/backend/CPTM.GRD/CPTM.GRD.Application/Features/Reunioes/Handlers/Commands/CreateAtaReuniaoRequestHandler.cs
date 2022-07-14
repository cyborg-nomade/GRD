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

public class CreateAtaReuniaoRequestHandler : IRequestHandler<CreateAtaReuniaoRequest, ReuniaoDto>
{
    private readonly IReuniaoRepository _reuniaoRepository;
    private readonly ILogReuniaoRepository _logReuniaoRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IFileCreator _fileCreator;

    public CreateAtaReuniaoRequestHandler(IReuniaoRepository reuniaoRepository,
        ILogReuniaoRepository logReuniaoRepository, IUserRepository userRepository, IMapper mapper,
        IFileCreator fileCreator)
    {
        _reuniaoRepository = reuniaoRepository;
        _logReuniaoRepository = logReuniaoRepository;
        _userRepository = userRepository;
        _mapper = mapper;
        _fileCreator = fileCreator;
    }

    public async Task<ReuniaoDto> Handle(CreateAtaReuniaoRequest request, CancellationToken cancellationToken)
    {
        var reuniao = await _reuniaoRepository.Get(request.Rid);

        var criacaoPautaPreviaLog = new LogReuniao()
        {
            Data = DateTime.Now,
            Tipo = TipoLogReuniao.EmissaoAta,
            Diferenca = "Emissão Ata",
            ReuniaoId = $@"Número Reunião {reuniao.NumeroReuniao}",
            UsuarioResp = await _userRepository.Get(request.Uid)
        };
        await _logReuniaoRepository.Add(criacaoPautaPreviaLog);
        reuniao.Logs.Add(criacaoPautaPreviaLog);

        reuniao.Status = ReuniaoStatus.Arquivada;
        reuniao.AtaFilePath = await _fileCreator.CreateAta(reuniao);

        foreach (var proposicao in reuniao.Proposicoes)
        {
            proposicao.Arquivada = true;
        }

        var updatedReuniao = await _reuniaoRepository.Update(reuniao);
        return _mapper.Map<ReuniaoDto>(updatedReuniao);
    }
}