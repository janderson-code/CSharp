using Microsoft.EntityFrameworkCore;
using ProjetoAnime.Manga.API.Data;

namespace ProjetoAnime.Manga.API.Configuration;

public static class DbConfig
{
    public static IServiceCollection AddDbContextConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllersWithViews();
        services.AddDbContext<MangaDbContext>(options =>
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
                var dbContext = services.GetRequiredService<MangaDbContext>();
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