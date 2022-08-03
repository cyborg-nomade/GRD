using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Proposicoes;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.DTOs.Main.Proposicao.Children.Voto.Validators;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Application.Features.Proposicoes.Requests.Commands;
using CPTM.GRD.Common;
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

    public AddDiretorVoteToProposicaoRequestHandler(
        IProposicaoRepository proposicaoRepository,
        IUserRepository userRepository,
        IMapper mapper,
        IGroupRepository groupRepository,
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
        _authenticationService.AuthorizeByMinLevel(request.RequestUser, AccessLevel.Diretor);

        var proposicao = await _proposicaoRepository.Get(request.Pid);
        if (proposicao == null) throw new NotFoundException(nameof(proposicao), request.Pid);

        foreach (var voteWithAjustes in request.VotesWithAjustes)
        {
            var votoRdDtoValidator =
                new CreateVotoDtoValidator(_groupRepository, _authenticationService, _userRepository);
            var votoRdDtoValidationResult =
                await votoRdDtoValidator.ValidateAsync(voteWithAjustes.VotoDto, cancellationToken);
            if (!votoRdDtoValidationResult.IsValid)
            {
                throw new ValidationException(votoRdDtoValidationResult);
            }

            var diretor = await _userRepository.Get(voteWithAjustes.VotoDto.Participante.User.Id);
            if (diretor == null)
                throw new NotFoundException(nameof(diretor), voteWithAjustes.VotoDto.Participante.User.Id);

            var votoRd = _mapper.Map<Voto>(voteWithAjustes.VotoDto);

            var ajustes = voteWithAjustes.Ajustes ??
                          throw new BadRequestException($"{nameof(voteWithAjustes.Ajustes)} não pode ser nulo");

            proposicao.AddDiretorVote(diretor, votoRd, ajustes);
        }

        proposicao.CalculateNewProposicaoStatusFromVotes();

        var updatedProposicao = await _proposicaoRepository.Update(proposicao);

        return _mapper.Map<ProposicaoDto>(updatedProposicao);
    }
}