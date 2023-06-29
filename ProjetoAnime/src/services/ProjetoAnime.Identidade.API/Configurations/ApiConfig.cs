using ProjetoAnime.Core.API.Identidade;

namespace ProjetoAnime.Identidade.API.Configurations
{
    public static class ApiConfig
    {

        public static IServiceCollection AddApiConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddIdentityConfig(configuration);
            return services;
        }

        public static IApplicationBuilder UseApiConfig(this WebApplication app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthConfiguration();
            app.MapControllers();

            return app;

        }

    }
}
