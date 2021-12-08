using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atos.DevSkills.Infra.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Desenvolvedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desenvolvedores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Habilidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DesenvolvedorSkill",
                columns: table => new
                {
                    DesenvolvedoresId = table.Column<int>(type: "int", nullable: false),
                    SkillsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesenvolvedorSkill", x => new { x.DesenvolvedoresId, x.SkillsId });
                    table.ForeignKey(
                        name: "FK_DesenvolvedorSkill_Desenvolvedores_DesenvolvedoresId",
                        column: x => x.DesenvolvedoresId,
                        principalTable: "Desenvolvedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DesenvolvedorSkill_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DesenvolvedorSkill_SkillsId",
                table: "DesenvolvedorSkill",
                column: "SkillsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DesenvolvedorSkill");

            migrationBuilder.DropTable(
                name: "Desenvolvedores");

            migrationBuilder.DropTable(
                name: "Skills");
        }
    }
}
