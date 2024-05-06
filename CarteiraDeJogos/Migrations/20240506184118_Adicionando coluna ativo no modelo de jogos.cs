using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarteiraDeJogos.Migrations
{
    /// <inheritdoc />
    public partial class Adicionandocolunaativonomodelodejogos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Ativo",
                table: "Jogos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Jogos");
        }
    }
}
