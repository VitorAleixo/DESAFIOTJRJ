using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TJRJ.Assunto.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Inicial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Assuntos",
                table: "Assuntos");

            migrationBuilder.RenameTable(
                name: "Assuntos",
                newName: "Assunto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assunto",
                table: "Assunto",
                column: "codAs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Assunto",
                table: "Assunto");

            migrationBuilder.RenameTable(
                name: "Assunto",
                newName: "Assuntos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assuntos",
                table: "Assuntos",
                column: "codAs");
        }
    }
}
