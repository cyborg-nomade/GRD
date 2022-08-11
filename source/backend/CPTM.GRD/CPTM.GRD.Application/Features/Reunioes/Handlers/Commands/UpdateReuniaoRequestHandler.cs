using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.Contracts.Persistence.StrictSequenceControl;
using CPTM.GRD.Application.Contracts.Util;
using CPTM.GRD.Application.DTOs.Main.Reuniao;
using CPTM.GRD.Application.DTOs.Main.Reuniao.Validators;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Application.Features.Reunioes.Requests.Commands;
using CPTM.GRD.Common;
using CPTM.GRD.Domain.Reunioes;
using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Handlers.Commands;

public class UpdateReuniaoRequestHandler : IRequestHandler<UpdateReuniaoRequest, ReuniaoDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IAuthenticationService _authenticationService;
    private readonly IReuniaoStrictSequenceControl _reuniaoStrictSequence;
    private readonly IProposicaoStrictSequenceControl _proposicaoStrictSequence;
    private readonly IDifferentiator _differentiator;

    public UpdateReuniaoRequestHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IAuthenticationService authenticationService,
        IReuniaoStrictSequenceControl reuniaoStrictSequence,
        IProposicaoStrictSequenceControl proposicaoStrictSequence,
        IDifferentiator differentiator)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _authenticationService = authenticationService;
        _reuniaoStrictSequence = reuniaoStrictSequence;
        _proposicaoStrictSequence = proposicaoStrictSequence;
        _differentiator = differentiator;
    }

    public async Task<ReuniaoDto> Handle(UpdateReuniaoRequest request, CancellationToken cancellationToken)
    {
        _authenticationService.AuthorizeByMinLevel(request.RequestUser, AccessLevel.Grg);

        var reuniaoDtoValidator = new UpdateReuniaoDtoValidator(_unitOfWork.GroupRepository, _authenticationService,
            _unitOfWork.UserRepository, _unitOfWork.VotoRepository,
            _unitOfWork.ReuniaoRepository, _reuniaoStrictSequence,
            _unitOfWork.ProposicaoRepository, _proposicaoStrictSequence);
        var reuniaoDtoValidationResult =
            await reuniaoDtoValidator.ValidateAsync(request.UpdateReuniaoDto, cancellationToken);
        if (!reuniaoDtoValidationResult.IsValid)
        {
            throw new ValidationException(reuniaoDtoValidationResult);
        }

        var savedReuniao = await _unitOfWork.ReuniaoRepository.Get(request.Rid);
        if (savedReuniao == null) throw new NotFoundException(nameof(savedReuniao), request.Rid);

        var claims = _authenticationService.GetTokenClaims(request.RequestUser);

        var responsavel = await _unitOfWork.UserRepository.Get(claims.Uid);
        if (responsavel == null) throw new NotFoundException(nameof(responsavel), claims.Uid);

        savedReuniao.OnUpdate(responsavel, _differentiator.GetDifferenceString<Reuniao>(
            savedReuniao,
            _mapper.Map<Reuniao>(request.UpdateReuniaoDto)));

        _mapper.Map(request.UpdateReuniaoDto, savedReuniao);
        var updatedReuniao = await _unitOfWork.ReuniaoRepository.Update(savedReuniao);
        await _unitOfWork.Save();

        return _mapper.Map<ReuniaoDto>(updatedReuniao);
    }
}