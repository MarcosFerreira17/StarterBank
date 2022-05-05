﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StarterBank.Data;

namespace StarterBank.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220505133920_updateConta")]
    partial class updateConta
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.16");

            modelBuilder.Entity("StarterBank.Model.Banco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Faixa")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.Property<int>("NumeroAgencia")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Bancos");
                });

            modelBuilder.Entity("StarterBank.Model.CaixaEletronico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BancoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Saldo")
                        .HasColumnType("int");

                    b.Property<int>("ValorSaque")
                        .HasColumnType("int");

                    b.Property<int>("nota10")
                        .HasColumnType("int");

                    b.Property<int>("nota100")
                        .HasColumnType("int");

                    b.Property<int>("nota20")
                        .HasColumnType("int");

                    b.Property<int>("nota50")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BancoId");

                    b.ToTable("CaixaEletronico");
                });

            modelBuilder.Entity("StarterBank.Model.Cartao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BancoId")
                        .HasColumnType("int");

                    b.Property<string>("Numero")
                        .HasColumnType("longtext");

                    b.Property<string>("Role")
                        .HasColumnType("longtext");

                    b.Property<string>("Senha")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Cartoes");
                });

            modelBuilder.Entity("StarterBank.Model.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CPF")
                        .HasColumnType("longtext");

                    b.Property<int>("ContaId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.Property<string>("Profissao")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("StarterBank.Model.Conta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("BancoId")
                        .HasColumnType("int");

                    b.Property<int>("CaixaEletronicoId")
                        .HasColumnType("int");

                    b.Property<int>("CartaoId")
                        .HasColumnType("int");

                    b.Property<int>("NumeroConta")
                        .HasColumnType("int");

                    b.Property<float>("Saldo")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("BancoId");

                    b.ToTable("Contas");
                });

            modelBuilder.Entity("StarterBank.Model.CaixaEletronico", b =>
                {
                    b.HasOne("StarterBank.Model.Banco", "Banco")
                        .WithMany()
                        .HasForeignKey("BancoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Banco");
                });

            modelBuilder.Entity("StarterBank.Model.Conta", b =>
                {
                    b.HasOne("StarterBank.Model.Banco", "Banco")
                        .WithMany()
                        .HasForeignKey("BancoId");

                    b.Navigation("Banco");
                });
#pragma warning restore 612, 618
        }
    }
}
