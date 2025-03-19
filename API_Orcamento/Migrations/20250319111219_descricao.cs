using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Orcamento.Migrations
{
    /// <inheritdoc />
    public partial class descricao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "tbLancamentos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IdLancamentoPai",
                table: "tbLancamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LancamentoId",
                table: "tbLancamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tbLancamentos_LancamentoId",
                table: "tbLancamentos",
                column: "LancamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbLancamentos_tbLancamentos_LancamentoId",
                table: "tbLancamentos",
                column: "LancamentoId",
                principalTable: "tbLancamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbLancamentos_tbLancamentos_LancamentoId",
                table: "tbLancamentos");

            migrationBuilder.DropIndex(
                name: "IX_tbLancamentos_LancamentoId",
                table: "tbLancamentos");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "tbLancamentos");

            migrationBuilder.DropColumn(
                name: "IdLancamentoPai",
                table: "tbLancamentos");

            migrationBuilder.DropColumn(
                name: "LancamentoId",
                table: "tbLancamentos");
        }
    }
}
