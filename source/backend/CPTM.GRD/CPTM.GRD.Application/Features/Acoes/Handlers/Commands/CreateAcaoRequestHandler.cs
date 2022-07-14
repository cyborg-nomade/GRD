using AutoMapper;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Logging;
using CPTM.GRD.Application.DTOs.Main.Acao;
using CPTM.GRD.Application.Features.Acoes.Requests.Commands;
using CPTM.GRD.Common;
using CPTM.GRD.Domain;
using CPTM.GRD.Domain.Logging;
using MediatR;

namespace CPTM.GRD.Application.Features.Acoes.Handlers.Commands;

public class CreateAcaoRequestHandler : IRequestHandler<CreateAcaoRequest, AcaoDto>
{
    private readonly IAcaoRepository _acaoRepository;
    private readonly ILogAcaoRepository _logAcaoRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public CreateAcaoRequestHandler(IAcaoRepository acaoRepository, ILogAcaoRepository logAcaoRepository,
        IUserRepository userRepository, IMapper mapper)
    {
        _acaoRepository = acaoRepository;
        _logAcaoRepository = logAcaoRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<AcaoDto> Handle(CreateAcaoRequest request, CancellationToken cancellationToken)
    {
        var acao = _mapper.Map<Acao>(request.CreateAcaoDto);

        var createLog = new LogAcao()
        {
            Data = DateTime.Now,
            Tipo = TipoLogAcao.Criacao,
            Diferenca = "Salvamento inicial",
            AcaoId = $@"ID Acão: {acao.Id}",
            UsuarioResp = await _userRepository.Get(request.Uid)
        };
        await _logAcaoRepository.Add(createLog);
        acao.Logs.Add(createLog);

        var addedAcao = await _acaoRepository.Add(acao);

        return _mapper.Map<AcaoDto>(addedAcao);
    }
}