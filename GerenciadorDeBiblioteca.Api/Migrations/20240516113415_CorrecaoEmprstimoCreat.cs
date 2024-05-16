using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorDeBiblioteca.Api.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoEmprstimoCreat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Emprestimo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MyProperty",
                table: "Emprestimo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
