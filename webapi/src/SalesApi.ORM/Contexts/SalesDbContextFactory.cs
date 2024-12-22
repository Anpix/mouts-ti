using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;

namespace SalesApi.ORM.Contexts;

public class SalesDbContextFactory : IDesignTimeDbContextFactory<SalesDbContext>
{
    public static readonly string ConnectionString = "SalesDbConnection";

    public SalesDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<SalesDbContext>();
        var connectionString = configuration.GetConnectionString(ConnectionString);

        builder.UseNpgsql(
            connectionString,
            b => b.MigrationsAssembly($"{nameof(SalesApi)}.{nameof(ORM)}")
                  .MigrationsHistoryTable(HistoryRepository.DefaultTableName, SalesDbContext.Schema)
                  .EnableRetryOnFailure()

        );

        return new SalesDbContext(builder.Options);
    }
}
