using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace ProjetoAnime.Core.API.Identidade;

public static class JWTConfig
{
    public static void AddJwtConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var appSettingSection = configuration.GetSection("AppSettings");
        services.Configure<AppSettings>(appSettingSection);

        var appSettings = appSettingSection.Get<AppSettings>();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(bearerOptions =>
        {
            bearerOptions.RequireHttpsMetadata = false;
            bearerOptions.BackchannelHttpHandler = new HttpClientHandler { ServerCertificateCustomValidationCallback = delegate { return true; } };
            bearerOptions.SaveToken = true;
        });
    }

    public static void UseAuthConfiguration(this IApplicationBuilder app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
    }
}