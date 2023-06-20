using Microsoft.EntityFrameworkCore;
using ProjetoAnime.Core.Data;
using ProjetoAnime.Manga.API.Interfaces;

namespace ProjetoAnime.Manga.API.Data;

public class MangaRepository : IMangaRepository
{
    public IUnitOfWork UnitOfWork => _context;
    private readonly MangaDbContext _context;

    public MangaRepository(MangaDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Models.Manga>> obterTodosMangas()
    {
        return await _context.Mangas.AsNoTracking().ToListAsync();
    }

    public async Task<Models.Manga> ObterPorId(Guid id)
    {
        return await _context.Mangas.FindAsync(id);
    }

    public void Adicionar(Models.Manga manga)
    {
        _context.Mangas.Add(manga);
        _context.Commit();
    }

    public void Atualizar(Models.Manga manga)
    {
        _context.Mangas.Update(manga);
        _context.Commit();
    }
    
    public void Dispose()
    {
        _context.Dispose();
    }
}