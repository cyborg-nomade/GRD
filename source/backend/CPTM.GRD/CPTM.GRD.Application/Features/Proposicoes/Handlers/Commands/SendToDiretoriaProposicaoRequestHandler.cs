using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Application.Features.Proposicoes.Requests.Commands;
using CPTM.GRD.Common;
using MediatR;
using static CPTM.GRD.Application.Models.EmailSubjectsAndMessages;


namespace CPTM.GRD.Application.Features.Proposicoes.Handlers.Commands;

public class SendToDiretoriaProposicaoRequestHandler : IRequestHandler<SendToDiretoriaProposicaoRequest, ProposicaoDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IAuthenticationService _authenticationService;
    private readonly IEmailService _emailService;

    public SendToDiretoriaProposicaoRequestHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IAuthenticationService authenticationService,
        IEmailService emailService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _authenticationService = authenticationService;
        _emailService = emailService;
    }

    public async Task<ProposicaoDto> Handle(SendToDiretoriaProposicaoRequest request,
        CancellationToken cancellationToken)
    {
        _authenticationService.AuthorizeByMinLevel(request.RequestUser, AccessLevel.Gerente);

        var proposicao = await _unitOfWork.ProposicaoRepository.Get(request.Pid);
        if (proposicao == null) throw new NotFoundException(nameof(proposicao), request.Pid);

        await _authenticationService.AuthorizeByMinGroups(request.RequestUser, proposicao.Area.Id);

        var claims = _authenticationService.GetTokenClaims(request.RequestUser);

        var responsavel = await _unitOfWork.UserRepository.Get(claims.Uid);
        if (responsavel == null) throw new NotFoundException(nameof(responsavel), claims.Uid);

        proposicao.SendToDiretoriaResponsavelApproval(responsavel);

        var updatedProposicao = await _unitOfWork.ProposicaoRepository.Update(proposicao);
        await _unitOfWork.Save();

        await _emailService.SendEmail(updatedProposicao, ProposicaoSendToDiretoriaApprovalSubject,
            ProposicaoSendToDiretorialApprovalMessage(updatedProposicao, responsavel));

        return _mapper.Map<ProposicaoDto>(updatedProposicao);
    }
}