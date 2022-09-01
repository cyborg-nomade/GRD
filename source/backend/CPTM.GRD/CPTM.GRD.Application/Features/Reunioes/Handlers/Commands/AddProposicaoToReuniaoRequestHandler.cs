using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.DTOs.Main.Mixed;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.DTOs.Main.Reuniao;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Application.Features.Reunioes.Requests.Commands;
using CPTM.GRD.Common;
using MediatR;
using static CPTM.GRD.Application.Models.EmailSubjectsAndMessages;

namespace CPTM.GRD.Application.Features.Reunioes.Handlers.Commands;

public class
    AddProposicaoToReuniaoRequestHandler : IRequestHandler<AddProposicaoToReuniaoRequest, AddProposicaoToReuniaoDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IEmailService _emailService;
    private readonly IAuthenticationService _authenticationService;

    public AddProposicaoToReuniaoRequestHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IEmailService emailService,
        IAuthenticationService authenticationService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _emailService = emailService;
        _authenticationService = authenticationService;
    }

    public async Task<AddProposicaoToReuniaoDto> Handle(AddProposicaoToReuniaoRequest request,
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

        reuniao.AddProposicao(proposicao, responsavel);

        var updatedReuniao = await _unitOfWork.ReuniaoRepository.Update(reuniao);
        await _unitOfWork.Save();

        await _emailService.SendEmail(proposicao, ProposicaoAddToReuniaoSubject,
            ProposicaoAddToReuniaoMessage(proposicao, reuniao));

        return new AddProposicaoToReuniaoDto()
        {
            ProposicaoDto = _mapper.Map<ProposicaoDto>(proposicao),
            ReuniaoDto = _mapper.Map<ReuniaoDto>(updatedReuniao)
        };
    }
}