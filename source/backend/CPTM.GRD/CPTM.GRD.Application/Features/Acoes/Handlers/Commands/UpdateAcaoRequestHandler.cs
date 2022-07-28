using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Acoes;
using CPTM.GRD.Application.Contracts.Util;
using CPTM.GRD.Application.DTOs.Main.Acao;
using CPTM.GRD.Application.DTOs.Main.Acao.Validators;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Application.Features.Acoes.Requests.Commands;
using CPTM.GRD.Domain.Acoes;
using MediatR;

namespace CPTM.GRD.Application.Features.Acoes.Handlers.Commands;

public class UpdateAcaoRequestHandler : IRequestHandler<UpdateAcaoRequest, AcaoDto>
{
    private readonly IAcaoRepository _acaoRepository;
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IGroupRepository _groupRepository;
    private readonly IAuthenticationService _authenticationService;
    private readonly IDifferentiator _differentiator;

    public UpdateAcaoRequestHandler(
        IAcaoRepository acaoRepository,
        IMapper mapper,
        IUserRepository userRepository,
        IGroupRepository groupRepository,
        IAuthenticationService authenticationService,
        IDifferentiator differentiator)
    {
        _acaoRepository = acaoRepository;
        _mapper = mapper;
        _userRepository = userRepository;
        _groupRepository = groupRepository;
        _authenticationService = authenticationService;
        _differentiator = differentiator;
    }

    public async Task<AcaoDto> Handle(UpdateAcaoRequest request, CancellationToken cancellationToken)
    {
        var acaoDtoValidator =
            new UpdateAcaoDtoValidator(_groupRepository, _authenticationService, _userRepository, _acaoRepository);
        var acaoDtoValidationResult = await acaoDtoValidator.ValidateAsync(request.UpdateAcaoDto, cancellationToken);
        if (!acaoDtoValidationResult.IsValid)
        {
            throw new ValidationException(acaoDtoValidationResult);
        }

        var savedAcao = await _acaoRepository.Get(request.Aid);
        if (savedAcao == null) throw new NotFoundException(nameof(savedAcao), request.Aid);

        var responsavel = await _userRepository.Get(request.Uid);
        if (responsavel == null) throw new NotFoundException(nameof(responsavel), request.Uid);

        savedAcao.OnUpdate(
            _differentiator.GetDifferenceString<Acao>(savedAcao, _mapper.Map<Acao>(request.UpdateAcaoDto)),
            responsavel);

        _mapper.Map(request.UpdateAcaoDto, savedAcao);
        var updatedAcao = await _acaoRepository.Update(savedAcao);

        return _mapper.Map<AcaoDto>(updatedAcao);
    }
}