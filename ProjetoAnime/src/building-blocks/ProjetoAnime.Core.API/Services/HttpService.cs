namespace ProjetoAnime.Core.API.Services;

public class HttpService : IHttpService
{
    private HttpClient _httpClient;

    public HttpService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        // _httpClient.DefaultRequestHeaders.Accept.Clear();
        // _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }
    public async Task<HttpResponseMessage> Post(string endPoint, object sendObject)
    {
        return _httpClient.PostAsJsonAsync($"{endPoint}", sendObject).Result;
    }

    public async Task<HttpResponseMessage> Get(string endPoint)
    {
        return _httpClient.GetAsync($"{endPoint}").Result;
    }
}