using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Storiify.Infra.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_usuario",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(maxLength: 60, nullable: false),
                    Email = table.Column<string>(maxLength: 160, nullable: false),
                    Login = table.Column<string>(maxLength: 100, nullable: false),
                    Senha = table.Column<string>(fixedLength: true, maxLength: 32, nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    FotoUrl = table.Column<string>(maxLength: 160, nullable: true),
                    FotoIdPublico = table.Column<string>(maxLength: 25, nullable: true),
                    DtCriacao = table.Column<DateTime>(nullable: false),
                    DtUltimaAtividade = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_historia",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(maxLength: 60, nullable: false),
                    FotoUrl = table.Column<string>(maxLength: 160, nullable: true),
                    FotoIdPublico = table.Column<string>(maxLength: 25, nullable: true),
                    UsuarioId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_historia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_historia_tb_usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "tb_usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_personagem",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(maxLength: 60, nullable: false),
                    FotoUrl = table.Column<string>(maxLength: 160, nullable: true),
                    FotoIdPublico = table.Column<string>(maxLength: 25, nullable: true),
                    HistoriaId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_personagem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_personagem_tb_historia_HistoriaId",
                        column: x => x.HistoriaId,
                        principalTable: "tb_historia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_historia_UsuarioId",
                table: "tb_historia",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_personagem_HistoriaId",
                table: "tb_personagem",
                column: "HistoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_personagem");

            migrationBuilder.DropTable(
                name: "tb_historia");

            migrationBuilder.DropTable(
                name: "tb_usuario");
        }
    }
}
