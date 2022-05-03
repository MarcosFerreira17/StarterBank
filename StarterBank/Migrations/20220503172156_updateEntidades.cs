using Microsoft.EntityFrameworkCore.Migrations;

namespace StarterBank.Migrations
{
    public partial class updateEntidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cartoes_Clientes_ClienteId",
                table: "Cartoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Contas_Cartoes_cartaoId",
                table: "Contas");

            migrationBuilder.DropIndex(
                name: "IX_Contas_cartaoId",
                table: "Contas");

            migrationBuilder.DropIndex(
                name: "IX_Cartoes_ClienteId",
                table: "Cartoes");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Cartoes");

            migrationBuilder.RenameColumn(
                name: "cartaoId",
                table: "Contas",
                newName: "CartaoId");

            migrationBuilder.AlterColumn<int>(
                name: "CartaoId",
                table: "Contas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "Cartoes",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("MySql:CharSet", "utf8mb4");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "CartaoId",
                table: "Contas",
                newName: "cartaoId");

            migrationBuilder.AlterColumn<int>(
                name: "cartaoId",
                table: "Contas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "Numero",
                table: "Cartoes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Cartoes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contas_cartaoId",
                table: "Contas",
                column: "cartaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cartoes_ClienteId",
                table: "Cartoes",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cartoes_Clientes_ClienteId",
                table: "Cartoes",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contas_Cartoes_cartaoId",
                table: "Contas",
                column: "cartaoId",
                principalTable: "Cartoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
