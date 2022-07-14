using AutoMapper;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.Features.Acoes.Requests.Commands;
using CPTM.GRD.Application.Persistence.Contracts.AccessControl;
using CPTM.GRD.Application.Persistence.Contracts.Logging;
using CPTM.GRD.Common;
using CPTM.GRD.Domain.Logging;
using MediatR;

namespace CPTM.GRD.Application.Features.Acoes.Handlers.Commands;

public class DeleteAcaoRequestHandler : IRequestHandler<DeleteAcaoRequest, Unit>
{
    private readonly IAcaoRepository _acaoRepository;
    private readonly ILogAcaoRepository _logAcaoRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public DeleteAcaoRequestHandler(IAcaoRepository acaoRepository, ILogAcaoRepository logAcaoRepository,
        IUserRepository userRepository, IMapper mapper)
    {
        _acaoRepository = acaoRepository;
        _logAcaoRepository = logAcaoRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(DeleteAcaoRequest request, CancellationToken cancellationToken)
    {
        var acao = await _acaoRepository.Get(request.Aid);

        var removeLog = new LogAcao()
        {
            Data = DateTime.Now,
            Tipo = TipoLogAcao.Remocao,
            Diferenca = "Remoção",
            AcaoId = $@"WAS ID Ação {acao.Id}",
            UsuarioResp = await _userRepository.Get(request.Uid),
        };
        await _logAcaoRepository.Add(removeLog);

        await _acaoRepository.Delete(request.Aid);

        return Unit.Value;
    }
}