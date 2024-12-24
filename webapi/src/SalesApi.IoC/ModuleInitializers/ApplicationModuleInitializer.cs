using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SalesApi.Application;
using SalesApi.Common.Validation;

namespace SalesApi.IoC.ModuleInitializers;

public class ApplicationModuleInitializer : IModuleInitializer
{
    public void Initialize(WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(typeof(ApplicationLayer).Assembly);
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(ApplicationLayer).Assembly));

        builder.Services.AddValidatorsFromAssembly(typeof(ApplicationLayer).Assembly);
        builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    }
}
