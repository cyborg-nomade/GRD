﻿using CPTM.GRD.Domain.Acoes;

namespace CPTM.GRD.Application.Contracts.Persistence.Acoes;

public interface IAcaoRepository : IGenericRepository<Acao>
{
    Task<IReadOnlyList<Acao>> GetByReuniao(int rid);
    Task<IReadOnlyList<Acao>> GetByResponsavel(int uid);
    Task<IReadOnlyList<Acao>> GetFromSubordinados(int suid);
}