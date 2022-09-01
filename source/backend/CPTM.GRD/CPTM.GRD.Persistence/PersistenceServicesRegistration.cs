using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Acoes;
using CPTM.GRD.Application.Contracts.Persistence.Acoes.Children;
using CPTM.GRD.Application.Contracts.Persistence.Logging;
using CPTM.GRD.Application.Contracts.Persistence.Proposicoes;
using CPTM.GRD.Application.Contracts.Persistence.Proposicoes.Children;
using CPTM.GRD.Application.Contracts.Persistence.Reunioes;
using CPTM.GRD.Application.Contracts.Persistence.StrictSequenceControl;
using CPTM.GRD.Application.Contracts.Persistence.Views;
using CPTM.GRD.Application.Models.Settings;
using CPTM.GRD.Persistence.Repositories;
using CPTM.GRD.Persistence.Repositories.AccessControl;
using CPTM.GRD.Persistence.Repositories.Acoes;
using CPTM.GRD.Persistence.Repositories.Acoes.Children;
using CPTM.GRD.Persistence.Repositories.Logging;
using CPTM.GRD.Persistence.Repositories.Proposicoes;
using CPTM.GRD.Persistence.Repositories.Proposicoes.Children;
using CPTM.GRD.Persistence.Repositories.Reunioes;
using CPTM.GRD.Persistence.Repositories.StrictSequenceControl;
using CPTM.GRD.Persistence.Repositories.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CPTM.GRD.Persistence;

public static class PersistenceServicesRegistration
{
    public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services,
        IConfiguration configuration, string environmentContentRootPath)
    {
        services.AddDbContext<GrdContext>(options =>
            options.UseOracle(configuration.GetConnectionString("GrdContextConnStr")));

        services.Configure<StrictSequenceControlServiceSettings>(settings =>
            settings.HomeDir = environmentContentRootPath);

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IGroupRepository, GroupRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IAndamentoRepository, AndamentoRepository>();
        services.AddScoped<IAcaoRepository, AcaoRepository>();

        services.AddScoped<IResolucaoRepository, ResolucaoRepository>();
        services.AddScoped<IVotoRepository, VotoRepository>();
        services.AddScoped<IProposicaoRepository, ProposicaoRepository>();

        services.AddScoped<IReuniaoRepository, ReuniaoRepository>();

        services.AddScoped<ILogAcaoRepository, LogAcaoRepository>();
        services.AddScoped<ILogProposicaoRepository, LogProposicaoRepository>();
        services.AddScoped<ILogReuniaoRepository, LogReuniaoRepository>();

        services.AddScoped<IProposicaoStrictSequenceControl, ProposicaoStrictSequenceControl>();
        services.AddScoped<IReuniaoStrictSequenceControl, ReuniaoStrictSequenceControl>();


        services.AddScoped<IViewUsuarioRepository, ViewUsuarioRepository>();
        services.AddScoped<IViewEstruturaRepository, ViewEstruturaRepository>();


        return services;
    }
}