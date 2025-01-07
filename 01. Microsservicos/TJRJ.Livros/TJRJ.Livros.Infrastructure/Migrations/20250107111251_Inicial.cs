using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TJRJ.Livros.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assunto",
                columns: table => new
                {
                    codAs = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assunto", x => x.codAs);
                });

            migrationBuilder.CreateTable(
                name: "Autor",
                columns: table => new
                {
                    CodAu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autor", x => x.CodAu);
                });

            migrationBuilder.CreateTable(
                name: "Livro",
                columns: table => new
                {
                    CodI = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Editora = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Edicao = table.Column<int>(type: "int", nullable: false),
                    AnoPublicacao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro", x => x.CodI);
                });

            migrationBuilder.CreateTable(
                name: "TipoVenda",
                columns: table => new
                {
                    TipoVenda_CodI = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoVenda", x => x.TipoVenda_CodI);
                });

            migrationBuilder.CreateTable(
                name: "LivroAssunto",
                columns: table => new
                {
                    Livro_CodI = table.Column<int>(type: "int", nullable: false),
                    Assunto_codAs = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivroAssunto", x => new { x.Livro_CodI, x.Assunto_codAs });
                    table.ForeignKey(
                        name: "FK_LivroAssunto_Assunto_Assunto_codAs",
                        column: x => x.Assunto_codAs,
                        principalTable: "Assunto",
                        principalColumn: "codAs",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivroAssunto_Livro_Livro_CodI",
                        column: x => x.Livro_CodI,
                        principalTable: "Livro",
                        principalColumn: "CodI",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LivroAutor",
                columns: table => new
                {
                    Livro_CodI = table.Column<int>(type: "int", nullable: false),
                    Autor_CodAu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivroAutor", x => new { x.Livro_CodI, x.Autor_CodAu });
                    table.ForeignKey(
                        name: "FK_LivroAutor_Autor_Autor_CodAu",
                        column: x => x.Autor_CodAu,
                        principalTable: "Autor",
                        principalColumn: "CodAu",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivroAutor_Livro_Livro_CodI",
                        column: x => x.Livro_CodI,
                        principalTable: "Livro",
                        principalColumn: "CodI",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LivroTipoVenda",
                columns: table => new
                {
                    Livro_CodI = table.Column<int>(type: "int", nullable: false),
                    TipoVenda_CodI = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivroTipoVenda", x => new { x.Livro_CodI, x.TipoVenda_CodI });
                    table.ForeignKey(
                        name: "FK_LivroTipoVenda_Livro_Livro_CodI",
                        column: x => x.Livro_CodI,
                        principalTable: "Livro",
                        principalColumn: "CodI",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivroTipoVenda_TipoVenda_TipoVenda_CodI",
                        column: x => x.TipoVenda_CodI,
                        principalTable: "TipoVenda",
                        principalColumn: "TipoVenda_CodI",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LivroAssunto_Assunto_codAs",
                table: "LivroAssunto",
                column: "Assunto_codAs");

            migrationBuilder.CreateIndex(
                name: "IX_LivroAutor_Autor_CodAu",
                table: "LivroAutor",
                column: "Autor_CodAu");

            migrationBuilder.CreateIndex(
                name: "IX_LivroTipoVenda_TipoVenda_CodI",
                table: "LivroTipoVenda",
                column: "TipoVenda_CodI");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LivroAssunto");

            migrationBuilder.DropTable(
                name: "LivroAutor");

            migrationBuilder.DropTable(
                name: "LivroTipoVenda");

            migrationBuilder.DropTable(
                name: "Assunto");

            migrationBuilder.DropTable(
                name: "Autor");

            migrationBuilder.DropTable(
                name: "Livro");

            migrationBuilder.DropTable(
                name: "TipoVenda");
        }
    }
}
