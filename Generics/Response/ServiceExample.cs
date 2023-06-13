using Domain.BankIntegration.Interfaces;
using Domain.BankIntegration.Models.BancoRendimento.Response;
using Domain.BankIntegration.Models.Request;
using System.Net.Http;
using System.Threading.Tasks;

namespace Domain.BankIntegration.Services.BancoRendimento
{
    public partial class RevindicacaoPortabilidadeService : IRevindicacaoPortabilidadeService
    {
        private readonly IHttpClientHelper _httpClientHelper;
        private const string SERVICEURL = "pi/api/v1/Reivindicacao/";

        public RevindicacaoPortabilidadeService(IHttpClientHelper httpClientHelper)
        {
            _httpClientHelper = httpClientHelper;
        }

        private TResponse Reivindicacao<TResponse>(HttpResponseMessage response)
            where TResponse : BankBaseResponse, new()
        {
            if (response == null)
                return new TResponse { IsSuccess = false };

            return response.Deserializar<TResponse>();
        }

        public async Task<IncluirReivindicacaoResponse> IncluirReivindicacao(RevindicacaoPortabilidadeRequest revindicacaoPortabilidadeRequest)
        {
            return
                Reivindicacao<IncluirReivindicacaoResponse>(_httpClientHelper.Post(SERVICEURL, $"reivindicacoes", revindicacaoPortabilidadeRequest).Result
            );
        }

        public async Task<ConsultarReivindicacaoResponse> ConsultarReivindicacaoById(string incricaoNacional, string ispbParticipante, string reivindicacaoId)
        {
            return
                Reivindicacao<ConsultarReivindicacaoResponse>(
                  _httpClientHelper.Get(SERVICEURL, $"reivindicacoes/{reivindicacaoId}?InscricaoNacional={incricaoNacional}&IspbParticipante={ispbParticipante}").Result
                );
        }

        public async Task<AlterarStatusReivindicacaoResponse> AlterarStatusReivindicacao(AlterarStatusReivindicacaoRequest alterarStatusReivindicacaoRequest)
        {
            return
             Reivindicacao<AlterarStatusReivindicacaoResponse>(
              _httpClientHelper.Patch(SERVICEURL, $"reivindicacoes", alterarStatusReivindicacaoRequest).Result
              );
        }
    }
}