using Microsoft.AspNetCore.Mvc;
using ProjetoAnime.Core.API.Controllers;
using ProjetoAnime.KitsuGateway.API.Services;

namespace ProjetoAnime.KitsuGateway.API.Controllers;

public class MangaController : MainController
{
    private readonly IMangaKitsuService _mangaKitsuService;

    public MangaController(IMangaKitsuService animeKitsuService)
    {
        _mangaKitsuService = animeKitsuService;
    }

    // GET
    [HttpGet("obter-manga-nome")]
    public IActionResult Index(string nome)
    {
        return Ok(_mangaKitsuService.obterMangaNome(nome));
    }
}