using Microsoft.EntityFrameworkCore.Migrations;

namespace StarterBank.Migrations
{
    public partial class updateConta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Numero",
                table: "Contas",
                newName: "NumeroConta");

            migrationBuilder.RenameColumn(
                name: "Agencia",
                table: "Contas",
                newName: "NumeroAgencia");

            migrationBuilder.AddColumn<int>(
                name: "CaixaId",
                table: "Contas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contas_CaixaId",
                table: "Contas",
                column: "CaixaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contas_CaixaEletronico_CaixaId",
                table: "Contas",
                column: "CaixaId",
                principalTable: "CaixaEletronico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contas_CaixaEletronico_CaixaId",
                table: "Contas");

            migrationBuilder.DropIndex(
                name: "IX_Contas_CaixaId",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "CaixaId",
                table: "Contas");

            migrationBuilder.RenameColumn(
                name: "NumeroConta",
                table: "Contas",
                newName: "Numero");

            migrationBuilder.RenameColumn(
                name: "NumeroAgencia",
                table: "Contas",
                newName: "Agencia");
        }
    }
}
