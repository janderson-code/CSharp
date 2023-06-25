using System.Net;
using Microsoft.Extensions.Options;
using ProjetoAnime.Webapp.MVC.Extensions;
using ProjetoAnime.Webapp.MVC.Models.Anime;

namespace ProjetoAnime.Webapp.MVC.Services;

public class KitsuService : Service, IKitsuService
{
    private readonly HttpClient _httpClient;

    public KitsuService(HttpClient httpClient, IOptions<AppSettings> settings)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(settings.Value.AnimeKitsuUrl);
        // Ignorar a verificação do certificado SSL
        ServicePointManager.ServerCertificateValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
    }

    public async Task<AnimeKitsuViewModel> ObterAnimesAlta()
    {
        var response = await _httpClient.GetAsync($"anime-em-alta");
        TratarErrosResponse(response);
        var obj = DeserializarObjetoResponse<AnimeKitsuViewModel>(response).Result;
        return obj;
    }
}

public interface IKitsuService
{
    Task<AnimeKitsuViewModel> ObterAnimesAlta();
}