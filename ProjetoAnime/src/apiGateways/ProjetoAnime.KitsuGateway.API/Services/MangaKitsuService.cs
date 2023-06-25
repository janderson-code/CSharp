namespace ProjetoAnime.KitsuGateway.API.Services;

public class MangaKitsuService : Service, IMangaKitsuService
{
    private readonly IHttpService _httpService;

    public MangaKitsuService(IHttpService httpService)
    {
        _httpService = httpService;
    }

    public MangaKitsuResponse obterMangaNome(string nome)
    {
        string nomeManga = nome.ToLower().Replace(" ", "-");
        var response = _httpService.Get($"https://kitsu.io/api/edge/manga?filter[slug]={nomeManga}").Result;
        TratarErrosResponse(response);
        var content = DeserializarObjetoResponse<MangaKitsuResponse>(response).Result;
        return content;
    }
}