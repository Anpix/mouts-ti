using Microsoft.AspNetCore.Builder;
using SalesApi.IoC.ModuleInitializers;

namespace SalesApi.IoC.Resolvers;

public static class DependencyRegistryResolver
{
    public static void RegisterDependencies(this WebApplicationBuilder builder)
    {
        new ApplicationModuleInitializer().Initialize(builder);
        new InfrastructureModuleInitializer().Initialize(builder);
        new WebApiModuleInitializer().Initialize(builder);
    }
}
