using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Acoes;
using CPTM.GRD.Application.Contracts.Persistence.Acoes.Children;
using CPTM.GRD.Application.Contracts.Persistence.Logging;
using CPTM.GRD.Application.Contracts.Persistence.Proposicoes;
using CPTM.GRD.Application.Contracts.Persistence.Proposicoes.Children;
using CPTM.GRD.Application.Contracts.Persistence.Reunioes;
using CPTM.GRD.Application.Contracts.Persistence.Reunioes.Children;
using CPTM.GRD.Application.Contracts.Persistence.Views;

namespace CPTM.GRD.Application.Contracts.Persistence;

public interface IUnitOfWork : IDisposable
{
    IUserRepository UserRepository { get; }
    IGroupRepository GroupRepository { get; }

    IAcaoRepository AcaoRepository { get; }
    IAndamentoRepository AndamentoRepository { get; }

    IProposicaoRepository ProposicaoRepository { get; }
    IResolucaoRepository ResolucaoRepository { get; }
    IVotoRepository VotoRepository { get; }

    IReuniaoRepository ReuniaoRepository { get; }
    IParticipanteRepository ParticipanteRepository { get; }

    ILogAcaoRepository LogAcaoRepository { get; }
    ILogProposicaoRepository LogProposicaoRepository { get; }
    ILogReuniaoRepository LogReuniaoRepository { get; }

    IViewUsuarioRepository ViewUsuarioRepository { get; }
    IViewEstruturaRepository ViewEstruturaRepository { get; }
    Task Save();
}