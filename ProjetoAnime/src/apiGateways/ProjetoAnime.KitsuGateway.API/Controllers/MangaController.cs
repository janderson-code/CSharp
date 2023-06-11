using Microsoft.AspNetCore.Mvc;
using ProjetoAnime.Core.API.Controllers;

namespace ProjetoAnime.KitsuGateway.API.Controllers;

public class MangaController : MainController
{
    // GET
    [HttpGet("obter-manga-apelido")]
    public IActionResult Index()
    {
        return Ok();
    }
}