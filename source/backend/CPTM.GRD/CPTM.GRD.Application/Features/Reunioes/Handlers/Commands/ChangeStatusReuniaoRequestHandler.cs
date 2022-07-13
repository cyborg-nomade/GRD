using AutoMapper;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.DTOs.Main.Reuniao;
using CPTM.GRD.Application.Features.Reunioes.Requests.Commands;
using CPTM.GRD.Application.Persistence.Contracts.AccessControl;
using CPTM.GRD.Application.Persistence.Contracts.Logging;
using CPTM.GRD.Domain.Logging;
using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Handlers.Commands;

public class ChangeStatusReuniaoRequestHandler : IRequestHandler<ChangeStatusReuniaoRequest, ReuniaoDto>
{
    private readonly IReuniaoRepository _reuniaoRepository;
    private readonly ILogReuniaoRepository _logReuniaoRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public ChangeStatusReuniaoRequestHandler(IReuniaoRepository reuniaoRepository,
        ILogReuniaoRepository logReuniaoRepository, IUserRepository userRepository, IMapper mapper)
    {
        _reuniaoRepository = reuniaoRepository;
        _logReuniaoRepository = logReuniaoRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<ReuniaoDto> Handle(ChangeStatusReuniaoRequest request, CancellationToken cancellationToken)
    {
        var savedReuniao = await _reuniaoRepository.Get(request.Rid);

        var changeStatusLog = new LogReuniao()
        {
            Data = DateTime.Now,
            Tipo = request.TipoLogReuniao,
            Diferenca = $@"Changed status from {savedReuniao.Status} to {request.NewStatus}",
            ReuniaoId = $@"Número Reunião: {savedReuniao.NumeroReuniao}",
            UsuarioResp = await _userRepository.Get(request.Uid),
        };
        await _logReuniaoRepository.Add(changeStatusLog);
        savedReuniao.Logs.Add(changeStatusLog);

        savedReuniao.Status = request.NewStatus;
        var updatedReuniao = await _reuniaoRepository.Update(savedReuniao);

        return _mapper.Map<ReuniaoDto>(updatedReuniao);
    }
}