using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;

namespace SalesApi.ORM.Contexts;

public class SalesDbContextFactory : IDesignTimeDbContextFactory<SalesDbContext>
{
    public SalesDbContext CreateDbContext(string[] args) => CreateDbContext();

    public static SalesDbContext CreateDbContext()
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<SalesDbContext>();
        ConfigureDbContextOptions(builder, configuration);

        return new SalesDbContext(builder.Options);
    }

    public static void ConfigureDbContextOptions(DbContextOptionsBuilder builder, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("SalesDbConnection");

        builder.UseNpgsql(
            connectionString,
            b => b.MigrationsAssembly($"{nameof(SalesApi)}.{nameof(ORM)}")
                  .MigrationsHistoryTable(HistoryRepository.DefaultTableName, SalesDbContext.Schema)
                  .EnableRetryOnFailure()
        );
    }
}
