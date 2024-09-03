using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EfInfrastructure;

public static class EfInfrastructureServicesExtension
{
    public static IServiceCollection AddEfInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connetString = nameof(FormDbContext);
        services.AddDbContext<FormDbContext>(options => options.UseSqlServer(configuration.GetConnectionString(connetString) ?? throw new InvalidOperationException("Connection string 'WebApplicationContext' not found.")));

        return services;
    }
}
