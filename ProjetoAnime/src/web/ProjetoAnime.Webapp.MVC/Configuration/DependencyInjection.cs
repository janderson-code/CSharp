using ProjetoAnime.Core.API.User;
using ProjetoAnime.Webapp.MVC.Services;

namespace ProjetoAnime.Webapp.MVC.Configuration;

public static class DependencyInjection
{
    public static void Register(this IServiceCollection services)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped<IAspNetUser, AspNetUser>();
        services.AddScoped<IAutenticacaoService, AutenticacaoService>();

        #region HttpServices

        services.AddHttpClient<IKitsuService, KitsuService>();

        #endregion
    }
}