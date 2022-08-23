using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Application.Features.Proposicoes.Requests.Queries;
using CPTM.GRD.Common;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Handlers.Queries;

public class GetProposicaoDetailRequestHandler : IRequestHandler<GetProposicaoDetailRequest, ProposicaoDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IAuthenticationService _authenticationService;

    public GetProposicaoDetailRequestHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IAuthenticationService authenticationService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _authenticationService = authenticationService;
    }

    public async Task<ProposicaoDto> Handle(GetProposicaoDetailRequest request, CancellationToken cancellationToken)
    {
        _authenticationService.AuthorizeByMinLevel(request.RequestUser, AccessLevel.Sub);
        var proposicao = await _unitOfWork.ProposicaoRepository.Get(request.Pid);
        if (proposicao == null) throw new NotFoundException(nameof(proposicao), request.Pid);
        if (proposicao.Area != null)
            await _authenticationService.AuthorizeByMinGroups(request.RequestUser, proposicao.Area.Id);
        return _mapper.Map<ProposicaoDto>(proposicao);
    }
}