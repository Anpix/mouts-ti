using SalesApi.ORM.Contexts;

namespace SalesApi.WebApi.Config;

public static class ApiConfig
{
    public static IServiceCollection AddApiConfig(this IServiceCollection services, IConfiguration configuration)
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

    public static WebApplication UseApiConfig(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        return app;
    }

}
