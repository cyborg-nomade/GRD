using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Proposicoes;
using CPTM.GRD.Application.Contracts.Persistence.StrictSequenceControl;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.DTOs.Main.Proposicao.Validators;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Application.Features.Proposicoes.Requests.Commands;
using CPTM.GRD.Domain.AccessControl;
using CPTM.GRD.Domain.Proposicoes;
using MediatR;
using static CPTM.GRD.Application.Models.EmailSubjectsAndMessages;

namespace CPTM.GRD.Application.Features.Proposicoes.Handlers.Commands;

public class CreateProposicaoRequestHandler : IRequestHandler<CreateProposicaoRequest, ProposicaoDto>
{
    private readonly IProposicaoRepository _proposicaoRepository;
    private readonly IGroupRepository _groupRepository;
    private readonly IAuthenticationService _authenticationService;
    private readonly IMapper _mapper;
    private readonly IProposicaoStrictSequenceControl _sequenceControl;
    private readonly IUserRepository _userRepository;
    private readonly IEmailService _emailService;

    public CreateProposicaoRequestHandler(
        IProposicaoRepository proposicaoRepository,
        IGroupRepository groupRepository,
        IAuthenticationService authenticationService,
        IMapper mapper,
        IProposicaoStrictSequenceControl sequenceControl,
        IUserRepository userRepository,
        IEmailService emailService)
    {
        _proposicaoRepository = proposicaoRepository;
        _groupRepository = groupRepository;
        _authenticationService = authenticationService;
        _mapper = mapper;
        _sequenceControl = sequenceControl;
        _userRepository = userRepository;
        _emailService = emailService;
    }

    public async Task<ProposicaoDto> Handle(CreateProposicaoRequest request, CancellationToken cancellationToken)
    {
        var proposicaoDtoValidator =
            new CreateProposicaoDtoValidator(_groupRepository, _authenticationService, _userRepository);
        var proposicaoDtoValidationResult =
            await proposicaoDtoValidator.ValidateAsync(request.CreateProposicaoDto, cancellationToken);
        if (!proposicaoDtoValidationResult.IsValid)
        {
            throw new ValidationException(proposicaoDtoValidationResult);
        }

        var proposicao = _mapper.Map<Proposicao>(request.CreateProposicaoDto);
        proposicao.IdPrd = await _sequenceControl.GetNextIdPrd();
        proposicao.OnSaveProposicao();

        var addedProposicao = await _proposicaoRepository.Add(proposicao);

        await _emailService.SendEmail(proposicao, ProposicaoCreationSubject, ProposicaoCreationMessage(proposicao));

        return _mapper.Map<ProposicaoDto>(addedProposicao);
    }
}