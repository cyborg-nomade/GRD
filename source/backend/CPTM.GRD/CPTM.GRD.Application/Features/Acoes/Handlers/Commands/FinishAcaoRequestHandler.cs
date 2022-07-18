using AutoMapper;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Acoes;
using CPTM.GRD.Application.DTOs.Main.Acao;
using CPTM.GRD.Application.Features.Acoes.Requests.Commands;
using MediatR;

namespace CPTM.GRD.Application.Features.Acoes.Handlers.Commands;

public class FinishAcaoRequestHandler : IRequestHandler<FinishAcaoRequest, AcaoDto>
{
    private readonly IAcaoRepository _acaoRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public FinishAcaoRequestHandler(IAcaoRepository acaoRepository, IUserRepository userRepository, IMapper mapper)
    {
        _acaoRepository = acaoRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<AcaoDto> Handle(FinishAcaoRequest request, CancellationToken cancellationToken)
    {
        var acaoExists = await _acaoRepository.Exists(request.Aid);
        var responsavelExists = await _userRepository.Exists(request.Uid);

        if (!(acaoExists || responsavelExists))
        {
            throw new Exception("Ação ou responsável não existe");
        }

        var acao = await _acaoRepository.Get(request.Aid);
        var responsavel = await _userRepository.Get(request.Uid);

        acao.Finish(request.Status, responsavel);

        var updatedAcao = await _acaoRepository.Update(acao);

        return _mapper.Map<AcaoDto>(updatedAcao);
    }
}