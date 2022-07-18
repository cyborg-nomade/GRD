using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Acoes;
using CPTM.GRD.Application.Contracts.Persistence.Proposicoes.Children;
using CPTM.GRD.Application.Contracts.Persistence.Reunioes;
using CPTM.GRD.Application.Contracts.Persistence.Reunioes.Children;
using CPTM.GRD.Application.Contracts.Persistence.StrictSequenceControl;
using CPTM.GRD.Application.DTOs.Main.Reuniao;
using CPTM.GRD.Application.DTOs.Main.Reuniao.Validators;
using CPTM.GRD.Application.Features.Reunioes.Requests.Commands;
using CPTM.GRD.Domain.Reunioes;
using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Handlers.Commands;

public class CreateReuniaoRequestHandler : IRequestHandler<CreateReuniaoRequest, ReuniaoDto>
{
    private readonly IReuniaoRepository _reuniaoRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IReuniaoStrictSequenceControl _sequenceControl;
    private readonly IGroupRepository _groupRepository;
    private readonly IAuthenticationService _authenticationService;
    private readonly IAcaoRepository _acaoRepository;
    private readonly IVotoRepository _votoRepository;
    private readonly IParticipanteRepository _participanteRepository;

    public CreateReuniaoRequestHandler(IReuniaoRepository reuniaoRepository, IUserRepository userRepository,
        IMapper mapper,
        IReuniaoStrictSequenceControl sequenceControl, IGroupRepository groupRepository,
        IAuthenticationService authenticationService, IAcaoRepository acaoRepository, IVotoRepository votoRepository,
        IParticipanteRepository participanteRepository)
    {
        _reuniaoRepository = reuniaoRepository;
        _userRepository = userRepository;
        _mapper = mapper;
        _sequenceControl = sequenceControl;
        _groupRepository = groupRepository;
        _authenticationService = authenticationService;
        _acaoRepository = acaoRepository;
        _votoRepository = votoRepository;
        _participanteRepository = participanteRepository;
    }

    public async Task<ReuniaoDto> Handle(CreateReuniaoRequest request, CancellationToken cancellationToken)
    {
        var responsavelExists = await _userRepository.Exists(request.Uid);
        var reuniaoValidator = new IReuniaoDtoValidator(_groupRepository, _authenticationService, _userRepository,
            _acaoRepository, _votoRepository, _participanteRepository);
        var reuniaoValidationResult = await reuniaoValidator.ValidateAsync(request.CreateReuniaoDto, cancellationToken);

        if (!(reuniaoValidationResult.IsValid || responsavelExists))
        {
            throw new Exception("Objetos inválidos");
        }

        var reuniao = _mapper.Map<Reuniao>(request.CreateReuniaoDto);
        reuniao.NumeroReuniao = await _sequenceControl.GetNextNumeroReuniao();

        var responsavel = await _userRepository.Get(request.Uid);

        reuniao.OnSave(responsavel);

        var addedReuniao = await _reuniaoRepository.Add(reuniao);

        return _mapper.Map<ReuniaoDto>(addedReuniao);
    }
}