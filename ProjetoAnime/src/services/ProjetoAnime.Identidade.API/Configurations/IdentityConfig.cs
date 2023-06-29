using Microsoft.AspNetCore.Authentication.JwtBearer;
using ProjetoAnime.Identidade.API.Data;
using ProjetoAnime.Identidade.API.Extensions;

namespace ProjetoAnime.Identidade.API.Configurations
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfig(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // Adicionando o servico de contexto e a conexão com bd SQL Server
            services.AddDbContext<AppDbContext>(
                options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
            );

            // Adicionando suporte ao Identity
            services
                .AddDefaultIdentity<IdentityUser>() // Adicionando o pacote de usuário
                .AddRoles<IdentityRole>() // Adicionando suporte as roles
                .AddErrorDescriber<IdentityMensagensPortugues>()
                .AddEntityFrameworkStores<AppDbContext>() // Contexto que usaremos para criar os bancos do Identity
                .AddDefaultTokenProviders(); // Tokens gerados para necessidade de resetar uma senha e etc. é criado default

            var appSettingsSection = configuration.GetSection("AppSettings"); // Vá até o arquivo do appsettings e pegue a seção/nó  "AppSettings"
            services.Configure<AppSettings>(appSettingsSection); // Aqui configuramos para popular a classe conforme o dados da seção/nó

            var appSettings = appSettingsSection.Get<AppSettings>(); // Pegamos a classe populada
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);// Aqui pegamos o valor da chave em bytes

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(bearerOptions =>
                {
                    bearerOptions.RequireHttpsMetadata = true;
                    bearerOptions.SaveToken = true;
                    bearerOptions.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key), // Usando a chave
                        ValidateIssuer = true,//
                        ValidateAudience = true,
                        ValidAudience = appSettings.ValidoEm,// Inserido o valor da Audiencia
                        ValidIssuer = appSettings.Emissor // Inserido o valor do Emissor
                    };
                });
            return services;
        }
    }
}