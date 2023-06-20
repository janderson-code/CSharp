using Microsoft.EntityFrameworkCore;
using ProjetoAnime.Core.Data;

namespace ProjetoAnime.Manga.API.Data;

public class MangaDbContext : DbContext, IUnitOfWork
{
    public MangaDbContext(DbContextOptions<MangaDbContext> options)
        : base(options) { }
    
    public DbSet<Models.Manga> Mangas { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                     e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            property.SetColumnType("varchar(100)"); 
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MangaDbContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(
                "Host=localhost;Port=5432;Database=ProjetoAnime;Username=postgres;Password=kasama"
            );
        }
    }
    public async Task<bool> Commit()
    {
        return await base.SaveChangesAsync() > 0;
    }
}