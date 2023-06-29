using ProjetoAnime.Webapp.MVC.Extensions;

namespace ProjetoAnime.Webapp.MVC.Configuration
{
    public static class WebAppConfig
    {
        public static IServiceCollection WebApiConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.Register();
            services.AddControllersWithViews();
            services.Configure<AppSettings>(configuration);
            return services;
        }

        public static IApplicationBuilder UseApiConfig(this WebApplication app, IConfiguration configuration)
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

            app.UseIdentityConfiguration();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapControllers();

            return app;
        }
    }
}