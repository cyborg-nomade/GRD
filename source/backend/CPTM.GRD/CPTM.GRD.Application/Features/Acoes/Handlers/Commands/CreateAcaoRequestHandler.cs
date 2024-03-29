﻿using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.DTOs.Main.Acao;
using CPTM.GRD.Application.DTOs.Main.Acao.Validators;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Application.Features.Acoes.Requests.Commands;
using CPTM.GRD.Common;
using CPTM.GRD.Domain.Acoes;
using MediatR;
using static CPTM.GRD.Application.Models.EmailSubjectsAndMessages;

namespace CPTM.GRD.Application.Features.Acoes.Handlers.Commands;

public class CreateAcaoRequestHandler : IRequestHandler<CreateAcaoRequest, AcaoDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IAuthenticationService _authenticationService;
    private readonly IEmailService _emailService;

    public CreateAcaoRequestHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IAuthenticationService authenticationService,
        IEmailService emailService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _authenticationService = authenticationService;
        _emailService = emailService;
    }

    public async Task<AcaoDto> Handle(CreateAcaoRequest request, CancellationToken cancellationToken)
    {
        _authenticationService.AuthorizeByMinLevel(request.RequestUser, AccessLevel.Grg);

        var acaoDtoValidator = new CreateAcaoDtoValidator(_unitOfWork.GroupRepository, _authenticationService,
            _unitOfWork.UserRepository);
        var acaoDtoValidationResult = await acaoDtoValidator.ValidateAsync(request.CreateAcaoDto, cancellationToken);
        if (!acaoDtoValidationResult.IsValid)
        {
            throw new ValidationException(acaoDtoValidationResult);
        }

        var dirRespAcao = await _unitOfWork.GroupRepository.Get(request.CreateAcaoDto.DiretoriaRes.Id);
        if (dirRespAcao == null)
            throw new NotFoundException(nameof(dirRespAcao), request.CreateAcaoDto.DiretoriaRes.Sigla);

        var responsavelAcao = await _unitOfWork.UserRepository.Get(request.CreateAcaoDto.Responsavel.Id);
        if (responsavelAcao == null)
            throw new NotFoundException(nameof(responsavelAcao), request.CreateAcaoDto.Responsavel.Id);

        var acao = _mapper.Map<Acao>(request.CreateAcaoDto);
        acao.DiretoriaRes = dirRespAcao;
        acao.Responsavel = responsavelAcao;

        var reuniao = await _unitOfWork.ReuniaoRepository.Get(request.Rid);
        if (reuniao == null) throw new NotFoundException(nameof(reuniao), request.Rid);

        var claims = _authenticationService.GetTokenClaims(request.RequestUser);

        var responsavel = await _unitOfWork.UserRepository.Get(claims.Uid);
        if (responsavel == null) throw new NotFoundException(nameof(responsavel), claims.Uid);

        reuniao.CreateAcao(acao, responsavel);

        await _unitOfWork.ReuniaoRepository.Update(reuniao);
        await _unitOfWork.Save();

        await _emailService.SendEmail(acao, reuniao, AcaoCreationSubject,
            AcaoCreationMessage(acao, reuniao));

        return _mapper.Map<AcaoDto>(acao);
    }
}