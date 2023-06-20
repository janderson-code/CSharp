using ProjetoAnime.Core.Data;

namespace ProjetoAnime.Anime.API.Models;

public interface IAnimeRepository : IRepository<Anime>
{
    Task<IEnumerable<Anime>> obterTodosAnimes();
    Task<Anime> ObterPorId(Guid id);
    void Adicionar(Anime anime);
    void Atualizar(Anime anime);
}