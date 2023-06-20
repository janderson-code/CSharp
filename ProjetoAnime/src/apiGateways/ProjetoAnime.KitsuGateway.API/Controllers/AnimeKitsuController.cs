using Microsoft.AspNetCore.Mvc;
using ProjetoAnime.Core.API.Controllers;
using ProjetoAnime.KitsuGateway.API.Models.Anime;
using ProjetoAnime.KitsuGateway.API.Services;

namespace ProjetoAnime.KitsuGateway.API.Controllers;

public sealed class AnimeKitsuController : MainController
{
    private readonly IAnimeKitsuService _animeKitsuService;

    public AnimeKitsuController(IAnimeKitsuService animeKitsuService)
    {
        _animeKitsuService = animeKitsuService;
    }

    [HttpGet("obter-anime-nome")]
    [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(AnimeKitsuResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Index(string nome)
    {
        return Ok(_animeKitsuService.ObterAnimeNome(nome));
    }

    [HttpGet("anime-em-alta")]
    [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(AnimeKitsuResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult AnimesAlta()
    {
        return Ok(_animeKitsuService.AnimesEmAlta());
    }
}