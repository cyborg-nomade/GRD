using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Proposicoes;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Application.Features.Proposicoes.Requests.Commands;
using CPTM.GRD.Common;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Handlers.Commands;

public class SendToDiretoriaProposicaoRequestHandler : IRequestHandler<SendToDiretoriaProposicaoRequest, ProposicaoDto>
{
    private readonly IProposicaoRepository _proposicaoRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IAuthenticationService _authenticationService;

    public SendToDiretoriaProposicaoRequestHandler(
        IProposicaoRepository proposicaoRepository,
        IUserRepository userRepository,
        IMapper mapper,
        IAuthenticationService authenticationService)
    {
        _proposicaoRepository = proposicaoRepository;
        _userRepository = userRepository;
        _mapper = mapper;
        _authenticationService = authenticationService;
    }

    public async Task<ProposicaoDto> Handle(SendToDiretoriaProposicaoRequest request,
        CancellationToken cancellationToken)
    {
        _authenticationService.AuthorizeByMinLevel(request.RequestUser, AccessLevel.Gerente);

        var proposicao = await _proposicaoRepository.Get(request.Pid);
        if (proposicao == null) throw new NotFoundException(nameof(proposicao), request.Pid);

        await _authenticationService.AuthorizeByMinGroups(request.RequestUser, proposicao.AreaSolicitante.Id);

        var claims = _authenticationService.GetTokenClaims(request.RequestUser);

        var responsavel = await _userRepository.Get(claims.Uid);
        if (responsavel == null) throw new NotFoundException(nameof(responsavel), claims.Uid);

        proposicao.SendToDiretoriaResponsavelApproval(responsavel);

        var updatedProposicao = await _proposicaoRepository.Update(proposicao);

        return _mapper.Map<ProposicaoDto>(updatedProposicao);
    }
}