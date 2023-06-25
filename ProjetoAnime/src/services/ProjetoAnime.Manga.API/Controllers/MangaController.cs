using ProjetoAnime.Core.API.Controllers;
using ProjetoAnime.Manga.API.Interfaces;

namespace ProjetoAnime.Manga.API.Controllers;

public sealed class MangasController : MainController
{
    private readonly IMangaRepository _mangaRepository;

    public MangasController(IMangaRepository mangaRepository)
    {
        _mangaRepository = mangaRepository;
    }

    [HttpGet("obter-todos-mangas")]
    public async Task<IEnumerable<Models.Manga>> Index()
    {
        return await _mangaRepository.obterTodosMangas();
    }

    [HttpGet("obter-manga-id")]
    public async Task<Models.Manga> detalhes(Guid id)
    {
        var anime = _mangaRepository.ObterPorId(id).Result;
        return anime;
    }

    [HttpPost("cadastrar")]
    public IActionResult cadastrar(Models.Manga manga)
    {
        try
        {
            _mangaRepository.Adicionar(manga);
            return CreatedAtAction("Index", new { id = manga.Id }, manga);
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
}