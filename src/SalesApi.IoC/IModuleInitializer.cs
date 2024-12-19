using Microsoft.AspNetCore.Builder;

namespace SalesApi.IoC;

public interface IModuleInitializer
{
    void Initialize(WebApplicationBuilder builder);
}
