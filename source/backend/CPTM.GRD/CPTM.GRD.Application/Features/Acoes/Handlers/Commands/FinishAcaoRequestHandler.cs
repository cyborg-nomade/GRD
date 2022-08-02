using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Acoes;
using CPTM.GRD.Application.DTOs.Main.Acao;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Application.Features.Acoes.Requests.Commands;
using CPTM.GRD.Common;
using MediatR;

namespace CPTM.GRD.Application.Features.Acoes.Handlers.Commands;

public class FinishAcaoRequestHandler : IRequestHandler<FinishAcaoRequest, AcaoDto>
{
    private readonly IAcaoRepository _acaoRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    private readonly IAuthenticationService _authenticationService;

    public FinishAcaoRequestHandler(
        IAcaoRepository acaoRepository,
        IUserRepository userRepository,
        IAuthenticationService authenticationService,
        IMapper mapper
    )
    {
        _acaoRepository = acaoRepository;
        _userRepository = userRepository;
        _authenticationService = authenticationService;
        _mapper = mapper;
    }

    public async Task<AcaoDto> Handle(FinishAcaoRequest request, CancellationToken cancellationToken)
    {
        _authenticationService.AuthorizeByMinLevel(request.RequestUser, AccessLevel.Grg);

        var acao = await _acaoRepository.Get(request.Aid);
        if (acao == null) throw new NotFoundException(nameof(acao), request.Aid);

        var claims = _authenticationService.GetTokenClaims(request.RequestUser);

        var responsavel = await _userRepository.Get(claims.Uid);
        if (responsavel == null) throw new NotFoundException(nameof(responsavel), claims.Uid);

        acao.Finish(request.Status, responsavel);

        var updatedAcao = await _acaoRepository.Update(acao);

        return _mapper.Map<AcaoDto>(updatedAcao);
    }
}