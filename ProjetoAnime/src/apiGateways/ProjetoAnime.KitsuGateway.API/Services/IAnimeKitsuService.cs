using ProjetoAnime.KitsuGateway.API.Models.Anime;

namespace ProjetoAnime.KitsuGateway.API.Services;

public interface IAnimeKitsuService
{
    Models.Anime.AnimeKitsuResponse ObterAnimeNome(string apelido);
}