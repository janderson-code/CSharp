namespace ProjetoAnime.KitsuGateway.API.Services;

public interface IMangaKitsuService
{
    MangaKitsuResponse obterMangaNome(string nome);
    MangaKitsuResponse MangasEmAlta();
}