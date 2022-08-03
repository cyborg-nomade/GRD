using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.DTOs.Main.Reuniao;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Application.Features.Reunioes.Requests.Commands;
using CPTM.GRD.Common;
using MediatR;
using static CPTM.GRD.Application.Models.EmailSubjectsAndMessages;

namespace CPTM.GRD.Application.Features.Reunioes.Handlers.Commands;

public class CreateAtaReuniaoRequestHandler : IRequestHandler<CreateAtaReuniaoRequest, ReuniaoDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IFileManagerService _fileManagerService;
    private readonly IEmailService _emailService;
    private readonly IAuthenticationService _authenticationService;

    public CreateAtaReuniaoRequestHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IFileManagerService fileManagerService,
        IEmailService emailService,
        IAuthenticationService authenticationService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _fileManagerService = fileManagerService;
        _emailService = emailService;
        _authenticationService = authenticationService;
    }

    public async Task<ReuniaoDto> Handle(CreateAtaReuniaoRequest request, CancellationToken cancellationToken)
    {
        _authenticationService.AuthorizeByMinLevel(request.RequestUser, AccessLevel.Grg);

        var reuniao = await _unitOfWork.ReuniaoRepository.Get(request.Rid);
        if (reuniao == null) throw new NotFoundException(nameof(reuniao), request.Rid);

        var claims = _authenticationService.GetTokenClaims(request.RequestUser);

        var responsavel = await _unitOfWork.UserRepository.Get(claims.Uid);
        if (responsavel == null) throw new NotFoundException(nameof(responsavel), claims.Uid);

        reuniao.OnEmitAta(responsavel, await _fileManagerService.CreateAta(reuniao));

        var updatedReuniao = await _unitOfWork.ReuniaoRepository.Update(reuniao);
        await _unitOfWork.Save();

        foreach (var proposicao in reuniao.Proposicoes)
        {
            await _emailService.SendEmail(proposicao, ProposicaoArquivamentoSubject,
                ProposicaoArquivamentoMessage(proposicao, responsavel));
        }

        await _emailService.SendEmailWithFile(updatedReuniao.ParticipantesPrevia.Select(p => p.User), reuniao,
            TipoArquivo.Ata);

        return _mapper.Map<ReuniaoDto>(updatedReuniao);
    }
}