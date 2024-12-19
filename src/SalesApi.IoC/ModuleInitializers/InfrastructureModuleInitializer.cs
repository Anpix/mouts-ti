using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SalesApi.Domain.Repositories;
using SalesApi.ORM.Contexts;
using SalesApi.ORM.Repositories;

namespace SalesApi.IoC.ModuleInitializers;

public class InfrastructureModuleInitializer : IModuleInitializer
{
    public void Initialize(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<DbContext>(provider => provider.GetRequiredService<SalesDbContext>());
        builder.Services.AddScoped<ISaleRepository, SaleRepository>();
    }
}
