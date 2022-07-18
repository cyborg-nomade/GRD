using AutoMapper;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Logging;
using CPTM.GRD.Application.Contracts.Persistence.StrictSequenceControl;
using CPTM.GRD.Application.DTOs.Main.Reuniao;
using CPTM.GRD.Application.Features.Reunioes.Requests.Commands;
using CPTM.GRD.Common;
using CPTM.GRD.Domain.Reunioes;
using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Handlers.Commands;

public class CreateReuniaoRequestHandler : IRequestHandler<CreateReuniaoRequest, ReuniaoDto>
{
    private readonly IReuniaoRepository _reuniaoRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IReuniaoStrictSequenceControl _sequenceControl;

    public CreateReuniaoRequestHandler(IReuniaoRepository reuniaoRepository, IUserRepository userRepository,
        ILogReuniaoRepository logReuniaoRepository, IMapper mapper,
        IReuniaoStrictSequenceControl sequenceControl)
    {
        _reuniaoRepository = reuniaoRepository;
        _userRepository = userRepository;
        _mapper = mapper;
        _sequenceControl = sequenceControl;
    }

    public async Task<ReuniaoDto> Handle(CreateReuniaoRequest request, CancellationToken cancellationToken)
    {
        var reuniao = _mapper.Map<Reuniao>(request.CreateReuniaoDto);
        reuniao.NumeroReuniao = await _sequenceControl.GetNextNumeroReuniao();

        var responsavel = await _userRepository.Get(request.Uid);

        reuniao.OnSave(responsavel);

        var addedReuniao = await _reuniaoRepository.Add(reuniao);

        return _mapper.Map<ReuniaoDto>(addedReuniao);
    }
}