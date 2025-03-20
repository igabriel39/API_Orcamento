using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Orcamento.Migrations
{
    /// <inheritdoc />
    public partial class autorelacionamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbLancamentos_tbLancamentos_LancamentoModel",
                table: "tbLancamentos");

            migrationBuilder.RenameColumn(
                name: "LancamentoModel",
                table: "tbLancamentos",
                newName: "LancamentoId");

            migrationBuilder.RenameIndex(
                name: "IX_tbLancamentos_LancamentoModel",
                table: "tbLancamentos",
                newName: "IX_tbLancamentos_LancamentoId");

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

            migrationBuilder.RenameColumn(
                name: "LancamentoId",
                table: "tbLancamentos",
                newName: "LancamentoModel");

            migrationBuilder.RenameIndex(
                name: "IX_tbLancamentos_LancamentoId",
                table: "tbLancamentos",
                newName: "IX_tbLancamentos_LancamentoModel");

            migrationBuilder.AddForeignKey(
                name: "FK_tbLancamentos_tbLancamentos_LancamentoModel",
                table: "tbLancamentos",
                column: "LancamentoModel",
                principalTable: "tbLancamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
