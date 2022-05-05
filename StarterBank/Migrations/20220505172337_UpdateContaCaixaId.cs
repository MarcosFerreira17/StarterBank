using Microsoft.EntityFrameworkCore.Migrations;

namespace StarterBank.Migrations
{
    public partial class UpdateContaCaixaId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CaixaEletronicoId",
                table: "Contas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CaixaEletronicoId",
                table: "Contas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
