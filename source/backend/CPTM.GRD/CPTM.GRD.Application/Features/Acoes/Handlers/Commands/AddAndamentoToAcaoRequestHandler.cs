using AutoMapper;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Logging;
using CPTM.GRD.Application.DTOs.Main.Acao;
using CPTM.GRD.Application.Features.Acoes.Requests.Commands;
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

        acao.AddAndamento(andamento);

        var updatedAcao = await _acaoRepository.Update(acao);
        return _mapper.Map<AcaoDto>(updatedAcao);
    }
}