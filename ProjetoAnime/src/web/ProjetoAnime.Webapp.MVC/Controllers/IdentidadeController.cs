namespace ProjetoAnime.Webapp.MVC.Controllers;

public class IdentidadeController : Controller
{
    // GET
    [HttpPost("cadastrarUsuario")]
    public IActionResult Cadastrar()
    {
        return Ok();
    }

    [HttpPost("logar")]
    public IActionResult Login()
    {
        return Ok();
    }
}