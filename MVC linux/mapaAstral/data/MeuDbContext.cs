using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mapaAstral.Models;
using Microsoft.EntityFrameworkCore;

namespace mapaAstral.data
{
    using Microsoft.EntityFrameworkCore;

    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions<MeuDbContext> options)
            : base(options)
        {
        }

        public DbSet<Signo> Signos { get; set; }
        public DbSet<Planeta> Planetas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Signo>().ToTable("Signos");
            modelBuilder.Entity<Planeta>().ToTable("Planetas");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=mapa_astral_db;Username=postgres;Password=kasama");
            }
        }
    }

}