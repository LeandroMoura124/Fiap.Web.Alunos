﻿// <auto-generated />
using System;
using Fiap.Web.Alunos.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace Fiap.Web.Alunos.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ClienteModel", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"));

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Observacao")
                        .HasMaxLength(500)
                        .HasColumnType("NVARCHAR2(500)");

                    b.Property<int>("RepresentanteId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("ClienteId");

                    b.HasIndex("RepresentanteId");

                    b.ToTable("Clientes", (string)null);
                });

            modelBuilder.Entity("Fiap.Web.Alunos.Models.RepresentanteModel", b =>
                {
                    b.Property<int>("RepresentanteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("REPRESENTANTEID");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RepresentanteId"));

                    b.Property<string>("Cpf")
                        .HasColumnType("NVARCHAR2(450)")
                        .HasColumnName("CPF");

                    b.Property<string>("RepresentanteNome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("REPRESENTANTENOME");

                    b.HasKey("RepresentanteId");

                    b.HasIndex("Cpf")
                        .IsUnique()
                        .HasFilter("\"CPF\" IS NOT NULL");

                    b.ToTable("REPRESENTANTES", (string)null);
                });

            modelBuilder.Entity("ClienteModel", b =>
                {
                    b.HasOne("Fiap.Web.Alunos.Models.RepresentanteModel", "Representante")
                        .WithMany()
                        .HasForeignKey("RepresentanteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Representante");
                });
#pragma warning restore 612, 618
        }
    }
}