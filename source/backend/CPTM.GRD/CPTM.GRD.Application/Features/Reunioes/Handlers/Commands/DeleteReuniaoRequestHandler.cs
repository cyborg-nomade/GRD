using AutoMapper;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Logging;
using CPTM.GRD.Application.Contracts.Persistence.Reunioes;
using CPTM.GRD.Application.Features.Reunioes.Requests.Commands;
using CPTM.GRD.Common;
using CPTM.GRD.Domain.Logging;
using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Handlers.Commands;

public class DeleteReuniaoRequestHandler : IRequestHandler<DeleteReuniaoRequest>
{
    private readonly IReuniaoRepository _reuniaoRepository;
    private readonly ILogReuniaoRepository _logReuniaoRepository;
    private readonly IUserRepository _userRepository;

    public DeleteReuniaoRequestHandler(IReuniaoRepository reuniaoRepository, ILogReuniaoRepository logReuniaoRepository,
        IUserRepository userRepository, IMapper mapper)
    {
        _reuniaoRepository = reuniaoRepository;
        _logReuniaoRepository = logReuniaoRepository;
        _userRepository = userRepository;
    }

    public async Task<Unit> Handle(DeleteReuniaoRequest request, CancellationToken cancellationToken)
    {
        var reuniao = await _reuniaoRepository.Get(request.Rid);
        var responsavel = await _userRepository.Get(request.Uid);

        var removeLog = new LogReuniao(reuniao, TipoLogReuniao.Remocao, responsavel, "Remoção");
        await _logReuniaoRepository.Add(removeLog);

        await _reuniaoRepository.Delete(request.Rid);

        return Unit.Value;
    }
}