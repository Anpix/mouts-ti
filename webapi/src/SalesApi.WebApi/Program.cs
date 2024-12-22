using SalesApi.WebApi.Config;

namespace SalesApi.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddConfig(builder.Configuration);
            
            var app = builder.Build();

            app.UseConfig();
            app.Run();
        }
    }
}
