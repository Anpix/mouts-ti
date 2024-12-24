using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SalesApi.Common.Extensions;
using SalesApi.Common.Middlewares;

namespace SalesApi.IoC.ModuleInitializers;

public class WebApiModuleInitializer : IModuleInitializer
{
    public void Initialize(WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<ExceptionHandlingMiddleware>();
        
        builder.AddBasicHealthChecks();
        builder.Services.AddAuthorization();
        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
    }
}
