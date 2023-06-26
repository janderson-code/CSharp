namespace ProjetoAnime.Webapp.MVC.Controllers;

public sealed class IdentidadeController : Controller
{

    [HttpGet("cadastrarUsuario")]
    public IActionResult Cadastrar()
    {
        return View();
    }

    [HttpGet("logar")]
    public IActionResult Login()
    {
        return View();
    }
}