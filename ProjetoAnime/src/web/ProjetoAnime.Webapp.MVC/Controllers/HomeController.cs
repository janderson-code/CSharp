using ProjetoAnime.Webapp.MVC.Services;

namespace ProjetoAnime.Webapp.MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IKitsuService _kitsuService;

    public HomeController(ILogger<HomeController> logger, IKitsuService kitsuService)
    {
        _logger = logger;
        _kitsuService = kitsuService;
    }

    public IActionResult Index()
    {
        var responseAnime = _kitsuService.ObterAnimesAlta().Result;
        var responseManga = _kitsuService.ObterMangasAlta().Result;

        KitsuViewModel kitsu = new KitsuViewModel();
        kitsu.Anime = responseAnime;
        kitsu.Manga = responseManga;
        return View(kitsu);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}