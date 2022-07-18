using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Proposicoes;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.DTOs.Main.Proposicao.Children.Voto.Validators;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Application.Features.Proposicoes.Requests.Commands;
using CPTM.GRD.Domain.Proposicoes.Children;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Handlers.Commands;

public class
    AddDiretorVoteToProposicaoRequestHandler : IRequestHandler<AddDiretorVoteToProposicaoRequest,
        ProposicaoDto>
{
    private readonly IProposicaoRepository _proposicaoRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IGroupRepository _groupRepository;
    private readonly IAuthenticationService _authenticationService;

    public AddDiretorVoteToProposicaoRequestHandler(IProposicaoRepository proposicaoRepository,
        IUserRepository userRepository, IMapper mapper, IGroupRepository groupRepository,
        IAuthenticationService authenticationService)
    {
        _proposicaoRepository = proposicaoRepository;
        _userRepository = userRepository;
        _mapper = mapper;
        _groupRepository = groupRepository;
        _authenticationService = authenticationService;
    }

    public async Task<ProposicaoDto> Handle(AddDiretorVoteToProposicaoRequest request,
        CancellationToken cancellationToken)
    {
        var proposicaoExists = await _proposicaoRepository.Exists(request.Pid);

        if (!proposicaoExists)
        {
            throw new NotFoundException("Proposição", proposicaoExists);
        }

        var proposicao = await _proposicaoRepository.Get(request.Pid);

        foreach (var voteWithAjustes in request.VotesWithAjustes)
        {
            var diretorExists = await _userRepository.Exists(voteWithAjustes.VotoDto.Participante.User.Id);

            if (!diretorExists)
            {
                throw new NotFoundException("Diretor", diretorExists);
            }

            var votoRdDtoValidator = new IVotoDtoValidator(_groupRepository, _authenticationService, _userRepository);
            var andamentoValidationResult =
                await votoRdDtoValidator.ValidateAsync(voteWithAjustes.VotoDto, cancellationToken);

            if (!andamentoValidationResult.IsValid)
            {
                throw new ValidationException(andamentoValidationResult);
            }

            var diretor = await _userRepository.Get(voteWithAjustes.VotoDto.Participante.User.Id);
            var votoRd = _mapper.Map<Voto>(voteWithAjustes.VotoDto);
            var ajustes = voteWithAjustes.Ajustes;

            proposicao.AddDiretorVote(diretor, votoRd, ajustes);
        }

        proposicao.CalculateNewProposicaoStatusFromVotes();

        var updatedProposicao = await _proposicaoRepository.Update(proposicao);

        return _mapper.Map<ProposicaoDto>(updatedProposicao);
    }
}