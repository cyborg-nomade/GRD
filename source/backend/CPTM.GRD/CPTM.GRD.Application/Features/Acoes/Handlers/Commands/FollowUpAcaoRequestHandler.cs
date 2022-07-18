using AutoMapper;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Acoes;
using CPTM.GRD.Application.Contracts.Persistence.Reunioes;
using CPTM.GRD.Application.DTOs.Main.Acao;
using CPTM.GRD.Application.DTOs.Main.Mixed;
using CPTM.GRD.Application.DTOs.Main.Reuniao;
using CPTM.GRD.Application.Features.Acoes.Requests.Commands;
using MediatR;

namespace CPTM.GRD.Application.Features.Acoes.Handlers.Commands;

public class FollowUpAcaoRequestHandler : IRequestHandler<FollowUpAcaoRequest, AddAcaoToReuniaoDto>
{
    private readonly IAcaoRepository _acaoRepository;
    private readonly IReuniaoRepository _reuniaoRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public FollowUpAcaoRequestHandler(IAcaoRepository acaoRepository, IReuniaoRepository reuniaoRepository,
        IUserRepository userRepository,
        IMapper mapper)
    {
        _acaoRepository = acaoRepository;
        _reuniaoRepository = reuniaoRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<AddAcaoToReuniaoDto> Handle(FollowUpAcaoRequest request, CancellationToken cancellationToken)
    {
        var acaoExists = await _acaoRepository.Exists(request.Aid);
        var reuniaoExists = await _reuniaoRepository.Exists(request.Rid);
        var responsavelExists = await _userRepository.Exists(request.Uid);

        if (!(acaoExists || reuniaoExists || responsavelExists))
        {
            throw new Exception("Ação, reunião ou responsável não existe");
        }

        var acao = await _acaoRepository.Get(request.Aid);
        var reuniao = await _reuniaoRepository.Get(request.Rid);
        var responsavel = await _userRepository.Get(request.Uid);

        acao.FollowUp(reuniao, responsavel);

        var updatedAcao = await _acaoRepository.Update(acao);
        return new AddAcaoToReuniaoDto()
        {
            AcaoDto = _mapper.Map<AcaoDto>(updatedAcao),
            ReuniaoDto = _mapper.Map<ReuniaoDto>(reuniao)
        };
    }
}