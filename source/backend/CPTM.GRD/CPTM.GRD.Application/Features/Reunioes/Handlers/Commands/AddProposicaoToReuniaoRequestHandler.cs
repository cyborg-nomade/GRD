using AutoMapper;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Proposicoes;
using CPTM.GRD.Application.Contracts.Persistence.Reunioes;
using CPTM.GRD.Application.DTOs.Main.Mixed;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.DTOs.Main.Reuniao;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Application.Features.Reunioes.Requests.Commands;
using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Handlers.Commands;

public class
    AddProposicaoToReuniaoRequestHandler : IRequestHandler<AddProposicaoToReuniaoRequest, AddProposicaoToReuniaoDto>
{
    private readonly IProposicaoRepository _proposicaoRepository;
    private readonly IReuniaoRepository _reuniaoRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public AddProposicaoToReuniaoRequestHandler(IProposicaoRepository proposicaoRepository,
        IReuniaoRepository reuniaoRepository, IUserRepository userRepository, IMapper mapper)
    {
        _proposicaoRepository = proposicaoRepository;
        _reuniaoRepository = reuniaoRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<AddProposicaoToReuniaoDto> Handle(AddProposicaoToReuniaoRequest request,
        CancellationToken cancellationToken)
    {
        var reuniaoExists = await _reuniaoRepository.Exists(request.Rid);

        if (!reuniaoExists)
        {
            throw new NotFoundException("Reunião", reuniaoExists);
        }

        var proposicaoExists = await _proposicaoRepository.Exists(request.Pid);

        if (!proposicaoExists)
        {
            throw new NotFoundException("Proposição", proposicaoExists);
        }

        var responsavelExists = await _userRepository.Exists(request.Uid);

        if (!responsavelExists)
        {
            throw new NotFoundException("Usuário", responsavelExists);
        }

        var proposicao = await _proposicaoRepository.Get(request.Pid);
        var reuniao = await _reuniaoRepository.Get(request.Rid);
        var responsavel = await _userRepository.Get(request.Uid);

        reuniao.AddProposicao(proposicao, responsavel);

        var updatedReuniao = await _reuniaoRepository.Update(reuniao);

        return new AddProposicaoToReuniaoDto()
        {
            ProposicaoDto = _mapper.Map<ProposicaoDto>(proposicao),
            ReuniaoDto = _mapper.Map<ReuniaoDto>(updatedReuniao)
        };
    }
}