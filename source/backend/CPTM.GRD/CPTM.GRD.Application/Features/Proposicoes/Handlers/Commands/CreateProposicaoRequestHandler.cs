using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.Contracts.Persistence.StrictSequenceControl;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.DTOs.Main.Proposicao.Validators;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Application.Features.Proposicoes.Requests.Commands;
using CPTM.GRD.Common;
using CPTM.GRD.Domain.Proposicoes;
using MediatR;
using static CPTM.GRD.Application.Models.EmailSubjectsAndMessages;

namespace CPTM.GRD.Application.Features.Proposicoes.Handlers.Commands;

public class CreateProposicaoRequestHandler : IRequestHandler<CreateProposicaoRequest, ProposicaoDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthenticationService _authenticationService;
    private readonly IMapper _mapper;
    private readonly IProposicaoStrictSequenceControl _sequenceControl;
    private readonly IEmailService _emailService;

    public CreateProposicaoRequestHandler(
        IUnitOfWork unitOfWork,
        IAuthenticationService authenticationService,
        IMapper mapper,
        IProposicaoStrictSequenceControl sequenceControl,
        IEmailService emailService)
    {
        _unitOfWork = unitOfWork;
        _authenticationService = authenticationService;
        _mapper = mapper;
        _sequenceControl = sequenceControl;
        _emailService = emailService;
    }

    public async Task<ProposicaoDto> Handle(CreateProposicaoRequest request, CancellationToken cancellationToken)
    {
        _authenticationService.AuthorizeByMinLevel(request.RequestUser, AccessLevel.Sub);
        await _authenticationService.AuthorizeByExactUser(request.RequestUser, request.CreateProposicaoDto.Criador.Id);
        await _authenticationService.AuthorizeByMinGroups(request.RequestUser,
            request.CreateProposicaoDto.Area.Id);

        var proposicaoDtoValidator =
            new CreateProposicaoDtoValidator(_unitOfWork.GroupRepository, _authenticationService,
                _unitOfWork.UserRepository);
        var proposicaoDtoValidationResult =
            await proposicaoDtoValidator.ValidateAsync(request.CreateProposicaoDto, cancellationToken);
        if (!proposicaoDtoValidationResult.IsValid)
        {
            throw new ValidationException(proposicaoDtoValidationResult);
        }

        var proposicao = _mapper.Map<Proposicao>(request.CreateProposicaoDto);
        var idPrd = await _sequenceControl.GetNextIdPrd();
        var criador = await _unitOfWork.UserRepository.Get(proposicao.Criador.Id);
        if (criador == null) throw new NotFoundException(nameof(criador), request.CreateProposicaoDto.Criador);
        var areaSolicitante = await _unitOfWork.GroupRepository.Get(proposicao.Area.Id);
        if (areaSolicitante == null)
            throw new NotFoundException(nameof(areaSolicitante), request.CreateProposicaoDto.Area);

        proposicao.OnSaveProposicao(idPrd, criador, areaSolicitante);

        var addedProposicao = await _unitOfWork.ProposicaoRepository.Add(proposicao);
        await _unitOfWork.Save();

        await _emailService.SendEmail(proposicao, ProposicaoCreationSubject, ProposicaoCreationMessage(proposicao));

        return _mapper.Map<ProposicaoDto>(addedProposicao);
    }
}