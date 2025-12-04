using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroFuturo.Data.Migrations
{
    /// <inheritdoc />
    public partial class inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriaInsumo",
                columns: table => new
                {
                    CategoriaInsumoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnidadeMedida = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantidade = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaInsumo", x => x.CategoriaInsumoId);
                });

            migrationBuilder.CreateTable(
                name: "Equipamento",
                columns: table => new
                {
                    EquipamentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamento", x => x.EquipamentoId);
                });

            migrationBuilder.CreateTable(
                name: "Fazenda",
                columns: table => new
                {
                    FazendaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fazenda", x => x.FazendaId);
                });

            migrationBuilder.CreateTable(
                name: "ConsumoInsumo",
                columns: table => new
                {
                    ConsumoInsumoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuantidadeConsumida = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SafraInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SafraFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustoTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EquipamentoId = table.Column<int>(type: "int", nullable: false),
                    CategoriaInsumoId = table.Column<int>(type: "int", nullable: false),
                    FazendaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumoInsumo", x => x.ConsumoInsumoId);
                    table.ForeignKey(
                        name: "FK_ConsumoInsumo_CategoriaInsumo_CategoriaInsumoId",
                        column: x => x.CategoriaInsumoId,
                        principalTable: "CategoriaInsumo",
                        principalColumn: "CategoriaInsumoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsumoInsumo_Equipamento_EquipamentoId",
                        column: x => x.EquipamentoId,
                        principalTable: "Equipamento",
                        principalColumn: "EquipamentoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsumoInsumo_Fazenda_FazendaId",
                        column: x => x.FazendaId,
                        principalTable: "Fazenda",
                        principalColumn: "FazendaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsumoInsumo_CategoriaInsumoId",
                table: "ConsumoInsumo",
                column: "CategoriaInsumoId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumoInsumo_EquipamentoId",
                table: "ConsumoInsumo",
                column: "EquipamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumoInsumo_FazendaId",
                table: "ConsumoInsumo",
                column: "FazendaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsumoInsumo");

            migrationBuilder.DropTable(
                name: "CategoriaInsumo");

            migrationBuilder.DropTable(
                name: "Equipamento");

            migrationBuilder.DropTable(
                name: "Fazenda");
        }
    }
}
