using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ProjetoAnime.Identidade.API.Data
{
    public class AppDbContext : IdentityDbContext
    {
        // Passando a classe do contexto para o  DoContextOptions para passar opções do nosso contexto na Startup
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
    }
}