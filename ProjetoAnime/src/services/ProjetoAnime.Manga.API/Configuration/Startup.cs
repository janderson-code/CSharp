using ProjetoAnime.Anime.API.Configuration;

namespace ProjetoAnime.Manga.API.Configuration;

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

        app.AddConfigureMigrate();
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
    }

    public void ConfigureService(IServiceCollection services)
    {
        services.DIConfigure();
        services.AddDbContextConfig(Configuration);
        services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerConfiguration();
    }
}