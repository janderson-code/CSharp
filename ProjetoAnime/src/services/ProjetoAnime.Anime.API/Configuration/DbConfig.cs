using Microsoft.EntityFrameworkCore;
using ProjetoAnime.Anime.API.Data;

namespace ProjetoAnime.Anime.API.Configuration;

public static class DbConfig
{
    public static IServiceCollection AddDbContextConfig(this IServiceCollection services, IConfiguration configuration)
    {
        
        services.AddControllersWithViews();
        services.AddDbContext<AnimeDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        return services;
    }

    public static IApplicationBuilder AddConfigureMigrate(this IApplicationBuilder app)
    {
        
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var services = scope.ServiceProvider;
            try
            {
                var dbContext = services.GetRequiredService<AnimeDbContext>();
                dbContext.Database.Migrate();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao migrar o banco de dados: " + ex.Message);
            }
        }

        return app;
    }
}