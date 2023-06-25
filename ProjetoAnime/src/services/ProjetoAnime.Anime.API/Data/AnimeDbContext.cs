using ProjetoAnime.Core.Data;

namespace ProjetoAnime.Anime.API.Data;

public class AnimeDbContext :DbContext, IUnitOfWork
{
    public AnimeDbContext(DbContextOptions<AnimeDbContext> options)
        : base(options) { }
    
    public DbSet<Models.Anime> Animes { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                     e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            property.SetColumnType("varchar(100)"); 
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AnimeDbContext).Assembly);
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