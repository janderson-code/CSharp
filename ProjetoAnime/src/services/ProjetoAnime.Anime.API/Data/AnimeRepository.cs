using System.Runtime.Intrinsics.X86;
using Microsoft.EntityFrameworkCore;
using ProjetoAnime.Anime.API.Models;
using ProjetoAnime.Core.Data;

namespace ProjetoAnime.Anime.API.Data;

public class AnimeRepository : IAnimeRepository
{
    public IUnitOfWork UnitOfWork => _context;
    private readonly AnimeDbContext _context;

    public AnimeRepository(AnimeDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Models.Anime>> obterTodosAnimes()
    {
        return await _context.Animes.AsNoTracking().ToListAsync();
    }

    public async Task<Models.Anime> ObterPorId(Guid id)
    {
        return await _context.Animes.FindAsync(id);
    }

    public void Adicionar(Models.Anime anime)
    {
        _context.Animes.Add(anime);
         _context.Commit().Wait();
    }

    public void Atualizar(Models.Anime anime)
    {
        _context.Animes.Update(anime);
        _context.Commit().Wait();
    }
    
    public void Dispose()
    {
        _context?.Dispose();
    }

}