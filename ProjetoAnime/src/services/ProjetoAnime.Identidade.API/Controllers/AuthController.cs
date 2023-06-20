using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProjetoAnime.Core.API.Controllers;
using ProjetoAnime.Identidade.API.Extensions;
using ProjetoAnime.Identidade.API.Models;
using ProjetoAnime.Identidade.API.Models.NerdStore.Enterprise.Identidade.API.Models;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace ProjetoAnime.Identidade.API.Controllers
{
    [Route("api/identidade")]
    internal sealed class AuthController : MainController
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppSettings _appSettings;

        public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signManager,
            IOptions<AppSettings> appSettings)
        {
            _signInManager = signManager;
            _userManager = userManager;
            _appSettings =
                appSettings.Value; // Pegando o valor dos dados do appSettings.json em tempo de execução com IOptions do appSettings
        }

        [HttpPost("nova-conta")]
        public async Task<ActionResult> Registrar(UsuarioRegistroViewModel usuarioRegistro)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var user = new IdentityUser
            {
                UserName = usuarioRegistro.Email,
                Email = usuarioRegistro.Email,
                EmailConfirmed = true
            };

            var result = _userManager.CreateAsync(user, usuarioRegistro.Senha).Result;

            if (result.Succeeded)
            {
                return CustomResponse(GerarJwt(usuarioRegistro.Email).Result);
            }

            // Adicionando erros na criação do usuário caso haja
            foreach (var error in result.Errors)
            {
                AdicionarErroProcessamento(error.Description);
            }

            return CustomResponse();
        }

        [HttpPost("autenticar")]
        public async Task<ActionResult> Login(UsuarioLoginViewModel usuarioLogin)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _signInManager.PasswordSignInAsync(usuarioLogin.Email, usuarioLogin.Senha,
                false, true);

            if (result.Succeeded)
            {
                return CustomResponse(GerarJwt(usuarioLogin.Email).Result); // Retornando o login com o token
            }

            if (result.IsLockedOut)
            {
                AdicionarErroProcessamento("Usuário temporariamente bloqueado por tentativas inválidas");
                return CustomResponse();
            }

            AdicionarErroProcessamento("Usuário ou Senha incorretos");
            return CustomResponse();
        }

        private async Task<UsuarioRespostaLogin> GerarJwt(string email)
        {
            var user = _userManager.FindByEmailAsync(email).Result; // Obter usuário pelo email
            var claims = _userManager.GetClaimsAsync(user).Result; //  Obter as Claims deste usuário 
            var userRoles = _userManager.GetRolesAsync(user).Result; // Obter as Roles deste Usuário

            //Adicionando mais claims do Tipo JWT na lista de Claims do usuário 
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())); // ID do token
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf,
                ToUnixEpochDate(DateTime.UtcNow).ToString())); // Quando o token vai expirar
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat,
                ToUnixEpochDate(DateTime.UtcNow).ToString(), // Quando o token foi emitido 
                ClaimValueTypes.Integer64));

            //Pegamos cada role do usuario e criamos uma claim para cada e adionamos na nossa lista de claims
            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim("role", userRole));
            }

            //Declararamos a Clam que representará de fato no Identity e pegamos todas as claims
            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            //Gerando o manipulador do Token						
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            //Codificando o Token
            var encodedToken = tokenHandler.WriteToken(token);

            // Retornando o Usuário com o token	
            return new UsuarioRespostaLogin
            {
                AccessToken = encodedToken,
                ExpiresIn = TimeSpan.FromHours(2).TotalSeconds,
                UsuarioToken = new UsuarioToken
                {
                    Id = user.Id,
                    Email = user.Email,
                    Claims = claims.Select(c => new UsuarioClaim { Type = c.Type, Value = c.Value })
                }
            };
        }

        // Método para configurar os valores de data das claims do método GerarJwt()
        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero))
                .TotalSeconds);
    }
}