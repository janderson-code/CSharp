using Microsoft.AspNetCore.Mvc;
using ProjetoAnime.Anime.API.Models;
using ProjetoAnime.Core.API.Controllers;

namespace ProjetoAnime.Anime.API.Controllers;

public class AnimesController : MainController
{
    private readonly IAnimeRepository _animeRepository;

    public AnimesController(IAnimeRepository animeRepository)
    {
        _animeRepository = animeRepository;
    }
    
    [HttpGet("obter-todos-animes")]
    public async Task<IEnumerable<Models.Anime>> Index()
    {
        return await _animeRepository.obterTodosAnimes();
    }

    [HttpGet("obter-anime_id")]
    public async Task<Models.Anime> detalhes(Guid id)
    {
        var anime = _animeRepository.ObterPorId(id).Result;
        return anime;
    }

    [HttpPost("cadastrar")]
    public IActionResult cadastrar(Models.Anime anime)
    {
        try
        {
            _animeRepository.Adicionar(anime);
            return CreatedAtAction("Index",new {id = anime.Id},anime);
        }
        catch (Exception e)
        {
            return BadRequest();
        }

    } 
}