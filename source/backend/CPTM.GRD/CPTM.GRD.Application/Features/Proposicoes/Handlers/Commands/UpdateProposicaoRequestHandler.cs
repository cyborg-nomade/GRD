using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.Contracts.Persistence.StrictSequenceControl;
using CPTM.GRD.Application.Contracts.Util;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.DTOs.Main.Proposicao.Validators;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Application.Features.Proposicoes.Requests.Commands;
using CPTM.GRD.Common;
using CPTM.GRD.Domain.Proposicoes;
using MediatR;
using static CPTM.GRD.Application.Models.EmailSubjectsAndMessages;

namespace CPTM.GRD.Application.Features.Proposicoes.Handlers.Commands;

public class UpdateProposicaoRequestHandler : IRequestHandler<UpdateProposicaoRequest, ProposicaoDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IAuthenticationService _authenticationService;
    private readonly IProposicaoStrictSequenceControl _proposicaoStrictSequence;
    private readonly IEmailService _emailService;
    private readonly IDifferentiator _differentiator;

    public UpdateProposicaoRequestHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IAuthenticationService authenticationService,
        IProposicaoStrictSequenceControl proposicaoStrictSequence,
        IEmailService emailService,
        IDifferentiator differentiator)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _authenticationService = authenticationService;
        _proposicaoStrictSequence = proposicaoStrictSequence;
        _emailService = emailService;
        _differentiator = differentiator;
    }

    public async Task<ProposicaoDto> Handle(UpdateProposicaoRequest request, CancellationToken cancellationToken)
    {
        _authenticationService.AuthorizeByMinLevel(request.RequestUser, AccessLevel.Sub);

        var proposicaoDtoValidator =
            new UpdateProposicaoDtoValidator(_unitOfWork.ProposicaoRepository, _proposicaoStrictSequence);
        var proposicaoDtoValidationResult =
            await proposicaoDtoValidator.ValidateAsync(request.UpdateProposicaoDto, cancellationToken);

        if (!proposicaoDtoValidationResult.IsValid)
        {
            throw new ValidationException(proposicaoDtoValidationResult);
        }

        var savedProposicao = await _unitOfWork.ProposicaoRepository.Get(request.Pid);
        if (savedProposicao == null)
            throw new NotFoundException(nameof(savedProposicao), request.Pid);

        if (savedProposicao.Area != null)
            await _authenticationService.AuthorizeByMinGroups(request.RequestUser, savedProposicao.Area.Id);

        var claims = _authenticationService.GetTokenClaims(request.RequestUser);

        var responsavel = await _unitOfWork.UserRepository.Get(claims.Uid);
        if (responsavel == null) throw new NotFoundException(nameof(responsavel), claims.Uid);

        savedProposicao.OnUpdate(responsavel,
            _differentiator.GetDifferenceString(savedProposicao,
                _mapper.Map<Proposicao>(request.UpdateProposicaoDto)));

        _mapper.Map(request.UpdateProposicaoDto, savedProposicao);
        var updatedProposicao = await _unitOfWork.ProposicaoRepository.Update(savedProposicao);
        await _unitOfWork.Save();

        await _emailService.SendEmail(updatedProposicao, ProposicaoUpdateSubject,
            ProposicaoUpdateMessage(updatedProposicao, responsavel));

        return _mapper.Map<ProposicaoDto>(updatedProposicao);
    }
}