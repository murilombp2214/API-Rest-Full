using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Desafio.API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    Codigo = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 150, nullable: true),
                    CPF = table.Column<string>(maxLength: 11, nullable: true),
                    UF = table.Column<string>(maxLength: 2, nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.Codigo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pessoas");
        }
    }
}
