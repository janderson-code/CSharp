using ProjetoAnime.Webapp.MVC.Extensions;

namespace ProjetoAnime.Webapp.MVC.Configuration
{
    public class Startup : IStartup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            app.UseApiConfig(Configuration);

        }

        public void ConfigureService(IServiceCollection services)
        {
            services.WebApiConfig(Configuration);

        }
    }
}