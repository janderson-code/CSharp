namespace ProjetoAnime.Webapp.MVC.Configuration
{
    public interface IStartup
    {
        IConfiguration Configuration { get; }

        void Configure(WebApplication app, IWebHostEnvironment env);

        void ConfigureService(IServiceCollection services);
    }

    public class Startup : IStartup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapControllers();
        }

        public void ConfigureService(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }
    }

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
}