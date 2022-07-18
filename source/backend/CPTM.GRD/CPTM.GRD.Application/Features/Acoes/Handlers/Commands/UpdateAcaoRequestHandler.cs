using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Acoes;
using CPTM.GRD.Application.DTOs.Main.Acao;
using CPTM.GRD.Application.DTOs.Main.Acao.Validators;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Application.Features.Acoes.Requests.Commands;
using CPTM.GRD.Application.Util;
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

    public UpdateAcaoRequestHandler(IAcaoRepository acaoRepository, IMapper mapper, IUserRepository userRepository,
        IGroupRepository groupRepository, IAuthenticationService authenticationService)
    {
        _acaoRepository = acaoRepository;
        _mapper = mapper;
        _userRepository = userRepository;
        _groupRepository = groupRepository;
        _authenticationService = authenticationService;
    }

    public async Task<AcaoDto> Handle(UpdateAcaoRequest request, CancellationToken cancellationToken)
    {
        var responsavelExists = await _userRepository.Exists(request.Uid);

        if (!responsavelExists)
        {
            throw new NotFoundException("Usuário", responsavelExists);
        }

        var acaoDtoValidator =
            new AcaoDtoValidator(_groupRepository, _authenticationService, _userRepository, _acaoRepository);
        var acaoValidationResult = await acaoDtoValidator.ValidateAsync(request.AcaoDto, cancellationToken);

        if (!acaoValidationResult.IsValid)
        {
            throw new ValidationException(acaoValidationResult);
        }

        var savedAcao = await _acaoRepository.Get(request.AcaoDto.Id);
        var responsavel = await _userRepository.Get(request.Uid);

        savedAcao.OnUpdate(Differentiator.GetDifferenceString<Acao>(savedAcao, _mapper.Map<Acao>(request.AcaoDto)),
            responsavel);

        _mapper.Map(request.AcaoDto, savedAcao);

        var updatedAcao = await _acaoRepository.Update(savedAcao);

        return _mapper.Map<AcaoDto>(updatedAcao);
    }
}