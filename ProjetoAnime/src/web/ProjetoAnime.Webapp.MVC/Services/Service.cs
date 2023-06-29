using Newtonsoft.Json;
using ProjetoAnime.Core.Communication;
using ProjetoAnime.Webapp.MVC.Extensions;
using System.Text;

namespace ProjetoAnime.Webapp.MVC.Services;

public abstract class Service
{
    protected StringContent ObterConteudo(object dados)
    {
        return new StringContent(JsonConvert.SerializeObject(dados), Encoding.UTF8, "application/json");
    }

    protected async Task<T> DeserializarObjetoResponse<T>(HttpResponseMessage responseMessage)
    {
        string content = responseMessage.Content.ReadAsStringAsync().Result;
        return JsonConvert.DeserializeObject<T>(content);
    }

    protected bool TratarErrosResponse(HttpResponseMessage response)
    {
        switch ((int)response.StatusCode)
        {
            case 401:
            case 403:
            case 404:
            case 500:
                throw new CustomHttpRequestException(response.StatusCode);
            case 400:
                return false;
        }

        response.EnsureSuccessStatusCode();
        return true;
    }

    protected ResponseResult RetornoOk()
    {
        return new ResponseResult();
    }
}