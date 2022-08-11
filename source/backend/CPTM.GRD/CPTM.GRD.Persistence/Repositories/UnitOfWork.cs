using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Acoes;
using CPTM.GRD.Application.Contracts.Persistence.Acoes.Children;
using CPTM.GRD.Application.Contracts.Persistence.Logging;
using CPTM.GRD.Application.Contracts.Persistence.Proposicoes;
using CPTM.GRD.Application.Contracts.Persistence.Proposicoes.Children;
using CPTM.GRD.Application.Contracts.Persistence.Reunioes;
using CPTM.GRD.Application.Contracts.Persistence.Views;
using CPTM.GRD.Persistence.Repositories.AccessControl;
using CPTM.GRD.Persistence.Repositories.Acoes;
using CPTM.GRD.Persistence.Repositories.Acoes.Children;
using CPTM.GRD.Persistence.Repositories.Logging;
using CPTM.GRD.Persistence.Repositories.Proposicoes;
using CPTM.GRD.Persistence.Repositories.Proposicoes.Children;
using CPTM.GRD.Persistence.Repositories.Reunioes;
using CPTM.GRD.Persistence.Repositories.Views;

namespace CPTM.GRD.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly GrdContext _grdContext;
    private readonly IUserRepository? _userRepository;
    private readonly IGroupRepository? _groupRepository;
    private readonly IAcaoRepository? _acoesRepository;
    private readonly IAndamentoRepository? _andamentoRepository;
    private readonly IProposicaoRepository? _proposicaoRepository;
    private readonly IResolucaoRepository? _resolucaoRepository;
    private readonly IVotoRepository? _votoRepository;
    private readonly IReuniaoRepository? _reuniaoRepository;
    private readonly ILogAcaoRepository? _logAcaoRepository;
    private readonly ILogProposicaoRepository? _logProposicaoRepository;
    private readonly ILogReuniaoRepository? _logReuniaoRepository;
    private readonly IViewUsuarioRepository? _viewUsuarioRepository;
    private readonly IViewEstruturaRepository? _viewEstruturaRepository;

    public UnitOfWork(GrdContext grdContext)
    {
        _grdContext = grdContext;
    }

    public IUserRepository UserRepository => _userRepository ?? new UserRepository(_grdContext);

    public IGroupRepository GroupRepository => _groupRepository ?? new GroupRepository(_grdContext);

    public IAcaoRepository AcaoRepository => _acoesRepository ?? new AcaoRepository(_grdContext);

    public IAndamentoRepository AndamentoRepository => _andamentoRepository ?? new AndamentoRepository(_grdContext);

    public IProposicaoRepository ProposicaoRepository => _proposicaoRepository ?? new ProposicaoRepository(_grdContext);

    public IResolucaoRepository ResolucaoRepository => _resolucaoRepository ?? new ResolucaoRepository(_grdContext);

    public IVotoRepository VotoRepository => _votoRepository ?? new VotoRepository(_grdContext);

    public IReuniaoRepository ReuniaoRepository => _reuniaoRepository ?? new ReuniaoRepository(_grdContext);

    public ILogAcaoRepository LogAcaoRepository => _logAcaoRepository ?? new LogAcaoRepository(_grdContext);

    public ILogProposicaoRepository LogProposicaoRepository =>
        _logProposicaoRepository ?? new LogProposicaoRepository(_grdContext);

    public ILogReuniaoRepository LogReuniaoRepository => _logReuniaoRepository ?? new LogReuniaoRepository(_grdContext);

    public IViewUsuarioRepository ViewUsuarioRepository =>
        _viewUsuarioRepository ?? new ViewUsuarioRepository(_grdContext);

    public IViewEstruturaRepository ViewEstruturaRepository =>
        _viewEstruturaRepository ?? new ViewEstruturaRepository(_grdContext);

    public void Dispose()
    {
        _grdContext.Dispose();
        GC.SuppressFinalize(this);
    }

    public async Task Save()
    {
        await _grdContext.SaveChangesAsync();
    }
}