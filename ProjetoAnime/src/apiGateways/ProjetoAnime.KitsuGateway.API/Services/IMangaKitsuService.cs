using ProjetoAnime.KitsuGateway.API.Models.Manga;

namespace ProjetoAnime.KitsuGateway.API.Services;

public interface IMangaKitsuService
{
    MangaKitsuResponse obterMangaNome(string nome);
}