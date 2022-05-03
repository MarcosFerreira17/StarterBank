using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StarterBank.Migrations
{
    public partial class InitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Contas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomeBanco = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Numero = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Agencia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cartoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Numero = table.Column<long>(type: "bigint", nullable: false),
                    Saldo = table.Column<float>(type: "float", nullable: false),
                    Senha = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cartoes_Contas_ContaId",
                        column: x => x.ContaId,
                        principalTable: "Contas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Profissao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CPF = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clientes_Contas_ContaId",
                        column: x => x.ContaId,
                        principalTable: "Contas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CaixaEletronico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nota100 = table.Column<int>(type: "int", nullable: false),
                    nota50 = table.Column<int>(type: "int", nullable: false),
                    nota20 = table.Column<int>(type: "int", nullable: false),
                    nota10 = table.Column<int>(type: "int", nullable: false),
                    Saldo = table.Column<int>(type: "int", nullable: false),
                    ValorSaque = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CartaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaixaEletronico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaixaEletronico_Cartoes_CartaoId",
                        column: x => x.CartaoId,
                        principalTable: "Cartoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CaixaEletronico_CartaoId",
                table: "CaixaEletronico",
                column: "CartaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cartoes_ContaId",
                table: "Cartoes",
                column: "ContaId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_ContaId",
                table: "Clientes",
                column: "ContaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaixaEletronico");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Cartoes");

            migrationBuilder.DropTable(
                name: "Contas");
        }
    }
}
