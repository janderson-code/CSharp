using ProjetoAnime.Core.Data;

namespace ProjetoAnime.Manga.API.Interfaces;

public interface IMangaRepository : IRepository<Models.Manga>
{
    Task<IEnumerable<Models.Manga>> obterTodosMangas();

    Task<Models.Manga> ObterPorId(Guid id);

    void Adicionar(Models.Manga anime);

    void Atualizar(Models.Manga anime);
}