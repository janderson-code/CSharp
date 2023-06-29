using ProjetoAnime.Anime.API.Data;
using ProjetoAnime.Anime.API.Models;

namespace ProjetoAnime.Anime.API.Configuration;

public static class DependencyInjectionConfig
{
    public static IServiceCollection DIConfigure(this IServiceCollection services)
    {
        services.AddScoped<IAnimeRepository, AnimeRepository>();
        services.AddScoped<AnimeDbContext>();

        return services;
    }
}