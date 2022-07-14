using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.DTOs.Main.Reuniao;
using CPTM.GRD.Application.Features.Reunioes.Requests.Commands;
using CPTM.GRD.Application.Persistence.Contracts.AccessControl;
using CPTM.GRD.Application.Persistence.Contracts.Logging;
using CPTM.GRD.Common;
using CPTM.GRD.Domain.Logging;
using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Handlers.Commands;

public class CreateMemoriaPreviaReuniaoRequestHandler : IRequestHandler<CreateMemoriaPreviaReuniaoRequest, ReuniaoDto>
{
    private readonly IReuniaoRepository _reuniaoRepository;
    private readonly ILogReuniaoRepository _logReuniaoRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IFileCreator _fileCreator;

    public CreateMemoriaPreviaReuniaoRequestHandler(IReuniaoRepository reuniaoRepository,
        ILogReuniaoRepository logReuniaoRepository, IUserRepository userRepository, IMapper mapper,
        IFileCreator fileCreator)
    {
        _reuniaoRepository = reuniaoRepository;
        _logReuniaoRepository = logReuniaoRepository;
        _userRepository = userRepository;
        _mapper = mapper;
        _fileCreator = fileCreator;
    }

    public async Task<ReuniaoDto> Handle(CreateMemoriaPreviaReuniaoRequest request, CancellationToken cancellationToken)
    {
        var reuniao = await _reuniaoRepository.Get(request.Rid);

        var criacaoMemoriaPreviaLog = new LogReuniao()
        {
            Data = DateTime.Now,
            Tipo = TipoLogReuniao.EmissaoMemoriaPrevia,
            Diferenca = "Emissão Memória Prévia",
            ReuniaoId = $@"Número Reunião {reuniao.NumeroReuniao}",
            UsuarioResp = await _userRepository.Get(request.Uid)
        };
        await _logReuniaoRepository.Add(criacaoMemoriaPreviaLog);
        reuniao.Logs.Add(criacaoMemoriaPreviaLog);

        reuniao.MemoriaPreviaFilePath = await _fileCreator.CreateMemoriaPrevia(reuniao);

        var updatedReuniao = await _reuniaoRepository.Update(reuniao);
        return _mapper.Map<ReuniaoDto>(updatedReuniao);
    }
}