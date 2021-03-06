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
                name: "Bancos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Faixa = table.Column<int>(type: "int", nullable: false),
                    NumeroAgencia = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CaixasEletronicosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bancos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cartoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Numero = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Senha = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Role = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BancoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartoes", x => x.Id);
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
                    ContaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Extratos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BancoId = table.Column<int>(type: "int", nullable: false),
                    ContaId = table.Column<int>(type: "int", nullable: false),
                    ValorDoSaque = table.Column<int>(type: "int", nullable: false),
                    ValorDoDeposito = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extratos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CaixaEletronico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BancoId = table.Column<int>(type: "int", nullable: false),
                    nota100 = table.Column<int>(type: "int", nullable: false),
                    nota50 = table.Column<int>(type: "int", nullable: false),
                    nota20 = table.Column<int>(type: "int", nullable: false),
                    nota10 = table.Column<int>(type: "int", nullable: false),
                    Saldo = table.Column<int>(type: "int", nullable: false),
                    ValorSaque = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaixaEletronico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaixaEletronico_Bancos_BancoId",
                        column: x => x.BancoId,
                        principalTable: "Bancos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Contas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NumeroConta = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Saldo = table.Column<float>(type: "float", nullable: false),
                    BancoId = table.Column<int>(type: "int", nullable: false),
                    CartaoId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contas_Bancos_BancoId",
                        column: x => x.BancoId,
                        principalTable: "Bancos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CaixaEletronico_BancoId",
                table: "CaixaEletronico",
                column: "BancoId");

            migrationBuilder.CreateIndex(
                name: "IX_Contas_BancoId",
                table: "Contas",
                column: "BancoId");

            migrationBuilder.Sql("INSERT INTO Bancos(Id, Nome, Faixa, NumeroAgencia, CaixasEletronicosId) VALUES('1','Santander','1234','2434', '1')");
            migrationBuilder.Sql("INSERT INTO Bancos(Id, Nome, Faixa, NumeroAgencia, CaixasEletronicosId) VALUES('2','Bradesco','4321','5425', '2')");
            migrationBuilder.Sql("INSERT INTO Bancos(Id, Nome, Faixa, NumeroAgencia, CaixasEletronicosId) VALUES('3','Mercantil','1244','2342', '3')");
            migrationBuilder.Sql("INSERT INTO Bancos(Id, Nome, Faixa, NumeroAgencia, CaixasEletronicosId) VALUES('4','Inter','5634','2423', '4')");

            migrationBuilder.Sql("INSERT INTO CaixaEletronico(Id, BancoId, nota100, nota50, nota20, nota10, Saldo, ValorSaque, Data) VALUES('1', '1', '100','100','100','100','18000', '0', '2022-05-03 13:51:00.666368')");
            migrationBuilder.Sql("INSERT INTO CaixaEletronico(Id, BancoId, nota100, nota50, nota20, nota10, Saldo, ValorSaque, Data) VALUES('2', '2', '100','100','100','100','18000', '0', '2022-05-03 13:51:00.666368')");
            migrationBuilder.Sql("INSERT INTO CaixaEletronico(Id, BancoId, nota100, nota50, nota20, nota10, Saldo, ValorSaque, Data) VALUES('3', '3', '100','100','100','100','18000', '0', '2022-05-03 13:51:00.666368')");
            migrationBuilder.Sql("INSERT INTO CaixaEletronico(Id, BancoId, nota100, nota50, nota20, nota10, Saldo, ValorSaque, Data) VALUES('4', '4', '5','5','5','10','950', '0', '2022-05-03 13:51:00.666368')");

            migrationBuilder.Sql("INSERT INTO Clientes(Id, Nome, Profissao, CPF, ContaId) VALUES('1','Marcos Ferreira','Dev','46680074700', '1')");
            migrationBuilder.Sql("INSERT INTO Clientes(Id, Nome, Profissao, CPF, ContaId) VALUES('2','João Ferreira','Dev','46680074700', '2')");
            migrationBuilder.Sql("INSERT INTO Clientes(Id, Nome, Profissao, CPF, ContaId) VALUES('3','Barbara Ferreira','Dev','46680074700', '3')");
            migrationBuilder.Sql("INSERT INTO Clientes(Id, Nome, Profissao, CPF, ContaId) VALUES('4','Irene Ferreira','Dev','46680074700', '4')");

            migrationBuilder.Sql("INSERT INTO Contas(Id, BancoId, NumeroConta, Saldo, CartaoId, ClienteId) VALUES('1','1','5634','100', '1', '1')");
            migrationBuilder.Sql("INSERT INTO Contas(Id, BancoId, NumeroConta, Saldo, CartaoId, ClienteId) VALUES('2','2','1255','100', '2', '2')");
            migrationBuilder.Sql("INSERT INTO Contas(Id, BancoId, NumeroConta, Saldo, CartaoId, ClienteId) VALUES('3','3','5533','100', '3', '3')");
            migrationBuilder.Sql("INSERT INTO Contas(Id, BancoId, NumeroConta, Saldo, CartaoId, ClienteId) VALUES('4','4','6544','100', '4', '4')");

            migrationBuilder.Sql("INSERT INTO Extratos(Id, BancoId, ContaId, ValorDoSaque, ValorDoDeposito) VALUES('1','1','1','100', '0')");
            migrationBuilder.Sql("INSERT INTO Extratos(Id, BancoId, ContaId, ValorDoSaque, ValorDoDeposito) VALUES('2','2','2','0', '50')");
            migrationBuilder.Sql("INSERT INTO Extratos(Id, BancoId, ContaId, ValorDoSaque, ValorDoDeposito) VALUES('3','3','3','0', '100')");
            migrationBuilder.Sql("INSERT INTO Extratos(Id, BancoId, ContaId, ValorDoSaque, ValorDoDeposito) VALUES('4','4','4','20', '0')");

            migrationBuilder.Sql("INSERT INTO Cartoes(Id, Numero, Senha, Role, BancoId) VALUES('1', '1234444444444444', 'B45CFFE084DD3D20D928BEE85E7B0F21', 'admin', '1')");
            migrationBuilder.Sql("INSERT INTO Cartoes(Id, Numero, Senha, Role, BancoId) VALUES('2', '4321444444444444', 'B45CFFE084DD3D20D928BEE85E7B0F21', 'user_comum', '2')");
            migrationBuilder.Sql("INSERT INTO Cartoes(Id, Numero, Senha, Role, BancoId) VALUES('3', '1244444444444444', 'B45CFFE084DD3D20D928BEE85E7B0F21', 'user_comum', '3')");
            migrationBuilder.Sql("INSERT INTO Cartoes(Id, Numero, Senha, Role, BancoId) VALUES('4', '5634444444444444', 'B45CFFE084DD3D20D928BEE85E7B0F21', 'user_comum', '4')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaixaEletronico");

            migrationBuilder.DropTable(
                name: "Cartoes");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Contas");

            migrationBuilder.DropTable(
                name: "Extratos");

            migrationBuilder.DropTable(
                name: "Bancos");
        }
    }
}
