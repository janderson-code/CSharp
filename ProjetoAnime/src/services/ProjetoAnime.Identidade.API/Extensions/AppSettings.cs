namespace ProjetoAnime.Identidade.API.Extensions;

public class AppSettings
{
    public string Secret { get; set; } // Chave
    public double ExpiracaoHoras { get; set; }
    public string Emissor { get; set; }
    public string ValidoEm { get; set; } // Audiencia
}