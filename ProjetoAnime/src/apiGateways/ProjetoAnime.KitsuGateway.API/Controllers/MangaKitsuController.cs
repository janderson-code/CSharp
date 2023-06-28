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
        return CustomResponse(_mangaKitsuService.obterMangaNome(nome));
    }

    [HttpGet("mangas-em-alta")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MangaKitsuResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult MangasAlta()
    {
        return CustomResponse(_mangaKitsuService.MangasEmAlta());
    }
}