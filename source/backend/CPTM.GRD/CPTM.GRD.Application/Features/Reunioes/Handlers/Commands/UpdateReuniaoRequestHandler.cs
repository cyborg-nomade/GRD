using AutoMapper;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Logging;
using CPTM.GRD.Application.DTOs.Main.Reuniao;
using CPTM.GRD.Application.Features.Reunioes.Requests.Commands;
using CPTM.GRD.Application.Util;
using CPTM.GRD.Common;
using CPTM.GRD.Domain;
using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Handlers.Commands;

public class UpdateReuniaoRequestHandler : IRequestHandler<UpdateReuniaoRequest, ReuniaoDto>
{
    private readonly IReuniaoRepository _reuniaoRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UpdateReuniaoRequestHandler(IReuniaoRepository reuniaoRepository, ILogReuniaoRepository logReuniaoRepository,
        IUserRepository userRepository, IMapper mapper)
    {
        _reuniaoRepository = reuniaoRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<ReuniaoDto> Handle(UpdateReuniaoRequest request, CancellationToken cancellationToken)
    {
        var savedReuniao = await _reuniaoRepository.Get(request.ReuniaoDto.Id);
        var responsavel = await _userRepository.Get(request.Uid);

        savedReuniao.GenerateReuniaoLog(TipoLogReuniao.Edicao, responsavel, Differentiator.GetDifferenceString<Reuniao>(
            savedReuniao,
            _mapper.Map<Reuniao>(request.ReuniaoDto)));

        _mapper.Map(request.ReuniaoDto, savedReuniao);

        var updatedReuniao = await _reuniaoRepository.Update(savedReuniao);

        return _mapper.Map<ReuniaoDto>(updatedReuniao);
    }
}