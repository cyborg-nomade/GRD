using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Reunioes;
using CPTM.GRD.Application.DTOs.Main.Reuniao;
using CPTM.GRD.Application.Features.Reunioes.Requests.Commands;
using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Handlers.Commands;

public class
    CreatePautaDefinitivaReuniaoRequestHandler : IRequestHandler<CreatePautaDefinitivaReuniaoRequest, ReuniaoDto>
{
    private readonly IReuniaoRepository _reuniaoRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IFileManagerService _fileManagerService;

    public CreatePautaDefinitivaReuniaoRequestHandler(IReuniaoRepository reuniaoRepository,
        IUserRepository userRepository, IMapper mapper,
        IFileManagerService fileManagerService)
    {
        _reuniaoRepository = reuniaoRepository;
        _userRepository = userRepository;
        _mapper = mapper;
        _fileManagerService = fileManagerService;
    }

    public async Task<ReuniaoDto> Handle(CreatePautaDefinitivaReuniaoRequest request,
        CancellationToken cancellationToken)
    {
        var reuniao = await _reuniaoRepository.Get(request.Rid);
        var responsavel = await _userRepository.Get(request.Uid);

        reuniao.OnEmitPautaDefinitiva(responsavel, await _fileManagerService.CreatePautaDefinitiva(reuniao));

        var updatedReuniao = await _reuniaoRepository.Update(reuniao);
        return _mapper.Map<ReuniaoDto>(updatedReuniao);
    }
}