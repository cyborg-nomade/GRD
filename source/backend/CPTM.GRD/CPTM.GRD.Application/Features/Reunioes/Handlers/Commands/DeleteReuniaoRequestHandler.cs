using AutoMapper;
using CPTM.GRD.Application.DTOs.Main.Reuniao;
using CPTM.GRD.Application.Features.Reunioes.Requests.Commands;
using CPTM.GRD.Application.Persistence.Contracts;
using CPTM.GRD.Application.Persistence.Contracts.AccessControl;
using CPTM.GRD.Application.Persistence.Contracts.Logging;
using CPTM.GRD.Common;
using CPTM.GRD.Domain.Logging;
using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Handlers.Commands;

public class DeleteReuniaoRequestHandler : IRequestHandler<DeleteReuniaoRequest>
{
    private readonly IReuniaoRepository _reuniaoRepository;
    private readonly ILogReuniaoRepository _logReuniaoRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public DeleteReuniaoRequestHandler(IReuniaoRepository reuniaoRepository, ILogReuniaoRepository logReuniaoRepository,
        IUserRepository userRepository, IMapper mapper)
    {
        _reuniaoRepository = reuniaoRepository;
        _logReuniaoRepository = logReuniaoRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(DeleteReuniaoRequest request, CancellationToken cancellationToken)
    {
        var reuniao = await _reuniaoRepository.Get(request.Id);

        var removeLog = new LogReuniao()
        {
            Data = DateTime.Now,
            Tipo = TipoLogReuniao.Remocao,
            Diferenca = "Remoção",
            ReuniaoId = $@"WAS Número Reunião {reuniao.NumeroReuniao}",
            UsuarioResp = await _userRepository.Get(request.Uid),
        };
        await _logReuniaoRepository.Add(removeLog);

        await _reuniaoRepository.Delete(request.Id);

        return Unit.Value;
    }
}