#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoAnime.Manga.API.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mangas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    Sinopse = table.Column<string>(type: "varchar(200)", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "date", nullable: false),
                    DataFim = table.Column<DateTime>(type: "date", nullable: false),
                    NomeOriginal = table.Column<string>(type: "varchar(200)", nullable: false),
                    Imagem = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mangas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mangas");
        }
    }
}