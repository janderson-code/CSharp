using Microsoft.AspNetCore.Mvc;
using ProjetoAnime.Anime.API.Models;
using ProjetoAnime.Core.API.Controllers;

namespace ProjetoAnime.Anime.API.Controllers;

public class AnimeController : MainController
{

    [HttpPost]
    public IActionResult CadastrarAnime(AnimeViewModel animeViewModel)
    {
        return CustomResponse();
    }
}