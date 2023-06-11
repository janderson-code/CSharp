using System.Net;
using System.Text;
using Newtonsoft.Json;
using ProjetoAnime.Core.Communication;

namespace ProjetoAnime.Core.API.Services;

public abstract class Service
{
    public Service()
    {
    }

    protected StringContent ObterConteudo(object dados)
    {
        return new StringContent(JsonConvert.SerializeObject(dados), Encoding.UTF8, "application/json");
    }

    protected async Task<T> DeserializarObjetoResponse<T>(HttpResponseMessage responseMessage)
    {
        string responseContent = await responseMessage.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(responseContent);
    }

    protected bool TratarErrosResponse(HttpResponseMessage response)
    {
        if (response.StatusCode == HttpStatusCode.BadRequest) return false;

        response.EnsureSuccessStatusCode();
        return true;
    }

    protected ResponseResult RetornoOk()
    {
        return new ResponseResult();
    }
}