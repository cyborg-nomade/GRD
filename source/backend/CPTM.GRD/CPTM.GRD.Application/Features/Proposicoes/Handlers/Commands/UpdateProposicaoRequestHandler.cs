using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Acoes;
using CPTM.GRD.Application.Contracts.Persistence.Proposicoes;
using CPTM.GRD.Application.Contracts.Persistence.Proposicoes.Children;
using CPTM.GRD.Application.Contracts.Persistence.Reunioes.Children;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.DTOs.Main.Proposicao.Validators;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Application.Features.Proposicoes.Requests.Commands;
using CPTM.GRD.Application.Util;
using CPTM.GRD.Domain.Proposicoes;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Handlers.Commands;

public class UpdateProposicaoRequestHandler : IRequestHandler<UpdateProposicaoRequest, ProposicaoDto>
{
    private readonly IProposicaoRepository _proposicaoRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IGroupRepository _groupRepository;
    private readonly IAuthenticationService _authenticationService;
    private readonly IAcaoRepository _acaoRepository;
    private readonly IVotoRepository _votoRepository;
    private readonly IParticipanteRepository _participanteRepository;

    public UpdateProposicaoRequestHandler(IProposicaoRepository proposicaoRepository, IUserRepository userRepository,
        IMapper mapper, IGroupRepository groupRepository, IAuthenticationService authenticationService,
        IAcaoRepository acaoRepository, IVotoRepository votoRepository, IParticipanteRepository participanteRepository)
    {
        _proposicaoRepository = proposicaoRepository;
        _userRepository = userRepository;
        _mapper = mapper;
        _groupRepository = groupRepository;
        _authenticationService = authenticationService;
        _acaoRepository = acaoRepository;
        _votoRepository = votoRepository;
        _participanteRepository = participanteRepository;
    }

    public async Task<ProposicaoDto> Handle(UpdateProposicaoRequest request, CancellationToken cancellationToken)
    {
        var responsavelExists = await _userRepository.Exists(request.Uid);

        if (!responsavelExists)
        {
            throw new NotFoundException("Usuário", responsavelExists);
        }

        var validator = new ProposicaoDtoValidator(_groupRepository, _authenticationService, _userRepository,
            _acaoRepository, _votoRepository, _participanteRepository);
        var validationResult = await validator.ValidateAsync(request.ProposicaoDto, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult);
        }

        var savedProposicao = await _proposicaoRepository.Get(request.ProposicaoDto.Id);
        var responsavel = await _userRepository.Get(request.Uid);

        savedProposicao.OnUpdate(responsavel,
            Differentiator.GetDifferenceString<Proposicao>(savedProposicao,
                _mapper.Map<Proposicao>(request.ProposicaoDto)));

        _mapper.Map(request.ProposicaoDto, savedProposicao);

        var updatedProposicao = await _proposicaoRepository.Update(savedProposicao);
        return _mapper.Map<ProposicaoDto>(updatedProposicao);
    }
}