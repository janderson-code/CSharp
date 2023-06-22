using ProjetoAnime.KitsuGateway.API.Models.Anime;

namespace ProjetoAnime.KitsuGateway.API.Services;

public interface IAnimeKitsuService
{
    AnimeKitsuResponse ObterAnimeNome(string apelido);
    AnimeKitsuResponse AnimesEmAlta();
}