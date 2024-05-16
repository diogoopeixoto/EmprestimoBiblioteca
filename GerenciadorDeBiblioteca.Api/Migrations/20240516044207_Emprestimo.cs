using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorDeBiblioteca.Api.Migrations
{
    /// <inheritdoc />
    public partial class Emprestimo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Disponibilidade",
                table: "Livros",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MyProperty",
                table: "Emprestimo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Disponibilidade",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Emprestimo");
        }
    }
}
