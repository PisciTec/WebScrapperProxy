using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebScrapperProxy.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Extracoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataInicio = table.Column<string>(type: "TEXT", nullable: true),
                    DataFinal = table.Column<string>(type: "TEXT", nullable: true),
                    QuantidadePaginas = table.Column<int>(type: "INTEGER", nullable: false),
                    QuantidadeLinhas = table.Column<int>(type: "INTEGER", nullable: false),
                    CaminhoArquivoJson = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extracoes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Extracoes");
        }
    }
}
