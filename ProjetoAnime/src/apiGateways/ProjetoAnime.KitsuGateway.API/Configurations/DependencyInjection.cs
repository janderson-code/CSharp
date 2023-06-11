using ProjetoAnime.Core.API.Services;
using ProjetoAnime.KitsuGateway.API.Services;

namespace ProjetoAnime.Anime.KitsuGateway.Configurations;

public static class DependencyInjection
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IAnimeKitsuService, AnimeKitsuService>();
        services.AddHttpClient<IHttpService, HttpService>();
    }
}