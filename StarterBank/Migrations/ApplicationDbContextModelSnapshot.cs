﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StarterBank.Data;

namespace StarterBank.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.16");

            modelBuilder.Entity("StarterBank.Model.CaixaEletronico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CartaoId")
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

                    b.HasIndex("CartaoId");

                    b.ToTable("CaixaEletronico");
                });

            modelBuilder.Entity("StarterBank.Model.Cartao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("ContaId")
                        .HasColumnType("int");

                    b.Property<long>("Numero")
                        .HasColumnType("bigint");

                    b.Property<float>("Saldo")
                        .HasColumnType("float");

                    b.Property<string>("Senha")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ContaId");

                    b.ToTable("Cartoes");
                });

            modelBuilder.Entity("StarterBank.Model.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CPF")
                        .HasColumnType("longtext");

                    b.Property<int?>("ContaId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.Property<string>("Profissao")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ContaId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("StarterBank.Model.Conta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Agencia")
                        .HasColumnType("int");

                    b.Property<string>("NomeBanco")
                        .HasColumnType("longtext");

                    b.Property<string>("Numero")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Contas");
                });

            modelBuilder.Entity("StarterBank.Model.CaixaEletronico", b =>
                {
                    b.HasOne("StarterBank.Model.Cartao", "Cartao")
                        .WithMany()
                        .HasForeignKey("CartaoId");

                    b.Navigation("Cartao");
                });

            modelBuilder.Entity("StarterBank.Model.Cartao", b =>
                {
                    b.HasOne("StarterBank.Model.Conta", "Conta")
                        .WithMany()
                        .HasForeignKey("ContaId");

                    b.Navigation("Conta");
                });

            modelBuilder.Entity("StarterBank.Model.Cliente", b =>
                {
                    b.HasOne("StarterBank.Model.Conta", "Conta")
                        .WithMany()
                        .HasForeignKey("ContaId");

                    b.Navigation("Conta");
                });
#pragma warning restore 612, 618
        }
    }
}
