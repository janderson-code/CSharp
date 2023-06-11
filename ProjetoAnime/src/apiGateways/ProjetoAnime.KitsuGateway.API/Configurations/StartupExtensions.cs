namespace ProjetoAnime.Anime.KitsuGateway.Configurations;

public static class StartupExtensions
{
    public static WebApplicationBuilder UseStartup<TStartup>(this WebApplicationBuilder webApplicationBuilder) where TStartup : IStartup
    {
        var startup = Activator.CreateInstance(typeof(TStartup), webApplicationBuilder.Configuration) as IStartup;

        if (startup == null) throw new ArgumentException("Classe startup invalida");

        startup.ConfigureService(webApplicationBuilder.Services);

        var app = webApplicationBuilder.Build();
        startup.Configure(app, app.Environment);
        app.Run();

        return webApplicationBuilder;
    }
}