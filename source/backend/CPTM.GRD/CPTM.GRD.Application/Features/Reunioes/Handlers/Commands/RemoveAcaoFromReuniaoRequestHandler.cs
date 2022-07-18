using AutoMapper;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Acoes;
using CPTM.GRD.Application.Contracts.Persistence.Reunioes;
using CPTM.GRD.Application.DTOs.Main.Acao;
using CPTM.GRD.Application.DTOs.Main.Mixed;
using CPTM.GRD.Application.DTOs.Main.Reuniao;
using CPTM.GRD.Application.Features.Reunioes.Requests.Commands;
using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Handlers.Commands;

public class RemoveAcaoFromReuniaoRequestHandler : IRequestHandler<RemoveAcaoFromReuniaoRequest, AddAcaoToReuniaoDto>
{
    private readonly IAcaoRepository _acaoRepository;
    private readonly IReuniaoRepository _reuniaoRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public RemoveAcaoFromReuniaoRequestHandler(IAcaoRepository acaoRepository, IReuniaoRepository reuniaoRepository,
        IUserRepository userRepository,
        IMapper mapper)
    {
        _acaoRepository = acaoRepository;
        _reuniaoRepository = reuniaoRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<AddAcaoToReuniaoDto> Handle(RemoveAcaoFromReuniaoRequest request,
        CancellationToken cancellationToken)
    {
        var acao = await _acaoRepository.Get(request.Aid);
        var reuniao = await _reuniaoRepository.Get(request.Rid);
        var responsavel = await _userRepository.Get(request.Uid);

        reuniao.RemoveAcao(acao, responsavel);

        var updatedReuniao = await _reuniaoRepository.Update(reuniao);
        return new AddAcaoToReuniaoDto()
        {
            AcaoDto = _mapper.Map<AcaoDto>(acao),
            ReuniaoDto = _mapper.Map<ReuniaoDto>(updatedReuniao)
        };
    }
}