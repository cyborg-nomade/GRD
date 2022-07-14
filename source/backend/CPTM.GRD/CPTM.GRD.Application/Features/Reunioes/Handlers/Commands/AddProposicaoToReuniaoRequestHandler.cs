using AutoMapper;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Logging;
using CPTM.GRD.Application.DTOs.Main.Mixed;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.DTOs.Main.Reuniao;
using CPTM.GRD.Application.Features.Reunioes.Requests.Commands;
using CPTM.GRD.Common;
using CPTM.GRD.Domain.Logging;
using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Handlers.Commands;

public class AddProposicaoToReuniaoRequestHandler : IRequestHandler<AddProposicaoToReuniaoRequest, AddToPautaDto>
{
    private readonly IProposicaoRepository _proposicaoRepository;
    private readonly IReuniaoRepository _reuniaoRepository;
    private readonly ILogProposicaoRepository _logProposicaoRepository;
    private readonly ILogReuniaoRepository _logReuniaoRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public AddProposicaoToReuniaoRequestHandler(IProposicaoRepository proposicaoRepository,
        IReuniaoRepository reuniaoRepository, ILogProposicaoRepository logProposicaoRepository,
        ILogReuniaoRepository logReuniaoRepository, IUserRepository userRepository, IMapper mapper)
    {
        _proposicaoRepository = proposicaoRepository;
        _reuniaoRepository = reuniaoRepository;
        _logProposicaoRepository = logProposicaoRepository;
        _logReuniaoRepository = logReuniaoRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<AddToPautaDto> Handle(AddProposicaoToReuniaoRequest request, CancellationToken cancellationToken)
    {
        var proposicao = await _proposicaoRepository.Get(request.Pid);
        var reuniao = await _reuniaoRepository.Get(request.Rid);
        var responsavel = await _userRepository.Get(request.Uid);

        reuniao.AddProposicao(proposicao, responsavel);

        var updatedProposicao = await _proposicaoRepository.Update(proposicao);
        var updatedReuniao = await _reuniaoRepository.Update(reuniao);

        return new AddToPautaDto()
        {
            ProposicaoDto = _mapper.Map<ProposicaoDto>(updatedProposicao),
            ReuniaoDto = _mapper.Map<ReuniaoDto>(updatedReuniao)
        };
    }
}