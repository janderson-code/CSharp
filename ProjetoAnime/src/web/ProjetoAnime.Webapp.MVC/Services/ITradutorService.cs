namespace ProjetoAnime.Webapp.MVC.Services
{
    public interface ITradutorService
    {
        public Task<string> TranslateText(string text, string targetLanguage);
    }
}