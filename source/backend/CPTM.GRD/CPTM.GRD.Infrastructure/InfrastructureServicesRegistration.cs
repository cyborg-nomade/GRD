using System.Text;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Util;
using CPTM.GRD.Application.Models.Settings;
using CPTM.GRD.Infrastructure.Authentication;
using CPTM.GRD.Infrastructure.Email;
using CPTM.GRD.Infrastructure.FileManagement;
using CPTM.GRD.Infrastructure.Util;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace CPTM.GRD.Infrastructure;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration, string environmentContentRootPath)
    {
        services.Configure<EmailServiceSettings>(configuration.GetSection("EmailServiceSettings"));
        services.Configure<FileManagerServiceSettings>((settings) => settings.HomeDir = environmentContentRootPath);
        services.Configure<AuthenticationServiceSettings>(configuration.GetSection("AuthenticationServiceSettings"));
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

        services.AddTransient<IEmailService, EmailService>();
        services.AddTransient<IFileManagerService, FileManagerService>();
        services.AddTransient<IAuthenticationService, AuthenticationService>();
        services.AddTransient<IDifferentiator, Differentiator>();

        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"],
                    IssuerSigningKey =
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
                };
            });

        return services;
    }
}