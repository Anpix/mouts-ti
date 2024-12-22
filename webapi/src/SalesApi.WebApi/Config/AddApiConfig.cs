using SalesApi.ORM.Contexts;

namespace SalesApi.WebApi.Config;

public static class AddApiConfig
{
    public static IServiceCollection AddConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();

        #region Database
        services.AddDbContext<SalesDbContext>();
        #endregion

        #region Versioning
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        #endregion

        return services;
    }
}
