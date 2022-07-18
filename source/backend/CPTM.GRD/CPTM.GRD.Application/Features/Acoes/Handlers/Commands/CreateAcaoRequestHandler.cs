using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Reunioes;
using CPTM.GRD.Application.DTOs.Main.Acao;
using CPTM.GRD.Application.DTOs.Main.Acao.Validators;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Application.Features.Acoes.Requests.Commands;
using CPTM.GRD.Domain.Acoes;
using MediatR;

namespace CPTM.GRD.Application.Features.Acoes.Handlers.Commands;

public class CreateAcaoRequestHandler : IRequestHandler<CreateAcaoRequest, AcaoDto>
{
    private readonly IReuniaoRepository _reuniaoRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IAuthenticationService _authenticationService;
    private readonly IGroupRepository _groupRepository;

    public CreateAcaoRequestHandler(IReuniaoRepository reuniaoRepository, IUserRepository userRepository,
        IMapper mapper, IAuthenticationService authenticationService, IGroupRepository groupRepository)
    {
        _reuniaoRepository = reuniaoRepository;
        _userRepository = userRepository;
        _mapper = mapper;
        _authenticationService = authenticationService;
        _groupRepository = groupRepository;
    }

    public async Task<AcaoDto> Handle(CreateAcaoRequest request, CancellationToken cancellationToken)
    {
        var reuniaoExists = await _reuniaoRepository.Exists(request.Rid);

        if (!reuniaoExists)
        {
            throw new NotFoundException("Reunião", reuniaoExists);
        }

        var responsavelExists = await _userRepository.Exists(request.Uid);

        if (!responsavelExists)
        {
            throw new NotFoundException("Usuário", responsavelExists);
        }

        var acaoDtoValidator = new IAcaoDtoValidator(_groupRepository, _authenticationService, _userRepository);
        var acaoValidationResult = await acaoDtoValidator.ValidateAsync(request.CreateAcaoDto, cancellationToken);

        if (!acaoValidationResult.IsValid)
        {
            throw new ValidationException(acaoValidationResult);
        }

        var acao = _mapper.Map<Acao>(request.CreateAcaoDto);
        var reuniao = await _reuniaoRepository.Get(request.Rid);
        var responsavel = await _userRepository.Get(request.Uid);

        reuniao.CreateAcao(acao, responsavel);

        await _reuniaoRepository.Update(reuniao);

        return _mapper.Map<AcaoDto>(acao);
    }
}