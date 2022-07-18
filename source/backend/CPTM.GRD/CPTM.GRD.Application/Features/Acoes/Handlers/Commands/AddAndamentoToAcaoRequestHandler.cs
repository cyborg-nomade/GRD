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

namespace CPTM.GRD.Application.Features.Acoes.Handlers.Commands;

public class AddAndamentoToAcaoRequestHandler : IRequestHandler<AddAndamentoToAcaoRequest, AcaoDto>
{
    private readonly IAcaoRepository _acaoRepository;
    private readonly IMapper _mapper;
    private readonly IAuthenticationService _authenticationService;
    private readonly IUserRepository _userRepository;

    public AddAndamentoToAcaoRequestHandler(IAcaoRepository acaoRepository, IMapper mapper,
        IAuthenticationService authenticationService, IUserRepository userRepository)
    {
        _acaoRepository = acaoRepository;
        _mapper = mapper;
        _authenticationService = authenticationService;
        _userRepository = userRepository;
    }

    public async Task<AcaoDto> Handle(AddAndamentoToAcaoRequest request, CancellationToken cancellationToken)
    {
        var acaoExists = await _acaoRepository.Exists(request.Aid);

        if (!acaoExists)
        {
            throw new NotFoundException("Ação", acaoExists);
        }

        var andamentoDtoValidator = new IAndamentoDtoValidator(_authenticationService, _userRepository);
        var andamentoValidationResult =
            await andamentoDtoValidator.ValidateAsync(request.AndamentoDto, cancellationToken);

        if (!andamentoValidationResult.IsValid)
        {
            throw new ValidationException(andamentoValidationResult);
        }

        var acao = await _acaoRepository.Get(request.Aid);
        var andamento = _mapper.Map<Andamento>(request.AndamentoDto);

        acao.AddAndamento(andamento);

        var updatedAcao = await _acaoRepository.Update(acao);
        return _mapper.Map<AcaoDto>(updatedAcao);
    }
}