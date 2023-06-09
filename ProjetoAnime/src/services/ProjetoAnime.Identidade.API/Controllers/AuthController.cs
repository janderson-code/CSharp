using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ProjetoAnime.Identidade.API.Models;

namespace ProjetoAnime.Identidade.API.Controllers
{
    [ApiController] // Com isso o Swagger entende que é doc de API pra trafegar JSON em vez de Form
    [Route("api/identidade")]
    public class AuthController : Controller
    {
        private readonly AuthenticationService _authenticationService;
        private readonly SignInManager<IdentityUser> _signInManager; //Gerencia login 
        private readonly UserManager<IdentityUser> _userManager; // Gerencia usuário

        public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signManager)
        {
            _signInManager = signManager;
            _userManager = userManager;
        }

        [HttpPost("nova-conta")]
        public async Task<ActionResult> Registrar(UsuarioRegistroViewModel usuarioRegistro)
        {
            if (!ModelState.IsValid) return BadRequest();

            var user = new IdentityUser // Criando objeto que será o usuário do Identity
            {
                UserName = usuarioRegistro.Email,
                Email = usuarioRegistro.Email,
                EmailConfirmed = true
            };

            // passe o usuário e a senha 
            var result = await _userManager.CreateAsync(user, usuarioRegistro.Senha);

            if (result.Succeeded)
            {
                _signInManager.SignInAsync(user, false).Wait();
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost("autenticar")]
        public async Task<ActionResult> Login(UsuarioLoginViewModel usuarioLogin)
        {
            if (!ModelState.IsValid) return BadRequest();

            var result = await _signInManager.PasswordSignInAsync(usuarioLogin.Email, usuarioLogin.Senha,
                false /*request persistente*/, true /*bloquear usuário após tentativas invalidas*/);

            if (result.Succeeded)
            {
                return Ok();

                
            }
            return BadRequest();
        }
    }
}