using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SalesApi.ORM.Contexts;
using SalesApi.ORM.Repositories;

namespace SalesApi.IoC.ModuleInitializers;

public class InfrastructureModuleInitializer : IModuleInitializer
{
    public void Initialize(WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<SalesDbContext>(options => 
            SalesDbContextFactory.ConfigureDbContextOptions(options, builder.Configuration));

        builder.Services.AddScoped<ISaleRepository, SaleRepository>();
    }
}
