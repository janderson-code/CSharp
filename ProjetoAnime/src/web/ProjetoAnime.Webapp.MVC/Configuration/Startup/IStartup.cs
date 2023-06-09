namespace ProjetoAnime.Webapp.MVC.Configuration
{
    public interface IStartup
    {
        IConfiguration Configuration { get; }

        void Configure(WebApplication app, IWebHostEnvironment env);

        void ConfigureService(IServiceCollection services);
    }
}