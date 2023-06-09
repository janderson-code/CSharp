namespace ProjetoAnime.Core.API.Identidade;

public class AppSettings
{
    public string Secret{ get; set; } // Chave
    public string ExpiracaoHoras { get; set; } 
    public string Emissor{ get; set; } 
    public string ValidoEm{ get; set; } // Audiencia
}