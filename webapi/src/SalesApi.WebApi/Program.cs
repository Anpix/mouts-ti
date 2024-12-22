using SalesApi.IoC.Resolvers;

namespace SalesApi.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.RegisterDependencies();

            var app = builder.Build();

            app.UseDependencies();
            app.Run();
        }
    }
}
