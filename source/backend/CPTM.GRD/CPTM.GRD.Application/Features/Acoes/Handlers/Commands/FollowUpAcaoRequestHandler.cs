using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Acoes;
using CPTM.GRD.Application.Contracts.Persistence.Reunioes;
using CPTM.GRD.Application.DTOs.Main.Acao;
using CPTM.GRD.Application.DTOs.Main.Mixed;
using CPTM.GRD.Application.DTOs.Main.Reuniao;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Application.Features.Acoes.Requests.Commands;
using CPTM.GRD.Common;
using MediatR;

namespace CPTM.GRD.Application.Features.Acoes.Handlers.Commands;

public class FollowUpAcaoRequestHandler : IRequestHandler<FollowUpAcaoRequest, AddAcaoToReuniaoDto>
{
    private readonly IAcaoRepository _acaoRepository;
    private readonly IReuniaoRepository _reuniaoRepository;
    private readonly IUserRepository _userRepository;
    private readonly IAuthenticationService _authenticationService;
    private readonly IMapper _mapper;

    public FollowUpAcaoRequestHandler(
        IAcaoRepository acaoRepository,
        IReuniaoRepository reuniaoRepository,
        IUserRepository userRepository,
        IAuthenticationService authenticationService,
        IMapper mapper)
    {
        _acaoRepository = acaoRepository;
        _reuniaoRepository = reuniaoRepository;
        _userRepository = userRepository;
        _authenticationService = authenticationService;
        _mapper = mapper;
    }

    public async Task<AddAcaoToReuniaoDto> Handle(FollowUpAcaoRequest request, CancellationToken cancellationToken)
    {
        _authenticationService.AuthorizeByMinLevel(request.RequestUser, AccessLevel.Grg);

        var acao = await _acaoRepository.Get(request.Aid);
        if (acao == null) throw new NotFoundException(nameof(acao), request.Aid);

        var reuniao = await _reuniaoRepository.Get(request.Rid);
        if (reuniao == null) throw new NotFoundException(nameof(reuniao), request.Rid);

        var claims = _authenticationService.GetTokenClaims(request.RequestUser);

        var responsavel = await _userRepository.Get(claims.Uid);
        if (responsavel == null) throw new NotFoundException(nameof(responsavel), claims.Uid);

        acao.FollowUp(reuniao, responsavel);

        var updatedAcao = await _acaoRepository.Update(acao);
        return new AddAcaoToReuniaoDto()
        {
            AcaoDto = _mapper.Map<AcaoDto>(updatedAcao),
            ReuniaoDto = _mapper.Map<ReuniaoDto>(reuniao)
        };
    }
}