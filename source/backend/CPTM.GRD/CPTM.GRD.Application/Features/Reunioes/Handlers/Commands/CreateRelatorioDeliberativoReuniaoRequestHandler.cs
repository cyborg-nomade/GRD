using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Logging;
using CPTM.GRD.Application.DTOs.Main.Reuniao;
using CPTM.GRD.Application.Features.Reunioes.Requests.Commands;
using CPTM.GRD.Common;
using CPTM.GRD.Domain;
using CPTM.GRD.Domain.Logging;
using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Handlers.Commands;

public class
    CreateRelatorioDeliberativoReuniaoRequestHandler : IRequestHandler<CreateRelatorioDeliberativoReuniaoRequest,
        ReuniaoDto>
{
    private readonly IReuniaoRepository _reuniaoRepository;
    private readonly ILogReuniaoRepository _logReuniaoRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IFileCreator _fileCreator;

    public CreateRelatorioDeliberativoReuniaoRequestHandler(IReuniaoRepository reuniaoRepository,
        ILogReuniaoRepository logReuniaoRepository, IUserRepository userRepository, IMapper mapper,
        IFileCreator fileCreator)
    {
        _reuniaoRepository = reuniaoRepository;
        _logReuniaoRepository = logReuniaoRepository;
        _userRepository = userRepository;
        _mapper = mapper;
        _fileCreator = fileCreator;
    }

    public async Task<ReuniaoDto> Handle(CreateRelatorioDeliberativoReuniaoRequest request,
        CancellationToken cancellationToken)
    {
        var reuniao = await _reuniaoRepository.Get(request.Rid);

        var criacaoRelatorioDeliberativoLog = new LogReuniao()
        {
            Data = DateTime.Now,
            Tipo = TipoLogReuniao.EmissaoRelatorioDeliberativo,
            Diferenca = "Emissão Relatório Deliberativo",
            ReuniaoId = $@"Número Reunião {reuniao.NumeroReuniao}",
            UsuarioResp = await _userRepository.Get(request.Uid)
        };
        await _logReuniaoRepository.Add(criacaoRelatorioDeliberativoLog);
        reuniao.Logs.Add(criacaoRelatorioDeliberativoLog);

        reuniao.Status = ReuniaoStatus.Realizada;

        foreach (var proposicao in reuniao.Proposicoes.ToList())
        {
            if (proposicao.AjustesRd != string.Empty)
            {
                if (proposicao.Status == ProposicaoStatus.AprovadaRd)
                {
                    proposicao.Status = ProposicaoStatus.AprovadaRdAguardandoAjustes;
                }

                if (proposicao.Status == ProposicaoStatus.SuspensaRd)
                {
                    proposicao.Status = ProposicaoStatus.SuspensaRdAguardandoAjustes;
                }
            }
            else if (proposicao.Status == ProposicaoStatus.SuspensaRd)
            {
                proposicao.Status = ProposicaoStatus.DisponivelInclusaoPauta;
                proposicao.Reuniao = new Reuniao();
                reuniao.Proposicoes.Remove(proposicao);
            }
        }

        reuniao.RelatorioDeliberativoFilePath = await _fileCreator.CreateRelatorioDeliberativo(reuniao);

        var updatedReuniao = await _reuniaoRepository.Update(reuniao);
        return _mapper.Map<ReuniaoDto>(updatedReuniao);
    }
}