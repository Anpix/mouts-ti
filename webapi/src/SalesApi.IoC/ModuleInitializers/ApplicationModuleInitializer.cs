using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SalesApi.Application;

namespace SalesApi.IoC.ModuleInitializers;

public class ApplicationModuleInitializer : IModuleInitializer
{
    public void Initialize(WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(typeof(ApplicationLayer).Assembly);

        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(ApplicationLayer).Assembly));
    }
}
