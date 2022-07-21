using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Reunioes;
using CPTM.GRD.Application.DTOs.Main.Reuniao;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Application.Features.Reunioes.Requests.Commands;
using CPTM.GRD.Common;
using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Handlers.Commands;

public class CreateMemoriaPreviaReuniaoRequestHandler : IRequestHandler<CreateMemoriaPreviaReuniaoRequest, ReuniaoDto>
{
    private readonly IReuniaoRepository _reuniaoRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IFileManagerService _fileManagerService;
    private readonly IEmailService _emailService;

    public CreateMemoriaPreviaReuniaoRequestHandler(
        IReuniaoRepository reuniaoRepository,
        IUserRepository userRepository,
        IMapper mapper,
        IFileManagerService fileManagerService,
        IEmailService emailService)
    {
        _reuniaoRepository = reuniaoRepository;
        _userRepository = userRepository;
        _mapper = mapper;
        _fileManagerService = fileManagerService;
        _emailService = emailService;
    }

    public async Task<ReuniaoDto> Handle(CreateMemoriaPreviaReuniaoRequest request, CancellationToken cancellationToken)
    {
        var reuniao = await _reuniaoRepository.Get(request.Rid);
        if (reuniao == null) throw new NotFoundException(nameof(reuniao), request.Rid);

        var responsavel = await _userRepository.Get(request.Uid);
        if (responsavel == null) throw new NotFoundException(nameof(responsavel), request.Uid);

        reuniao.OnEmitMemoriaPrevia(responsavel, await _fileManagerService.CreateMemoriaPrevia(reuniao));

        var updatedReuniao = await _reuniaoRepository.Update(reuniao);

        await _emailService.SendEmailWithFile(updatedReuniao.ParticipantesPrevia.Select(p => p.User), reuniao,
            TipoArquivo.MemoriaPrevia);

        return _mapper.Map<ReuniaoDto>(updatedReuniao);
    }
}