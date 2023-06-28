using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using ProjetoAnime.Core.API.User;
using ProjetoAnime.Core.Communication;
using ProjetoAnime.Webapp.MVC.Extensions;
using ProjetoAnime.Webapp.MVC.Models.Identidade;

namespace ProjetoAnime.Webapp.MVC.Services
{
    public class AutenticacaoService : Service, IAutenticacaoService
    {
        public AutenticacaoService(
            HttpClient httpClient,
            IAspNetUser aspNetUser,
            IOptions<AppSettings> options,
            IAuthenticationService authenticationService)
        {
            _aspNetUser = aspNetUser;
            _httpClient = httpClient;
            _authenticationService = authenticationService;
            _httpClient.BaseAddress = new Uri(options.Value.AutenticationUrl);
        }


        private readonly HttpClient _httpClient;
        private readonly IAspNetUser _aspNetUser;
        private readonly IAuthenticationService _authenticationService;

        public async Task<UsuarioRespostaLogin> Login(UsuarioLoginViewModel parametros)
        {
            var response = await _httpClient.PostAsync("/api/identidade/autenticar", ObterConteudo(parametros));

            if (!TratarErrosResponse(response))
            {
                return new UsuarioRespostaLogin
                {
                    ResponseResult = await DeserializarObjetoResponse<ResponseResult>(response)
                };
            }

            return await DeserializarObjetoResponse<UsuarioRespostaLogin>(response);
        }

        public async Task<UsuarioRespostaLogin> Registro(UsuarioRegistroViewModel parametros)
        {
            var response = await _httpClient.PostAsync("/api/identidade/nova-conta", ObterConteudo(parametros));

            if (!TratarErrosResponse(response))
            {
                return new UsuarioRespostaLogin
                {
                    ResponseResult = await DeserializarObjetoResponse<ResponseResult>(response)
                };
            }

            return await DeserializarObjetoResponse<UsuarioRespostaLogin>(response);
        }

        public async Task RealizarLogin(UsuarioRespostaLogin usuario)
        {
            var token = ObterJwtToken(usuario.AccessToken);
            var claims = new List<Claim>
            {
                new Claim("JWT", usuario.AccessToken),
                new Claim("RefreshToken", usuario.RefreshToken)
            };
            claims.AddRange(token.Claims);

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddHours(8),
                IsPersistent = true
            };

            await _authenticationService.SignInAsync(_aspNetUser.GetHttpContext(),
                CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
        }

        public async Task Logout()
        {
            await _authenticationService.SignOutAsync(_aspNetUser.GetHttpContext(),
                CookieAuthenticationDefaults.AuthenticationScheme, null);
        }

        public JwtSecurityToken ObterJwtToken(string jwtToken)
        {
            return new JwtSecurityTokenHandler().ReadToken(jwtToken) as JwtSecurityToken;
        }
    }
}