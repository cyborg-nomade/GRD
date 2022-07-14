using AutoMapper;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.DTOs.Main.Reuniao;
using CPTM.GRD.Application.Features.Reunioes.Requests.Commands;
using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Handlers.Commands;

public class ChangeStatusReuniaoRequestHandler : IRequestHandler<ChangeStatusReuniaoRequest, ReuniaoDto>
{
    private readonly IReuniaoRepository _reuniaoRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public ChangeStatusReuniaoRequestHandler(IReuniaoRepository reuniaoRepository, IUserRepository userRepository,
        IMapper mapper)
    {
        _reuniaoRepository = reuniaoRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<ReuniaoDto> Handle(ChangeStatusReuniaoRequest request, CancellationToken cancellationToken)
    {
        var savedReuniao = await _reuniaoRepository.Get(request.Rid);
        var responsavel = await _userRepository.Get(request.Uid);

        savedReuniao.ChangeStatus(request.NewStatus, request.TipoLogReuniao, responsavel);

        var updatedReuniao = await _reuniaoRepository.Update(savedReuniao);

        return _mapper.Map<ReuniaoDto>(updatedReuniao);
    }
}