using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Application.Features.Proposicoes.Requests.Commands;
using CPTM.GRD.Common;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Handlers.Commands;

public class
    GrgReturnToDiretoriaProposicaoRequestHandler : IRequestHandler<GrgReturnToDiretoriaProposicaoRequest, ProposicaoDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IAuthenticationService _authenticationService;

    public GrgReturnToDiretoriaProposicaoRequestHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IAuthenticationService authenticationService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _authenticationService = authenticationService;
    }

    public async Task<ProposicaoDto> Handle(GrgReturnToDiretoriaProposicaoRequest request,
        CancellationToken cancellationToken)
    {
        _authenticationService.AuthorizeByMinLevel(request.RequestUser, AccessLevel.Grg);

        var proposicao = await _unitOfWork.ProposicaoRepository.Get(request.Pid);
        if (proposicao == null) throw new NotFoundException(nameof(proposicao), request.Pid);

        var claims = _authenticationService.GetTokenClaims(request.RequestUser);

        var responsavel = await _unitOfWork.UserRepository.Get(claims.Uid);
        if (responsavel == null) throw new NotFoundException(nameof(responsavel), claims.Uid);

        proposicao.GrgReturnProposicaoToDiretoria(responsavel, request.MotivoReprovacao);

        var updatedProposicao = await _unitOfWork.ProposicaoRepository.Update(proposicao);
        await _unitOfWork.Save();

        return _mapper.Map<ProposicaoDto>(updatedProposicao);
    }
}