using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Proposicoes;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Application.Features.Proposicoes.Requests.Commands;
using CPTM.GRD.Common;
using MediatR;
using static CPTM.GRD.Application.Models.EmailSubjectsAndMessages;

namespace CPTM.GRD.Application.Features.Proposicoes.Handlers.Commands;

public class
    DiretoriaResponsavelRepproveProposicaoRequestHandler : IRequestHandler<DiretoriaResponsavelRepproveProposicaoRequest
        , ProposicaoDto>
{
    private readonly IProposicaoRepository _proposicaoRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IEmailService _emailService;
    private readonly IAuthenticationService _authenticationService;

    public DiretoriaResponsavelRepproveProposicaoRequestHandler(
        IProposicaoRepository proposicaoRepository,
        IUserRepository userRepository,
        IMapper mapper,
        IEmailService emailService,
        IAuthenticationService authenticationService)
    {
        _proposicaoRepository = proposicaoRepository;
        _userRepository = userRepository;
        _mapper = mapper;
        _emailService = emailService;
        _authenticationService = authenticationService;
    }

    public async Task<ProposicaoDto> Handle(DiretoriaResponsavelRepproveProposicaoRequest request,
        CancellationToken cancellationToken)
    {
        _authenticationService.AuthorizeByMinLevel(request.RequestUser, AccessLevel.AssessorDiretoria);

        var proposicao = await _proposicaoRepository.Get(request.Pid);
        if (proposicao == null) throw new NotFoundException(nameof(proposicao), request.Pid);

        await _authenticationService.AuthorizeByMinGroups(request.RequestUser, proposicao.AreaSolicitante.Id);

        var claims = _authenticationService.GetTokenClaims(request.RequestUser);

        var responsavel = await _userRepository.Get(claims.Uid);
        if (responsavel == null) throw new NotFoundException(nameof(responsavel), claims.Uid);

        proposicao.DiretoriaResponsavelRepproveProposicao(responsavel, request.MotivoReprovacao);

        var updatedProposicao = await _proposicaoRepository.Update(proposicao);

        await _emailService.SendEmail(updatedProposicao, ProposicaoDirRespRepproveSubject,
            ProposicaoDirRespRepproveMessage(updatedProposicao, responsavel));

        return _mapper.Map<ProposicaoDto>(updatedProposicao);
    }
}