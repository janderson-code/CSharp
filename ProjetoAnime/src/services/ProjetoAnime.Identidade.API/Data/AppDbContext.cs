using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ProjetoAnime.Identidade.API.Data
{
    public class AppDbContext : IdentityDbContext
    {
        // Passando a classe do contexto para o  DoContextOptions para passar opções do nosso contexto na Startup
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
    }
}
