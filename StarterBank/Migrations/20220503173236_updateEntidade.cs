using Microsoft.EntityFrameworkCore.Migrations;

namespace StarterBank.Migrations
{
    public partial class updateEntidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contas_Cartoes_CartaoId",
                table: "Contas");

            migrationBuilder.DropIndex(
                name: "IX_Contas_CartaoId",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "CartaoId",
                table: "Cartoes");

            migrationBuilder.AlterColumn<int>(
                name: "CartaoId",
                table: "Contas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Contas_CartaoId",
                table: "Contas",
                column: "CartaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contas_Cartoes_CartaoId",
                table: "Contas",
                column: "CartaoId",
                principalTable: "Cartoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contas_Cartoes_CartaoId",
                table: "Contas");

            migrationBuilder.DropIndex(
                name: "IX_Contas_CartaoId",
                table: "Contas");

            migrationBuilder.AlterColumn<int>(
                name: "CartaoId",
                table: "Contas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CartaoId",
                table: "Cartoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contas_CartaoId",
                table: "Contas",
                column: "CartaoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contas_Cartoes_CartaoId",
                table: "Contas",
                column: "CartaoId",
                principalTable: "Cartoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
