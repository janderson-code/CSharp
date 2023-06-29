using ProjetoAnime.Manga.API.Data;
using ProjetoAnime.Manga.API.Interfaces;

namespace ProjetoAnime.Manga.API.Configuration;

public static class DependencyInjectionConfig
{
    public static IServiceCollection DIConfigure(this IServiceCollection services)
    {
        services.AddScoped<IMangaRepository, MangaRepository>();
        services.AddScoped<MangaDbContext>();

        return services;
    }
}