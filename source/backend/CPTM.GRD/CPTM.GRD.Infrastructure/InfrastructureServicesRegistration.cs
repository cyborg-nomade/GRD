using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Util;
using CPTM.GRD.Application.Models.Settings;
using CPTM.GRD.Infrastructure.Authentication;
using CPTM.GRD.Infrastructure.Email;
using CPTM.GRD.Infrastructure.FileManagement;
using CPTM.GRD.Infrastructure.Util;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CPTM.GRD.Infrastructure;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration, string environmentContentRootPath)
    {
        services.Configure<EmailServiceSettings>(configuration.GetSection("EmailServiceSettings"));
        services.Configure<FileManagerServiceSettings>((settings) => settings.HomeDir = environmentContentRootPath);
        services.Configure<AuthenticationServiceSettings>(configuration.GetSection("AuthenticationServiceSettings"));

        services.AddTransient<IEmailService, EmailService>();
        services.AddTransient<IFileManagerService, FileManagerService>();
        services.AddTransient<IAuthenticationService, AuthenticationService>();
        services.AddTransient<IDifferentiator, Differentiator>();
        return services;
    }
}