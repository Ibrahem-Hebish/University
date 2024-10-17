public class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Configuration.AddEnvironmentVariables();

        builder.Services.AddWeb();

        builder.Services.AddInfrustructure();

        builder.Services.AddServices();

        builder.Services.AddCore();

        var app = builder.Build();

        await app.ConfigureAsync();

        app.Run();
    }
}