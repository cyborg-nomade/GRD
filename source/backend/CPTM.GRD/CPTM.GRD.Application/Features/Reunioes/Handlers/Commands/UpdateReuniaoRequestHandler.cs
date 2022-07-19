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
    private readonly IReuniaoStrictSequenceControl _reuniaoStrictSequence;
    private readonly IProposicaoRepository _proposicaoRepository;
    private readonly IProposicaoStrictSequenceControl _proposicaoStrictSequence;

    public UpdateReuniaoRequestHandler(IReuniaoRepository reuniaoRepository,
        IUserRepository userRepository, IMapper mapper, IGroupRepository groupRepository,
        IAuthenticationService authenticationService, IAcaoRepository acaoRepository, IVotoRepository votoRepository,
        IParticipanteRepository participanteRepository, IReuniaoStrictSequenceControl reuniaoStrictSequence,
        IProposicaoRepository proposicaoRepository, IProposicaoStrictSequenceControl proposicaoStrictSequence)
    {
        _reuniaoRepository = reuniaoRepository;
        _userRepository = userRepository;
        _mapper = mapper;
        _groupRepository = groupRepository;
        _authenticationService = authenticationService;
        _acaoRepository = acaoRepository;
        _votoRepository = votoRepository;
        _participanteRepository = participanteRepository;
        _reuniaoStrictSequence = reuniaoStrictSequence;
        _proposicaoRepository = proposicaoRepository;
        _proposicaoStrictSequence = proposicaoStrictSequence;
    }

    public async Task<ReuniaoDto> Handle(UpdateReuniaoRequest request, CancellationToken cancellationToken)
    {
        var reuniaoDtoValidator = new UpdateReuniaoDtoValidator(_groupRepository, _authenticationService,
            _userRepository,
            _acaoRepository, _votoRepository, _participanteRepository, _reuniaoRepository, _reuniaoStrictSequence,
            _proposicaoRepository, _proposicaoStrictSequence);
        var reuniaoDtoValidationResult =
            await reuniaoDtoValidator.ValidateAsync(request.UpdateReuniaoDto, cancellationToken);
        if (!reuniaoDtoValidationResult.IsValid)
        {
            throw new ValidationException(reuniaoDtoValidationResult);
        }

        var savedReuniao = await _reuniaoRepository.Get(request.UpdateReuniaoDto.Id);
        if (savedReuniao == null) throw new NotFoundException(nameof(savedReuniao), request.UpdateReuniaoDto.Id);

        var responsavel = await _userRepository.Get(request.Uid);
        if (responsavel == null) throw new NotFoundException(nameof(responsavel), request.Uid);

        savedReuniao.OnUpdate(responsavel, Differentiator.GetDifferenceString<Reuniao>(
            savedReuniao,
            _mapper.Map<Reuniao>(request.UpdateReuniaoDto)));

        _mapper.Map(request.UpdateReuniaoDto, savedReuniao);
        var updatedReuniao = await _reuniaoRepository.Update(savedReuniao);

        return _mapper.Map<ReuniaoDto>(updatedReuniao);
    }
}