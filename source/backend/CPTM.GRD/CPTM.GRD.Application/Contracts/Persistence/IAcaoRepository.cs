using CPTM.GRD.Domain.Acoes;

namespace CPTM.GRD.Application.Contracts.Persistence;

public interface IAcaoRepository : IGenericRepository<Acao>
{
    Task<IReadOnlyList<Acao>> GetByReuniao(int rid);
}