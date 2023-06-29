namespace ProjetoAnime.Identidade.API.Configurations;

public class Startup : IStartup
{
    public IConfiguration Configuration { get; }
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void Configure(WebApplication app, IWebHostEnvironment env)
    {
        app.UseApiConfig(env);
    }

    public void ConfigureService(IServiceCollection services)
    {

        services.AddApiConfig(Configuration);
    }
}