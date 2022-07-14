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

public class UpdateAcaoRequestHandler : IRequestHandler<UpdateAcaoRequest, AcaoDto>
{
    private readonly IAcaoRepository _acaoRepository;
    private readonly ILogAcaoRepository _logAcaoRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UpdateAcaoRequestHandler(IAcaoRepository acaoRepository, ILogAcaoRepository logAcaoRepository,
        IUserRepository userRepository, IMapper mapper)
    {
        _acaoRepository = acaoRepository;
        _logAcaoRepository = logAcaoRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<AcaoDto> Handle(UpdateAcaoRequest request, CancellationToken cancellationToken)
    {
        var savedAcao = await _acaoRepository.Get(request.AcaoDto.Id);

        var editLog = new LogAcao()
        {
            Data = DateTime.Now,
            Tipo = TipoLogAcao.Edicao,
            Diferenca = Differentiator.GetDifferenceString<Acao>(savedAcao, _mapper.Map<Acao>(request.AcaoDto)),
            AcaoId = $@"ID Acão: {savedAcao.Id}",
            UsuarioResp = await _userRepository.Get(request.Uid)
        };
        await _logAcaoRepository.Add(editLog);
        savedAcao.Logs.Add(editLog);

        _mapper.Map(request.AcaoDto, savedAcao);

        var updatedAcao = await _acaoRepository.Update(savedAcao);

        return _mapper.Map<AcaoDto>(updatedAcao);
    }
}