using ProjetoAnime.Core.API.Services;

namespace ProjetoAnime.KitsuGateway.API.Services;

public class AnimeKitsuService : Service,IAnimeKitsuService
{
    private readonly IHttpService _httpService;

    public AnimeKitsuService(IHttpService httpService)
    {
        _httpService = httpService;
    }
    public string ObterAnimeApelido(string apelido)
    {
        string procura = apelido.ToLower().Replace(" ", "-");
        var response = _httpService.Get($"https://kitsu.io/api/edge/anime?filter[slug]={procura}").Result;
        TratarErrosResponse(response);
        var content = response.Content.ReadAsStringAsync().Result;
        return content;
    }
}