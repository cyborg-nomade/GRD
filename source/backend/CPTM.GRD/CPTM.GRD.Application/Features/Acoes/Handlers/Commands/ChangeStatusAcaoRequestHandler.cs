using AutoMapper;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.DTOs.Main.Acao;
using CPTM.GRD.Application.Features.Acoes.Requests.Commands;
using CPTM.GRD.Application.Persistence.Contracts.AccessControl;
using CPTM.GRD.Application.Persistence.Contracts.Logging;
using CPTM.GRD.Domain.Logging;
using MediatR;

namespace CPTM.GRD.Application.Features.Acoes.Handlers.Commands;

public class ChangeStatusAcaoRequestHandler : IRequestHandler<ChangeStatusAcaoRequest, AcaoDto>
{
    private readonly IAcaoRepository _acaoRepository;
    private readonly ILogAcaoRepository _logAcaoRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public ChangeStatusAcaoRequestHandler(IAcaoRepository acaoRepository, ILogAcaoRepository logAcaoRepository,
        IUserRepository userRepository, IMapper mapper)
    {
        _acaoRepository = acaoRepository;
        _logAcaoRepository = logAcaoRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<AcaoDto> Handle(ChangeStatusAcaoRequest request, CancellationToken cancellationToken)
    {
        var savedAcao = await _acaoRepository.Get(request.Aid);

        var changeStatusLog = new LogAcao()
        {
            Data = DateTime.Now,
            Tipo = request.TipoLogAcao,
            Diferenca = $@"Mudança de status de {savedAcao.Status} para {request.NewStatus}",
            AcaoId = $@"ID Ação {savedAcao.Id}",
            UsuarioResp = await _userRepository.Get(request.Uid)
        };
        await _logAcaoRepository.Add(changeStatusLog);
        savedAcao.Logs.Add(changeStatusLog);

        savedAcao.Status = request.NewStatus;

        var updatedAcao = await _acaoRepository.Update(savedAcao);

        return _mapper.Map<AcaoDto>(updatedAcao);
    }
}