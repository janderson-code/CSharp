using ProjetoAnime.Core.API.Services;
using ProjetoAnime.KitsuGateway.API.Models.Anime;

namespace ProjetoAnime.KitsuGateway.API.Services;

public class AnimeKitsuService : Service,IAnimeKitsuService
{
    private readonly IHttpService _httpService;

    public AnimeKitsuService(IHttpService httpService)
    {
        _httpService = httpService;
    }
    public AnimeKitsuResponse ObterAnimeNome(string nome)
    {
        string nomeAnime = nome.ToLower().Replace(" ", "-");
        var response = _httpService.Get($"https://kitsu.io/api/edge/anime?filter[slug]={nomeAnime}").Result;
        TratarErrosResponse(response);
        var content = DeserializarObjetoResponse<AnimeKitsuResponse>(response).Result;
        return content;
    }

    public AnimeKitsuResponse AnimesEmAlta()
    {
        var response = _httpService.Get("https://kitsu.io/api/edge/trending/anime").Result;
        TratarErrosResponse(response);
        var content = DeserializarObjetoResponse<AnimeKitsuResponse>(response).Result;
        return content;
    }
}