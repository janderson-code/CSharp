namespace ProjetoAnime.Anime.API.Configuration;

public class Startup : IStartup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void Configure(WebApplication app, IWebHostEnvironment env)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwaggerConfiguration();
        }

        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        app.AddConfigureMigrate();
    }

    public void ConfigureService(IServiceCollection services)
    {
        services.AddControllers();
        services.DIConfigure();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerConfiguration();
        services.AddDbContextConfig(Configuration);
    }
}