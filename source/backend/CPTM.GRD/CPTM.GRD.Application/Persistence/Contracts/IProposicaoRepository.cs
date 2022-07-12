using CPTM.GRD.Common;
using CPTM.GRD.Domain;

namespace CPTM.GRD.Application.Persistence.Contracts;

public interface IProposicaoRepository : IGenericRepository<Proposicao>
{
    Task<IReadOnlyList<Proposicao>> GetByStatus(ProposicaoStatus status);
    Task<IReadOnlyList<Proposicao>> GetByUser(int uid);
    Task<IReadOnlyList<Proposicao>> GetByGroup(int gid);
    Task<IReadOnlyList<Proposicao>> GetByUserAndStatus(int uid, ProposicaoStatus status);
    Task<IReadOnlyList<Proposicao>> GetByGroupAndStatus(int gid, ProposicaoStatus status);
    Task<IReadOnlyList<Proposicao>> GetByReuniao(int rid);
    Task<IReadOnlyList<Proposicao>> GetByReuniaoPrevia(int rid);
}