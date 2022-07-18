using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Proposicoes;
using CPTM.GRD.Application.Contracts.Persistence.Reunioes;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.Features.Reunioes.Requests.Commands;
using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Handlers.Commands;

public class
    CreateResolucaoDiretoriaProposicaoReuniaoRequestHandler : IRequestHandler<
        CreateResolucaoDiretoriaProposicaoReuniaoRequest, ProposicaoDto>
{
    private readonly IReuniaoRepository _reuniaoRepository;
    private readonly IProposicaoRepository _proposicaoRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IFileManagerService _fileManagerService;

    public CreateResolucaoDiretoriaProposicaoReuniaoRequestHandler(IReuniaoRepository reuniaoRepository,
        IProposicaoRepository proposicaoRepository, IUserRepository userRepository, IMapper mapper,
        IFileManagerService fileManagerService)
    {
        _reuniaoRepository = reuniaoRepository;
        _proposicaoRepository = proposicaoRepository;
        _userRepository = userRepository;
        _mapper = mapper;
        _fileManagerService = fileManagerService;
    }

    public async Task<ProposicaoDto> Handle(CreateResolucaoDiretoriaProposicaoReuniaoRequest request,
        CancellationToken cancellationToken)
    {
        var reuniao = await _reuniaoRepository.Get(request.Rid);
        var responsavel = await _userRepository.Get(request.Uid);
        var proposicao = await _proposicaoRepository.Get(request.Pid);

        reuniao.OnEmitProposicaoResolucaoDiretoria(request.Pid, responsavel,
            await _fileManagerService.CreateResolucaoDiretoria(reuniao, proposicao));

        var updatedProposicao = await _proposicaoRepository.Update(proposicao);
        return _mapper.Map<ProposicaoDto>(updatedProposicao);
    }
}