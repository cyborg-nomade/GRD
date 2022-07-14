using AutoMapper;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.DTOs.Main.Mixed;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.DTOs.Main.Reuniao;
using CPTM.GRD.Application.Features.Reunioes.Requests.Commands;
using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Handlers.Commands;

public class
    RemoveProposicaoFromReuniaoRequestHandler : IRequestHandler<RemoveProposicaoFromReuniaoRequest, AddToPautaDto>
{
    private readonly IReuniaoRepository _reuniaoRepository;
    private readonly IProposicaoRepository _proposicaoRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public RemoveProposicaoFromReuniaoRequestHandler(IReuniaoRepository reuniaoRepository,
        IProposicaoRepository proposicaoRepository, IUserRepository userRepository, IMapper mapper)
    {
        _reuniaoRepository = reuniaoRepository;
        _proposicaoRepository = proposicaoRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<AddToPautaDto> Handle(RemoveProposicaoFromReuniaoRequest request,
        CancellationToken cancellationToken)
    {
        var reuniao = await _reuniaoRepository.Get(request.Rid);
        var proposicao = await _proposicaoRepository.Get(request.Pid);
        var responsavel = await _userRepository.Get(request.Uid);

        reuniao.RemoveProposicao(proposicao, responsavel);

        var updatedProposicao = await _proposicaoRepository.Update(proposicao);
        var updatedReuniao = await _reuniaoRepository.Update(reuniao);

        return new AddToPautaDto()
        {
            ProposicaoDto = _mapper.Map<ProposicaoDto>(updatedProposicao),
            ReuniaoDto = _mapper.Map<ReuniaoDto>(updatedReuniao)
        };
    }
}