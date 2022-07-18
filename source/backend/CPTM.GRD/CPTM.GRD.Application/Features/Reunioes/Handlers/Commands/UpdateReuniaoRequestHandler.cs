using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Acoes;
using CPTM.GRD.Application.Contracts.Persistence.Logging;
using CPTM.GRD.Application.Contracts.Persistence.Proposicoes.Children;
using CPTM.GRD.Application.Contracts.Persistence.Reunioes;
using CPTM.GRD.Application.Contracts.Persistence.Reunioes.Children;
using CPTM.GRD.Application.Contracts.Persistence.StrictSequenceControl;
using CPTM.GRD.Application.DTOs.Main.Reuniao;
using CPTM.GRD.Application.DTOs.Main.Reuniao.Validators;
using CPTM.GRD.Application.Features.Reunioes.Requests.Commands;
using CPTM.GRD.Application.Util;
using CPTM.GRD.Domain.Reunioes;
using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Handlers.Commands;

public class UpdateReuniaoRequestHandler : IRequestHandler<UpdateReuniaoRequest, ReuniaoDto>
{
    private readonly IReuniaoRepository _reuniaoRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IGroupRepository _groupRepository;
    private readonly IAuthenticationService _authenticationService;
    private readonly IAcaoRepository _acaoRepository;
    private readonly IVotoRepository _votoRepository;
    private readonly IParticipanteRepository _participanteRepository;
    private readonly IReuniaoStrictSequenceControl _strictSequence;

    public UpdateReuniaoRequestHandler(IReuniaoRepository reuniaoRepository, ILogReuniaoRepository logReuniaoRepository,
        IUserRepository userRepository, IMapper mapper, IGroupRepository groupRepository,
        IAuthenticationService authenticationService, IAcaoRepository acaoRepository, IVotoRepository votoRepository,
        IParticipanteRepository participanteRepository, IReuniaoStrictSequenceControl strictSequence)
    {
        _reuniaoRepository = reuniaoRepository;
        _userRepository = userRepository;
        _mapper = mapper;
        _groupRepository = groupRepository;
        _authenticationService = authenticationService;
        _acaoRepository = acaoRepository;
        _votoRepository = votoRepository;
        _participanteRepository = participanteRepository;
        _strictSequence = strictSequence;
    }

    public async Task<ReuniaoDto> Handle(UpdateReuniaoRequest request, CancellationToken cancellationToken)
    {
        var responsavelExists = await _userRepository.Exists(request.Uid);
        var reuniaoValidator = new ReuniaoDtoValidator(_groupRepository, _authenticationService, _userRepository,
            _acaoRepository, _votoRepository, _participanteRepository, _reuniaoRepository, _strictSequence);
        var reuniaoValidationResult = await reuniaoValidator.ValidateAsync(request.ReuniaoDto, cancellationToken);

        if (!(reuniaoValidationResult.IsValid || responsavelExists))
        {
            throw new Exception("Objetos inválidos");
        }

        var savedReuniao = await _reuniaoRepository.Get(request.ReuniaoDto.Id);
        var responsavel = await _userRepository.Get(request.Uid);

        savedReuniao.OnUpdate(responsavel, Differentiator.GetDifferenceString<Reuniao>(
            savedReuniao,
            _mapper.Map<Reuniao>(request.ReuniaoDto)));

        _mapper.Map(request.ReuniaoDto, savedReuniao);

        var updatedReuniao = await _reuniaoRepository.Update(savedReuniao);

        return _mapper.Map<ReuniaoDto>(updatedReuniao);
    }
}