using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Veiculo",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Placa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Cor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoVeiculo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculo", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Caminhao",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CapacidadeDeCarga = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CodigoVeiculo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caminhao", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Caminhao_Veiculo_CodigoVeiculo",
                        column: x => x.CodigoVeiculo,
                        principalTable: "Veiculo",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carro",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CapacidadePassageiro = table.Column<int>(type: "int", nullable: false),
                    CodigoVeiculo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carro", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Carro_Veiculo_CodigoVeiculo",
                        column: x => x.CodigoVeiculo,
                        principalTable: "Veiculo",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Revisao",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quilometragem = table.Column<int>(type: "int", nullable: false),
                    DataRevisao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorRevisao = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CodigoVeiculo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revisao", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Revisao_Veiculo_CodigoVeiculo",
                        column: x => x.CodigoVeiculo,
                        principalTable: "Veiculo",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Caminhao_CodigoVeiculo",
                table: "Caminhao",
                column: "CodigoVeiculo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carro_CodigoVeiculo",
                table: "Carro",
                column: "CodigoVeiculo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Revisao_CodigoVeiculo",
                table: "Revisao",
                column: "CodigoVeiculo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Caminhao");

            migrationBuilder.DropTable(
                name: "Carro");

            migrationBuilder.DropTable(
                name: "Revisao");

            migrationBuilder.DropTable(
                name: "Veiculo");
        }
    }
}
