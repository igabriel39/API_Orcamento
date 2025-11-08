using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Orcamento.Migrations
{
    /// <inheritdoc />
    public partial class tabela_de_orgaos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbOrgao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtUltimaAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbOrgao", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbOrgao");
        }
    }
}
