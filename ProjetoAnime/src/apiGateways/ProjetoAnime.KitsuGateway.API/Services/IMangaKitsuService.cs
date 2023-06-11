using ProjetoAnime.KitsuGateway.API.Models.Manga;

namespace ProjetoAnime.KitsuGateway.API.Services;

public interface IMangaKitsuService
{
    Manga obterMangaNome(string nome);
}