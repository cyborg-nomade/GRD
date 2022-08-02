using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Reunioes;
using CPTM.GRD.Application.DTOs.Main.Acao;
using CPTM.GRD.Application.DTOs.Main.Acao.Validators;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Application.Features.Acoes.Requests.Commands;
using CPTM.GRD.Common;
using CPTM.GRD.Domain.Acoes;
using MediatR;
using static CPTM.GRD.Application.Models.EmailSubjectsAndMessages;

namespace CPTM.GRD.Application.Features.Acoes.Handlers.Commands;

public class CreateAcaoRequestHandler : IRequestHandler<CreateAcaoRequest, AcaoDto>
{
    private readonly IReuniaoRepository _reuniaoRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IAuthenticationService _authenticationService;
    private readonly IGroupRepository _groupRepository;
    private readonly IEmailService _emailService;

    public CreateAcaoRequestHandler(
        IReuniaoRepository reuniaoRepository,
        IUserRepository userRepository,
        IMapper mapper,
        IAuthenticationService authenticationService,
        IGroupRepository groupRepository,
        IEmailService emailService)
    {
        _reuniaoRepository = reuniaoRepository;
        _userRepository = userRepository;
        _mapper = mapper;
        _authenticationService = authenticationService;
        _groupRepository = groupRepository;
        _emailService = emailService;
    }

    public async Task<AcaoDto> Handle(CreateAcaoRequest request, CancellationToken cancellationToken)
    {
        _authenticationService.AuthorizeByMinLevel(request.RequestUser, AccessLevel.Grg);

        var acaoDtoValidator = new CreateAcaoDtoValidator(_groupRepository, _authenticationService, _userRepository);
        var acaoDtoValidationResult = await acaoDtoValidator.ValidateAsync(request.CreateAcaoDto, cancellationToken);
        if (!acaoDtoValidationResult.IsValid)
        {
            throw new ValidationException(acaoDtoValidationResult);
        }

        var acao = _mapper.Map<Acao>(request.CreateAcaoDto);

        var reuniao = await _reuniaoRepository.Get(request.Rid);
        if (reuniao == null) throw new NotFoundException(nameof(reuniao), request.Rid);

        var responsavel = await _userRepository.Get(request.Uid);
        if (responsavel == null) throw new NotFoundException(nameof(responsavel), request.Uid);

        reuniao.CreateAcao(acao, responsavel);

        await _reuniaoRepository.Update(reuniao);

        await _emailService.SendEmail(acao, reuniao, AcaoCreationSubject,
            AcaoCreationMessage(acao, reuniao));

        return _mapper.Map<AcaoDto>(acao);
    }
}