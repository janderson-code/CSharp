namespace ProjetoAnime.KitsuGateway.API.Controllers;

public sealed class AnimeKitsuController : MainController
{
    private readonly IAnimeKitsuService _animeKitsuService;

    public AnimeKitsuController(IAnimeKitsuService animeKitsuService)
    {
        _animeKitsuService = animeKitsuService;
    }

    [HttpGet("obter-anime-nome")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AnimeKitsuResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Index(string nome)
    {
        return CustomResponse(_animeKitsuService.ObterAnimeNome(nome));
    }

    [HttpGet("anime-em-alta")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AnimeKitsuResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult AnimesAlta()
    {
        return CustomResponse(_animeKitsuService.AnimesEmAlta());
    }
}