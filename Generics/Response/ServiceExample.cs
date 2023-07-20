using System.Net.Http;
using System.Threading.Tasks;

namespace Domain.BankIntegration.Services.BancoRendimento
{
    public partial class RevindicacaoPortabilidadeService : IRevindicacaoPortabilidadeService
    {
        private readonly IHttpClientHelper _httpClientHelper;
        private const string SERVICEURL = "pi/api/v1/service/";

        public RevindicacaoPortabilidadeService(IHttpClientHelper httpClientHelper)
        {
            _httpClientHelper = httpClientHelper;
        }

        private TResponse SerializacaoGenerica<TResponse>(HttpResponseMessage response)
            where TResponse : BankBaseResponse, new()
        {
            if (response == null)
                return new TResponse { IsSuccess = false };

            return response.Deserializar<TResponse>();
        }

        public async Task<IncluirReivindicacaoResponse> IncluirProduto(ProdutoRequest ProdutoRequest)
        {
            return
                SerializacaoGenerica<IncluirReivindicacaoResponse>(_httpClientHelper.Post(SERVICEURL, $"reivindicacoes", revindicacaoPortabilidadeRequest).Result
            );
        }

        public async Task<ConsultarReivindicacaoResponse> ConsultarProdutoById(string cpf, string isp, string id)
        {
            return
                SerializacaoGenerica<ConsultarReivindicacaoResponse>(
                  _httpClientHelper.Get(SERVICEURL, $"produtos/{id}?cpf={incricaoNacional}&Isp={isp}").Result
                );
        }

        public async Task<AlterarStatusReivindicacaoResponse> AlterarStatusProduto(AlterarStatusProdutoRequest AlterarStatusProduto)
        {
            return
             SerializacaoGenerica<AlterarStatusReivindicacaoResponse>(
              _httpClientHelper.Patch(SERVICEURL, $"produtos", AlterarStatusProduto).Result
              );
        }
    }
}