using Microsoft.AspNetCore.Mvc;
using ProjetoAnime.Core.API.Controllers;
using ProjetoAnime.KitsuGateway.API.Services;

namespace ProjetoAnime.KitsuGateway.API.Controllers;

internal sealed class AnimeKitsuController : MainController
{
    private readonly IAnimeKitsuService _animeKitsuService;

    public AnimeKitsuController(IAnimeKitsuService animeKitsuService)
    {
        _animeKitsuService = animeKitsuService;
    }

    // GET
    [HttpGet("obter-anime-nome")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Index(string nome)
    {
        return Ok(_animeKitsuService.ObterAnimeNome(nome));
    }
}