using Microsoft.EntityFrameworkCore.Migrations;

namespace StarterBank.Migrations
{
    public partial class RetirarCartaoCaixa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaixaEletronico_Cartoes_CartaoId",
                table: "CaixaEletronico");

            migrationBuilder.DropIndex(
                name: "IX_CaixaEletronico_CartaoId",
                table: "CaixaEletronico");

            migrationBuilder.DropColumn(
                name: "CartaoId",
                table: "CaixaEletronico");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CartaoId",
                table: "CaixaEletronico",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CaixaEletronico_CartaoId",
                table: "CaixaEletronico",
                column: "CartaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_CaixaEletronico_Cartoes_CartaoId",
                table: "CaixaEletronico",
                column: "CartaoId",
                principalTable: "Cartoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
