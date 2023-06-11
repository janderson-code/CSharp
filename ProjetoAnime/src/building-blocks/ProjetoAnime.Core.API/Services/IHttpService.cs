namespace ProjetoAnime.Core.API.Services;

public interface IHttpService
{
    Task<HttpResponseMessage> Post(string endPoint, Object sendObject);
    Task<HttpResponseMessage> Get(string endPoint);
}