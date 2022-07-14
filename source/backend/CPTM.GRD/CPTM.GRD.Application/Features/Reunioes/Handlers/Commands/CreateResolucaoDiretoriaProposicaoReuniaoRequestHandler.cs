using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.DTOs.Main.Reuniao;
using CPTM.GRD.Application.Features.Reunioes.Requests.Commands;
using CPTM.GRD.Application.Persistence.Contracts.AccessControl;
using CPTM.GRD.Application.Persistence.Contracts.Logging;
using CPTM.GRD.Common;
using CPTM.GRD.Domain.Logging;
using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Handlers.Commands;

public class
    CreateResolucaoDiretoriaProposicaoReuniaoRequestHandler : IRequestHandler<
        CreateResolucaoDiretoriaProposicaoReuniaoRequest, ProposicaoDto>
{
    private readonly IReuniaoRepository _reuniaoRepository;
    private readonly IProposicaoRepository _proposicaoRepository;
    private readonly ILogProposicaoRepository _logProposicaoRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IFileCreator _fileCreator;

    public CreateResolucaoDiretoriaProposicaoReuniaoRequestHandler(IReuniaoRepository reuniaoRepository,
        IProposicaoRepository proposicaoRepository,
        ILogProposicaoRepository logProposicaoRepository, IUserRepository userRepository, IMapper mapper,
        IFileCreator fileCreator)
    {
        _reuniaoRepository = reuniaoRepository;
        _proposicaoRepository = proposicaoRepository;
        _logProposicaoRepository = logProposicaoRepository;
        _userRepository = userRepository;
        _mapper = mapper;
        _fileCreator = fileCreator;
    }

    public async Task<ProposicaoDto> Handle(CreateResolucaoDiretoriaProposicaoReuniaoRequest request,
        CancellationToken cancellationToken)
    {
        var reuniao = await _reuniaoRepository.Get(request.Rid);
        var proposicao = reuniao.Proposicoes.SingleOrDefault(p => p.Id == request.Pid);

        if (proposicao == null) throw new Exception("Essa Proposição não existe na Reunião indicada");

        var criacaoResolucaoDiretoriaLog = new LogProposicao()
        {
            Data = DateTime.Now,
            Tipo = TipoLogProposicao.EmissaoResolucaoDiretoria,
            Diferenca = "Emissão Resolução Diretoria",
            ProposicaoId = $@"IDPRD {proposicao.IdPrd}",
            UsuarioResp = await _userRepository.Get(request.Uid)
        };
        await _logProposicaoRepository.Add(criacaoResolucaoDiretoriaLog);
        proposicao.Logs.Add(criacaoResolucaoDiretoriaLog);

        proposicao.ResolucaoDiretoriaFilePath = await _fileCreator.CreateResolucaoDiretoria(reuniao, proposicao);

        var updatedProposicao = await _proposicaoRepository.Update(proposicao);
        return _mapper.Map<ProposicaoDto>(updatedProposicao);
    }
}