using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence;
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
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IAuthenticationService _authenticationService;

    public AddDiretorVoteToProposicaoRequestHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IAuthenticationService authenticationService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _authenticationService = authenticationService;
    }

    public async Task<ProposicaoDto> Handle(AddDiretorVoteToProposicaoRequest request,
        CancellationToken cancellationToken)
    {
        _authenticationService.AuthorizeByMinLevel(request.RequestUser, AccessLevel.Diretor);

        var proposicao = await _unitOfWork.ProposicaoRepository.Get(request.Pid);
        if (proposicao == null) throw new NotFoundException(nameof(proposicao), request.Pid);

        foreach (var voteWithAjustes in request.VotesWithAjustes)
        {
            var votoRdDtoValidator =
                new CreateVotoDtoValidator(_unitOfWork.GroupRepository, _authenticationService,
                    _unitOfWork.UserRepository);
            var votoRdDtoValidationResult =
                await votoRdDtoValidator.ValidateAsync(voteWithAjustes.VotoDto, cancellationToken);
            if (!votoRdDtoValidationResult.IsValid)
            {
                throw new ValidationException(votoRdDtoValidationResult);
            }

            var diretor = await _unitOfWork.UserRepository.Get(voteWithAjustes.VotoDto.Participante.User.Id);
            if (diretor == null)
                throw new NotFoundException(nameof(diretor), voteWithAjustes.VotoDto.Participante.User.Id);

            var votoRd = _mapper.Map<Voto>(voteWithAjustes.VotoDto);

            var ajustes = voteWithAjustes.Ajustes ??
                          throw new BadRequestException($"{nameof(voteWithAjustes.Ajustes)} não pode ser nulo");

            proposicao.AddDiretorVote(diretor, votoRd, ajustes);
        }

        proposicao.CalculateNewProposicaoStatusFromVotes();

        var updatedProposicao = await _unitOfWork.ProposicaoRepository.Update(proposicao);
        await _unitOfWork.Save();

        return _mapper.Map<ProposicaoDto>(updatedProposicao);
    }
}