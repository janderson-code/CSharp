using Microsoft.AspNetCore.Mvc;
using ProjetoAnime.Core.API.Controllers;
using ProjetoAnime.KitsuGateway.API.Services;

namespace ProjetoAnime.KitsuGateway.API.Controllers;

public sealed class MangaKitsuController : MainController
{
    private readonly IMangaKitsuService _mangaKitsuService;

    public MangaKitsuController(IMangaKitsuService animeKitsuService)
    {
        _mangaKitsuService = animeKitsuService;
    }

    // GET
    [HttpGet("obter-manga-nome")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Index(string nome)
    {
        return Ok(_mangaKitsuService.obterMangaNome(nome));
    }
}