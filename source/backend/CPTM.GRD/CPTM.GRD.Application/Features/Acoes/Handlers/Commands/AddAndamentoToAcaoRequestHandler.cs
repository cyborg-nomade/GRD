using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Acoes;
using CPTM.GRD.Application.DTOs.Main.Acao;
using CPTM.GRD.Application.DTOs.Main.Acao.Children.Validators;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Application.Features.Acoes.Requests.Commands;
using CPTM.GRD.Domain.Acoes.Children;
using MediatR;
using static CPTM.GRD.Application.Models.EmailSubjectsAndMessages;

namespace CPTM.GRD.Application.Features.Acoes.Handlers.Commands;

public class AddAndamentoToAcaoRequestHandler : IRequestHandler<AddAndamentoToAcaoRequest, AcaoDto>
{
    private readonly IAcaoRepository _acaoRepository;
    private readonly IMapper _mapper;
    private readonly IAuthenticationService _authenticationService;
    private readonly IUserRepository _userRepository;
    private readonly IEmailService _emailService;

    public AddAndamentoToAcaoRequestHandler(
        IAcaoRepository acaoRepository,
        IMapper mapper,
        IAuthenticationService authenticationService,
        IUserRepository userRepository,
        IEmailService emailService)
    {
        _acaoRepository = acaoRepository;
        _mapper = mapper;
        _authenticationService = authenticationService;
        _userRepository = userRepository;
        _emailService = emailService;
    }

    public async Task<AcaoDto> Handle(AddAndamentoToAcaoRequest request, CancellationToken cancellationToken)
    {
        var andamentoDtoValidator = new IAndamentoDtoValidator(_authenticationService, _userRepository);
        var andamentoValidationResult =
            await andamentoDtoValidator.ValidateAsync(request.AndamentoDto, cancellationToken);

        if (!andamentoValidationResult.IsValid)
        {
            throw new ValidationException(andamentoValidationResult);
        }

        var acao = await _acaoRepository.Get(request.Aid);
        if (acao == null) throw new NotFoundException(nameof(acao), request.Aid);

        _authenticationService.AuthorizeByExactUser(request.RequestUser, acao.Responsavel);

        var andamento = _mapper.Map<Andamento>(request.AndamentoDto);
        acao.AddAndamento(andamento);

        var updatedAcao = await _acaoRepository.Update(acao);

        foreach (var reuniao in acao.Reunioes)
        {
            await _emailService.SendEmail(acao, reuniao, AcaoAddAndamentoSubject,
                AcaoAddAndamentoMessage(acao, andamento));
        }

        return _mapper.Map<AcaoDto>(updatedAcao);
    }
}