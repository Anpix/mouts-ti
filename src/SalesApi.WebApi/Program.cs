using SalesApi.WebApi.Config;

namespace SalesApi.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddApiConfig(builder.Configuration);
            builder.Services.AddDependencyInjection();

            var app = builder.Build();

            app.UseApiConfig();
            app.Run();
        }
    }
}
