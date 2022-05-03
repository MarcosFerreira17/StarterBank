using Microsoft.EntityFrameworkCore.Migrations;

namespace StarterBank.Migrations
{
    public partial class updateCaixa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Banco",
                table: "CaixaEletronico",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "FaixaDoBanco",
                table: "CaixaEletronico",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.Sql("INSERT INTO CaixaEletronico(Id, nota100, nota50, nota20, nota10, Saldo, ValorSaque, Data, Banco, FaixaDoBanco) VALUES('1','100','100','100','100','1800', '0', '2022-05-03 13:51:00.666368', 'Santander', '1234')");
            migrationBuilder.Sql("INSERT INTO CaixaEletronico(Id, nota100, nota50, nota20, nota10, Saldo, ValorSaque, Data, Banco, FaixaDoBanco) VALUES('2','100','100','100','100','1800', '0', '2022-05-03 13:51:00.666368', 'Bradesco', '1554')");
            migrationBuilder.Sql("INSERT INTO CaixaEletronico(Id, nota100, nota50, nota20, nota10, Saldo, ValorSaque, Data, Banco, FaixaDoBanco) VALUES('3','100','100','100','100','1800', '0', '2022-05-03 13:51:00.666368', 'Mercantil', '2234')");
            migrationBuilder.Sql("INSERT INTO CaixaEletronico(Id, nota100, nota50, nota20, nota10, Saldo, ValorSaque, Data, Banco, FaixaDoBanco) VALUES('4','100','100','100','100','1800', '0', '2022-05-03 13:51:00.666368', 'Inter', '8586')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Banco",
                table: "CaixaEletronico");

            migrationBuilder.DropColumn(
                name: "FaixaDoBanco",
                table: "CaixaEletronico");
        }
    }
}
