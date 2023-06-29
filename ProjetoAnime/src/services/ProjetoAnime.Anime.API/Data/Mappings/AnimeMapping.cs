using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjetoAnime.Anime.API.Data.Mappings;

public class AnimeMapping : IEntityTypeConfiguration<Models.Anime>
{
    public void Configure(EntityTypeBuilder<Models.Anime> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Nome)
            .HasColumnType("varchar(200)")
            .IsRequired();

        builder.Property(a => a.Imagem)
            .HasColumnType("varchar(200)")
            .IsRequired();

        builder.Property(a => a.Sinopse)
            .HasColumnType("varchar(200)")
            .IsRequired();

        builder.Property(a => a.NomeOriginal)
            .HasColumnType("varchar(200)")
            .IsRequired();

        builder.Property(a => a.DataInicio)
            .HasColumnType("date")
            .IsRequired();

        builder.Property(a => a.DataFim)
            .HasColumnType("date")
            .IsRequired();

        builder.ToTable("Animes");
    }
}