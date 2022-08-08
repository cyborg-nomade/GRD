using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Application.Features.Reunioes.Requests.Commands;
using CPTM.GRD.Common;
using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Handlers.Commands;

public class
    CreateResolucaoDiretoriaProposicaoReuniaoRequestHandler : IRequestHandler<
        CreateResolucaoDiretoriaProposicaoReuniaoRequest, ProposicaoDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IFileManagerService _fileManagerService;
    private readonly IEmailService _emailService;
    private readonly IAuthenticationService _authenticationService;

    public CreateResolucaoDiretoriaProposicaoReuniaoRequestHandler(
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

    public async Task<ProposicaoDto> Handle(CreateResolucaoDiretoriaProposicaoReuniaoRequest request,
        CancellationToken cancellationToken)
    {
        _authenticationService.AuthorizeByMinLevel(request.RequestUser, AccessLevel.Grg);

        var proposicao = await _unitOfWork.ProposicaoRepository.Get(request.Pid);
        if (proposicao == null) throw new NotFoundException(nameof(proposicao), request.Pid);

        var reuniao = await _unitOfWork.ReuniaoRepository.Get(request.Rid);
        if (reuniao == null) throw new NotFoundException(nameof(reuniao), request.Rid);

        var claims = _authenticationService.GetTokenClaims(request.RequestUser);

        var responsavel = await _unitOfWork.UserRepository.Get(claims.Uid);
        if (responsavel == null) throw new NotFoundException(nameof(responsavel), claims.Uid);

        reuniao.OnEmitProposicaoResolucaoDiretoria(request.Pid, responsavel,
            await _fileManagerService.CreateResolucaoDiretoria(reuniao, proposicao));

        var updatedProposicao = await _unitOfWork.ProposicaoRepository.Update(proposicao);
        await _unitOfWork.Save();

        await _emailService.SendEmailWithFile(updatedProposicao);

        return _mapper.Map<ProposicaoDto>(updatedProposicao);
    }
}