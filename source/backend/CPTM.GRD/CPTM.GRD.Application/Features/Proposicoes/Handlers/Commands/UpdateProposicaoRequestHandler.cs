using AutoMapper;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Proposicoes;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.Features.Proposicoes.Requests.Commands;
using CPTM.GRD.Application.Util;
using CPTM.GRD.Domain.Proposicoes;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Handlers.Commands;

public class UpdateProposicaoRequestHandler : IRequestHandler<UpdateProposicaoRequest, ProposicaoDto>
{
    private readonly IProposicaoRepository _proposicaoRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UpdateProposicaoRequestHandler(IProposicaoRepository proposicaoRepository, IUserRepository userRepository,
        IMapper mapper)
    {
        _proposicaoRepository = proposicaoRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<ProposicaoDto> Handle(UpdateProposicaoRequest request, CancellationToken cancellationToken)
    {
        var savedProposicao = await _proposicaoRepository.Get(request.ProposicaoDto.Id);
        var responsavel = await _userRepository.Get(request.Uid);

        savedProposicao.OnUpdate(responsavel,
            Differentiator.GetDifferenceString<Proposicao>(savedProposicao,
                _mapper.Map<Proposicao>(request.ProposicaoDto)));

        _mapper.Map(request.ProposicaoDto, savedProposicao);

        var updatedProposicao = await _proposicaoRepository.Update(savedProposicao);
        return _mapper.Map<ProposicaoDto>(updatedProposicao);
    }
}