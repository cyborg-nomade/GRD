using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.Contracts.Util;
using CPTM.GRD.Application.DTOs.Main.Acao;
using CPTM.GRD.Application.DTOs.Main.Acao.Validators;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Application.Features.Acoes.Requests.Commands;
using CPTM.GRD.Common;
using CPTM.GRD.Domain.Acoes;
using MediatR;

namespace CPTM.GRD.Application.Features.Acoes.Handlers.Commands;

public class UpdateAcaoRequestHandler : IRequestHandler<UpdateAcaoRequest, AcaoDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IAuthenticationService _authenticationService;
    private readonly IDifferentiator _differentiator;

    public UpdateAcaoRequestHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IAuthenticationService authenticationService,
        IDifferentiator differentiator)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _authenticationService = authenticationService;
        _differentiator = differentiator;
    }

    public async Task<AcaoDto> Handle(UpdateAcaoRequest request, CancellationToken cancellationToken)
    {
        _authenticationService.AuthorizeByMinLevel(request.RequestUser, AccessLevel.Grg);

        var acaoDtoValidator =
            new UpdateAcaoDtoValidator(_unitOfWork.GroupRepository, _authenticationService, _unitOfWork.UserRepository,
                _unitOfWork.AcaoRepository);
        var acaoDtoValidationResult = await acaoDtoValidator.ValidateAsync(request.UpdateAcaoDto, cancellationToken);
        if (!acaoDtoValidationResult.IsValid)
        {
            throw new ValidationException(acaoDtoValidationResult);
        }

        var savedAcao = await _unitOfWork.AcaoRepository.Get(request.Aid);
        if (savedAcao == null) throw new NotFoundException(nameof(savedAcao), request.Aid);

        var claims = _authenticationService.GetTokenClaims(request.RequestUser);

        var responsavel = await _unitOfWork.UserRepository.Get(claims.Uid);
        if (responsavel == null) throw new NotFoundException(nameof(responsavel), claims.Uid);

        savedAcao.OnUpdate(
            _differentiator.GetDifferenceString<Acao>(
                savedAcao,
                _mapper.Map<Acao>(request.UpdateAcaoDto)),
            responsavel);

        _mapper.Map(request.UpdateAcaoDto, savedAcao);
        var updatedAcao = await _unitOfWork.AcaoRepository.Update(savedAcao);
        await _unitOfWork.Save();

        return _mapper.Map<AcaoDto>(updatedAcao);
    }
}