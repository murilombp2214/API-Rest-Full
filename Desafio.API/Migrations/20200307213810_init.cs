using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Desafio.API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    Codigo = table.Column<Guid>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Nome = table.Column<string>(maxLength: 150, nullable: true),
                    CPF = table.Column<string>(maxLength: 11, nullable: true),
                    UF = table.Column<string>(maxLength: 2, nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Sessao",
                columns: table => new
                {
                    Codigo = table.Column<Guid>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    CodigoPessoa = table.Column<Guid>(nullable: false),
                    InicioSessao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessao", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Sessao_Pessoa_CodigoPessoa",
                        column: x => x.CodigoPessoa,
                        principalTable: "Pessoa",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sessao_CodigoPessoa",
                table: "Sessao",
                column: "CodigoPessoa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sessao");

            migrationBuilder.DropTable(
                name: "Pessoa");
        }
    }
}
