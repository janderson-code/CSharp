using System.IdentityModel.Tokens.Jwt;
using ProjetoAnime.Webapp.MVC.Models.Identidade;

namespace ProjetoAnime.Webapp.MVC.Services;

public interface IAutenticacaoService
{
    Task<UsuarioRespostaLogin> Login(UsuarioLoginViewModel parametros);

    Task<UsuarioRespostaLogin> Registro(UsuarioRegistroViewModel parametros);

    Task RealizarLogin(UsuarioRespostaLogin usuario);

    Task Logout();

    JwtSecurityToken ObterJwtToken(string jwtToken);
}