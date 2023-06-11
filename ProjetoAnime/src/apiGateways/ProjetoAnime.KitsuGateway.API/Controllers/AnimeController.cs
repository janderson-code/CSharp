using Microsoft.AspNetCore.Mvc;
using ProjetoAnime.Core.API.Controllers;
using ProjetoAnime.KitsuGateway.API.Services;

namespace ProjetoAnime.KitsuGateway.API.Controllers;

public class AnimeController : MainController
{
    private readonly IAnimeKitsuService _animeKitsuService;

    public AnimeController(IAnimeKitsuService animeKitsuService)
    {
        _animeKitsuService = animeKitsuService;
    }
    // GET
    [HttpGet("obter-anime-nome")]
    public IActionResult Index(string nome)
    {
        return Ok(_animeKitsuService.ObterAnimeNome(nome));
    }
}