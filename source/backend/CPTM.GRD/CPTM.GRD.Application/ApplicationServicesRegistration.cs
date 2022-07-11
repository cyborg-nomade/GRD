using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace CPTM.GRD.Application;

public static class ApplicationServicesRegistration
{
    public static void ConfigureApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
    }
}