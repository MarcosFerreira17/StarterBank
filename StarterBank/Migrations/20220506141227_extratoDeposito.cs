using Microsoft.EntityFrameworkCore.Migrations;

namespace StarterBank.Migrations
{
    public partial class extratoDeposito : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ValorDoDeposito",
                table: "Extratos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorDoDeposito",
                table: "Extratos");
        }
    }
}
