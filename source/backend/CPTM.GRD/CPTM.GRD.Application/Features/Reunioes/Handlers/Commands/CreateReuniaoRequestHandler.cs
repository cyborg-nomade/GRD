using AutoMapper;
using CPTM.GRD.Application.DTOs.Main.Reuniao;
using CPTM.GRD.Application.Features.Reunioes.Requests.Commands;
using CPTM.GRD.Application.Persistence.Contracts;
using CPTM.GRD.Application.Persistence.Contracts.AccessControl;
using CPTM.GRD.Application.Persistence.Contracts.Logging;
using CPTM.GRD.Application.Persistence.Contracts.StrictSequenceControl;
using CPTM.GRD.Common;
using CPTM.GRD.Domain;
using CPTM.GRD.Domain.Logging;
using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Handlers.Commands;

public class CreateReuniaoRequestHandler : IRequestHandler<CreateReuniaoRequest, ReuniaoDto>
{
    private readonly IReuniaoRepository _reuniaoRepository;
    private readonly IUserRepository _userRepository;
    private readonly ILogReuniaoRepository _logReuniaoRepository;
    private readonly IMapper _mapper;
    private readonly IReuniaoStrictSequenceControl _sequenceControl;

    public CreateReuniaoRequestHandler(IReuniaoRepository reuniaoRepository, IUserRepository userRepository,
        ILogReuniaoRepository logReuniaoRepository, IMapper mapper,
        IReuniaoStrictSequenceControl sequenceControl)
    {
        _reuniaoRepository = reuniaoRepository;
        _userRepository = userRepository;
        _logReuniaoRepository = logReuniaoRepository;
        _mapper = mapper;
        _sequenceControl = sequenceControl;
    }

    public async Task<ReuniaoDto> Handle(CreateReuniaoRequest request, CancellationToken cancellationToken)
    {
        var reuniao = _mapper.Map<Reuniao>(request.ReuniaoDto);
        reuniao.NumeroReuniao = await _sequenceControl.GetNextNumeroReuniao();

        var createLog = new LogReuniao()
        {
            Data = DateTime.Now,
            Tipo = TipoLogReuniao.Criacao,
            Diferenca = "Salvamento inicial",
            ReuniaoId = $@"Numero Reuniao {reuniao.NumeroReuniao}",
            UsuarioResp = await _userRepository.Get(request.Uid),
        };
        await _logReuniaoRepository.Add(createLog);
        reuniao.Logs.Add(createLog);

        var addedReuniao = await _reuniaoRepository.Add(reuniao);

        return _mapper.Map<ReuniaoDto>(addedReuniao);
    }
}