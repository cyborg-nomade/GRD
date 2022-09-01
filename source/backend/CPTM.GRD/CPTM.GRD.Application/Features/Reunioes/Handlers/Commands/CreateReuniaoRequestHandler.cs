using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.Contracts.Persistence.StrictSequenceControl;
using CPTM.GRD.Application.DTOs.Main.Reuniao;
using CPTM.GRD.Application.DTOs.Main.Reuniao.Validators;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Application.Features.Reunioes.Requests.Commands;
using CPTM.GRD.Common;
using CPTM.GRD.Domain.Reunioes;
using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Handlers.Commands;

public class CreateReuniaoRequestHandler : IRequestHandler<CreateReuniaoRequest, ReuniaoDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IReuniaoStrictSequenceControl _reuniaoSequenceControl;
    private readonly IAuthenticationService _authenticationService;
    private readonly IProposicaoStrictSequenceControl _proposicaoStrictSequence;

    public CreateReuniaoRequestHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IReuniaoStrictSequenceControl reuniaoSequenceControl,
        IAuthenticationService authenticationService,
        IProposicaoStrictSequenceControl proposicaoStrictSequence)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _reuniaoSequenceControl = reuniaoSequenceControl;
        _authenticationService = authenticationService;
        _proposicaoStrictSequence = proposicaoStrictSequence;
    }

    public async Task<ReuniaoDto> Handle(CreateReuniaoRequest request, CancellationToken cancellationToken)
    {
        _authenticationService.AuthorizeByMinLevel(request.RequestUser, AccessLevel.Grg);

        var reuniaoDtoValidator = new CreateReuniaoDtoValidator(_unitOfWork.GroupRepository, _authenticationService,
            _unitOfWork.UserRepository, _unitOfWork.VotoRepository,
            _unitOfWork.ProposicaoRepository, _proposicaoStrictSequence);
        var reuniaoDtoValidationResult =
            await reuniaoDtoValidator.ValidateAsync(request.CreateReuniaoDto, cancellationToken);
        if (!reuniaoDtoValidationResult.IsValid)
        {
            throw new ValidationException(reuniaoDtoValidationResult);
        }

        var reuniao = _mapper.Map<Reuniao>(request.CreateReuniaoDto);
        var numeroReuniao = await _reuniaoSequenceControl.GetNextNumeroReuniao();

        var claims = _authenticationService.GetTokenClaims(request.RequestUser);
        var responsavel = await _unitOfWork.UserRepository.Get(claims.Uid);
        if (responsavel == null) throw new NotFoundException(nameof(responsavel), claims.Uid);

        var participantesPrevia =
            await _unitOfWork.UserRepository.GetFromIdList(request.CreateReuniaoDto.ParticipantesPreviaIds);
        var participantes = await _unitOfWork.UserRepository.GetFromIdList(request.CreateReuniaoDto.ParticipantesIds);

        reuniao.OnSave(numeroReuniao, responsavel, participantesPrevia, participantes);

        var addedReuniao = await _unitOfWork.ReuniaoRepository.Add(reuniao);
        await _unitOfWork.Save();

        return _mapper.Map<ReuniaoDto>(addedReuniao);
    }
}