using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using ProjetoAnime.Webapp.MVC.Models.Identidade;
using ProjetoAnime.Webapp.MVC.Services;

namespace ProjetoAnime.Webapp.MVC.Controllers;

public sealed class IdentidadeController : MainController
{
    private readonly IAutenticacaoService _autenticacaoService;

    public IdentidadeController(IAutenticacaoService autenticacaoService)
    {
        _autenticacaoService = autenticacaoService;
    }

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

    [HttpPost("cadastrarUsuario")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Cadastrar(UsuarioRegistroViewModel usuario)
    {
        if (!ModelState.IsValid) return View(usuario);

        var response = _autenticacaoService.Registro(usuario).Result;
        if (ResponsePossuiErros(response.ResponseResult)) return View(usuario);

        _autenticacaoService.RealizarLogin(response).Wait();

        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    [Route("login")]
    public IActionResult Login(string returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;
        return View();
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(UsuarioLoginViewModel parametros, string returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;
        if (!ModelState.IsValid) return View(parametros);

        var resposta = await _autenticacaoService.Login(parametros);
        if (ResponsePossuiErros(resposta.ResponseResult)) return View(parametros);

        await _autenticacaoService.RealizarLogin(resposta);

        if (string.IsNullOrEmpty(returnUrl)) return RedirectToAction("Index", "Home");
        return LocalRedirect(returnUrl);
    }

    [HttpGet]
    [Route("sair")]
    public async Task<IActionResult> LogOut()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Login", "Identidade");
    }
}