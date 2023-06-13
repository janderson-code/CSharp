using ProjetoAnime.Core.DomainObjects;

namespace ProjetoAnime.Anime.API.Models;

public class Anime : Entity, IAggregateRoot
{
    public string Nome { get; set; }
    public string Sinopse { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public string NomeOriginal { get; set; }
    public string Imagem { get; set; }
}