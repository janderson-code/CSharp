using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjetoAnime.Identidade.API.Data;

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
                .AddEntityFrameworkStores<AppDbContext>() // Contexto que usaremos para criar os bancos do Identity
                .AddDefaultTokenProviders(); // Tokens gerados para necessidade de resetar uma senha e etc. é criado default

            return services;
        }
    }
}
