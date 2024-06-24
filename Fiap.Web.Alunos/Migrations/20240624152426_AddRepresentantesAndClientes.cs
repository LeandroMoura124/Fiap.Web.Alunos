using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.Web.Alunos.Migrations
{
    /// <inheritdoc />
    public partial class AddRepresentantesAndClientes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "REPRESENTANTES",
                columns: table => new
                {
                    REPRESENTANTEID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    REPRESENTANTENOME = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CPF = table.Column<string>(type: "NVARCHAR2(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REPRESENTANTES", x => x.REPRESENTANTEID);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Sobrenome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "date", nullable: false),
                    Observacao = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: true),
                    RepresentanteId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                    table.ForeignKey(
                        name: "FK_Clientes_REPRESENTANTES_RepresentanteId",
                        column: x => x.RepresentanteId,
                        principalTable: "REPRESENTANTES",
                        principalColumn: "REPRESENTANTEID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_RepresentanteId",
                table: "Clientes",
                column: "RepresentanteId");

            migrationBuilder.CreateIndex(
                name: "IX_REPRESENTANTES_CPF",
                table: "REPRESENTANTES",
                column: "CPF",
                unique: true,
                filter: "\"CPF\" IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "REPRESENTANTES");
        }
    }
}
