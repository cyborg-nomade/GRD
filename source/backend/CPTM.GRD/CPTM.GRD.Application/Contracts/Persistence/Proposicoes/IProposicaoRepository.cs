using CPTM.GRD.Common;
using CPTM.GRD.Domain.Proposicoes;

namespace CPTM.GRD.Application.Contracts.Persistence.Proposicoes;

public interface IProposicaoRepository : IGenericRepository<Proposicao>
{
    Task<IReadOnlyList<Proposicao>> GetByStatus(ProposicaoStatus status, bool arquivada);
    Task<IReadOnlyList<Proposicao>> GetByUser(int uid);
    Task<IReadOnlyList<Proposicao>> GetByGroup(int gid);
    Task<IReadOnlyList<Proposicao>> GetByUserAndStatus(int uid, ProposicaoStatus status, bool arquivada);
    Task<IReadOnlyList<Proposicao>> GetByGroupAndStatus(int gid, ProposicaoStatus status, bool arquivada);
    Task<IReadOnlyList<Proposicao>> GetByReuniao(int rid);
    Task<IReadOnlyList<Proposicao>> GetByReuniaoPrevia(int rid);
    Task<Proposicao?> GetWithReuniao(int pid);
}