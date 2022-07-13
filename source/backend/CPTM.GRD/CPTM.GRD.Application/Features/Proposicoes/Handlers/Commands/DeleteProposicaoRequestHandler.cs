using AutoMapper;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.Features.Proposicoes.Requests.Commands;
using CPTM.GRD.Application.Persistence.Contracts.Logging;
using CPTM.GRD.Common;
using CPTM.GRD.Domain.Logging;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Handlers.Commands;

public class DeleteProposicaoRequestHandler : IRequestHandler<DeleteProposicaoRequest>
{
    private readonly IProposicaoRepository _proposicaoRepository;
    private readonly ILogProposicaoRepository _logProposicaoRepository;
    private readonly IMapper _mapper;

    public DeleteProposicaoRequestHandler(IProposicaoRepository proposicaoRepository,
        ILogProposicaoRepository logProposicaoRepository, IMapper mapper)
    {
        _proposicaoRepository = proposicaoRepository;
        _logProposicaoRepository = logProposicaoRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(DeleteProposicaoRequest request, CancellationToken cancellationToken)
    {
        var proposicao = await _proposicaoRepository.Get(request.Id);
        var removeLog = new LogProposicao()
        {
            Data = DateTime.Now,
            Tipo = TipoLogProposicao.Remocao,
            Diferenca = "Remoção",
            ProposicaoId = $@"WAS IDPRD {proposicao.IdPrd}",
            UsuarioResp = proposicao.Criador,
        };
        await _logProposicaoRepository.Add(removeLog);

        await _proposicaoRepository.Delete(request.Id);
        return Unit.Value;
    }
}