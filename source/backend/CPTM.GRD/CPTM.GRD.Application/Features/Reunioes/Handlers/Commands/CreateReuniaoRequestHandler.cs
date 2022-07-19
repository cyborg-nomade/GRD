using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Acoes;
using CPTM.GRD.Application.Contracts.Persistence.Proposicoes;
using CPTM.GRD.Application.Contracts.Persistence.Proposicoes.Children;
using CPTM.GRD.Application.Contracts.Persistence.Reunioes;
using CPTM.GRD.Application.Contracts.Persistence.Reunioes.Children;
using CPTM.GRD.Application.Contracts.Persistence.StrictSequenceControl;
using CPTM.GRD.Application.DTOs.Main.Reuniao;
using CPTM.GRD.Application.DTOs.Main.Reuniao.Validators;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Application.Features.Reunioes.Requests.Commands;
using CPTM.GRD.Domain.Reunioes;
using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Handlers.Commands;

public class CreateReuniaoRequestHandler : IRequestHandler<CreateReuniaoRequest, ReuniaoDto>
{
    private readonly IReuniaoRepository _reuniaoRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IReuniaoStrictSequenceControl _reuniaoSequenceControl;
    private readonly IGroupRepository _groupRepository;
    private readonly IAuthenticationService _authenticationService;
    private readonly IAcaoRepository _acaoRepository;
    private readonly IVotoRepository _votoRepository;
    private readonly IParticipanteRepository _participanteRepository;
    private readonly IProposicaoRepository _proposicaoRepository;
    private readonly IProposicaoStrictSequenceControl _proposicaoStrictSequence;

    public CreateReuniaoRequestHandler(IReuniaoRepository reuniaoRepository, IUserRepository userRepository,
        IMapper mapper,
        IReuniaoStrictSequenceControl reuniaoSequenceControl, IGroupRepository groupRepository,
        IAuthenticationService authenticationService, IAcaoRepository acaoRepository, IVotoRepository votoRepository,
        IParticipanteRepository participanteRepository, IProposicaoRepository proposicaoRepository,
        IProposicaoStrictSequenceControl proposicaoStrictSequence)
    {
        _reuniaoRepository = reuniaoRepository;
        _userRepository = userRepository;
        _mapper = mapper;
        _reuniaoSequenceControl = reuniaoSequenceControl;
        _groupRepository = groupRepository;
        _authenticationService = authenticationService;
        _acaoRepository = acaoRepository;
        _votoRepository = votoRepository;
        _participanteRepository = participanteRepository;
        _proposicaoRepository = proposicaoRepository;
        _proposicaoStrictSequence = proposicaoStrictSequence;
    }

    public async Task<ReuniaoDto> Handle(CreateReuniaoRequest request, CancellationToken cancellationToken)
    {
        var reuniaoDtoValidator = new IReuniaoDtoValidator(_groupRepository, _authenticationService, _userRepository,
            _acaoRepository, _votoRepository, _participanteRepository, _reuniaoRepository, _reuniaoSequenceControl,
            _proposicaoRepository, _proposicaoStrictSequence);
        var reuniaoDtoValidationResult =
            await reuniaoDtoValidator.ValidateAsync(request.CreateReuniaoDto, cancellationToken);
        if (!reuniaoDtoValidationResult.IsValid)
        {
            throw new ValidationException(reuniaoDtoValidationResult);
        }

        var reuniao = _mapper.Map<Reuniao>(request.CreateReuniaoDto);
        reuniao.NumeroReuniao = await _reuniaoSequenceControl.GetNextNumeroReuniao();

        var responsavel = await _userRepository.Get(request.Uid);
        if (responsavel == null) throw new NotFoundException(nameof(responsavel), request.Uid);

        reuniao.OnSave(responsavel);

        var addedReuniao = await _reuniaoRepository.Add(reuniao);

        return _mapper.Map<ReuniaoDto>(addedReuniao);
    }
}