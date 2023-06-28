namespace ProjetoAnime.Webapp.MVC.Services
{
    public class TradutorServiceDeepL : ITradutorService
    {
        private readonly HttpClient _httpClient;
        private const string DeepLApiUrl = "https://api-free.deepl.com/v2/translate";

        public TradutorServiceDeepL(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> TranslateText(string text, string targetLanguage)
        {
            // Configurar a requisição
            var request = new HttpRequestMessage(HttpMethod.Post, DeepLApiUrl);
            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(text), "text");
            formData.Add(new StringContent(targetLanguage), "target_lang");
            formData.Add(new StringContent("YOUR_AUTH_KEY"), "auth_key"); // Substitua "YOUR_AUTH_KEY" pela sua chave de autenticação do DeepL

            request.Content = formData;

            // Enviar a requisição
            var response = await _httpClient.SendAsync(request);

            // Processar a resposta
            var responseBody = await response.Content.ReadAsStringAsync();

            // Aqui você pode fazer o parsing da resposta para obter a tradução desejada
            // O formato da resposta depende da estrutura do JSON retornado pelo DeepL

            return responseBody;
        }
    }
}
