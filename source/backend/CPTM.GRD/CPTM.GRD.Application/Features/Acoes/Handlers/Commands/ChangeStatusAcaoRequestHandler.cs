using AutoMapper;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Logging;
using CPTM.GRD.Application.DTOs.Main.Acao;
using CPTM.GRD.Application.Features.Acoes.Requests.Commands;
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

        savedAcao.ChangeStatus(request.NewStatus, request.TipoLogAcao);

        var updatedAcao = await _acaoRepository.Update(savedAcao);

        return _mapper.Map<AcaoDto>(updatedAcao);
    }
}