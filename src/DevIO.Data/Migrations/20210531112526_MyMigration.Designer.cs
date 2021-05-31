﻿// <auto-generated />
using System;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DevIO.Data.Migrations
{
    [DbContext(typeof(MeuDbContext))]
    [Migration("20210531112526_MyMigration")]
    partial class MyMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DevIO.Business.Models.CategoriaProduto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("CategoriaProdutos");
                });

            modelBuilder.Entity("DevIO.Business.Models.EntradaSaidaProduto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Data");

                    b.Property<string>("Operacao")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("ProdutoId");

                    b.Property<int>("Quantidade");

                    b.Property<string>("Responsavel")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.ToTable("EntradaSaidaProdutos");
                });

            modelBuilder.Entity("DevIO.Business.Models.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CategoriaProdutoId");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<int>("Quantidade");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaProdutoId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("DevIO.Business.Models.EntradaSaidaProduto", b =>
                {
                    b.HasOne("DevIO.Business.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId");
                });

            modelBuilder.Entity("DevIO.Business.Models.Produto", b =>
                {
                    b.HasOne("DevIO.Business.Models.CategoriaProduto", "CategoriaProduto")
                        .WithMany("Produtos")
                        .HasForeignKey("CategoriaProdutoId");
                });
#pragma warning restore 612, 618
        }
    }
}
