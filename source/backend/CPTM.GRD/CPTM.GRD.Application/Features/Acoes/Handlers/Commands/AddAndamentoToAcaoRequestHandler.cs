using AutoMapper;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.DTOs.Main.Acao;
using CPTM.GRD.Application.Features.Acoes.Requests.Commands;
using CPTM.GRD.Application.Persistence.Contracts.AccessControl;
using CPTM.GRD.Application.Persistence.Contracts.Logging;
using CPTM.GRD.Application.Util;
using CPTM.GRD.Common;
using CPTM.GRD.Domain;
using CPTM.GRD.Domain.Logging;
using MediatR;

namespace CPTM.GRD.Application.Features.Acoes.Handlers.Commands;

public class AddAndamentoToAcaoRequestHandler : IRequestHandler<AddAndamentoToAcaoRequest, AcaoDto>
{
    private readonly IAcaoRepository _acaoRepository;
    private readonly IAndamentoRepository _andamentoRepository;
    private readonly ILogAcaoRepository _logAcaoRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public AddAndamentoToAcaoRequestHandler(IAcaoRepository acaoRepository, IAndamentoRepository andamentoRepository,
        ILogAcaoRepository logAcaoRepository, IUserRepository userRepository, IMapper mapper)
    {
        _acaoRepository = acaoRepository;
        _andamentoRepository = andamentoRepository;
        _logAcaoRepository = logAcaoRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<AcaoDto> Handle(AddAndamentoToAcaoRequest request, CancellationToken cancellationToken)
    {
        var acao = await _acaoRepository.Get(request.Aid);
        var andamento = _mapper.Map<Andamento>(request.AndamentoDto);

        var addAndamentoLog = new LogAcao()
        {
            Data = DateTime.Now,
            Tipo = TipoLogAcao.InclusaoAndamento,
            Diferenca = $"Incluído andamento: {andamento.Descricao}",
            AcaoId = $@"ID Ação: {acao.Id}",
            UsuarioResp = await _userRepository.Get(request.Aid)
        };
        await _logAcaoRepository.Add(addAndamentoLog);
        acao.Andamentos.Add(andamento);

        acao.Status = AcaoStatus.EmAcompanhamento;

        var updatedAcao = await _acaoRepository.Update(acao);
        return _mapper.Map<AcaoDto>(updatedAcao);
    }
}