using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Orcamento.Migrations
{
    /// <inheritdoc />
    public partial class campoCodigoDecimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Codigo",
                table: "tbGrupoDespesa",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Codigo",
                table: "tbGrupoDespesa",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
