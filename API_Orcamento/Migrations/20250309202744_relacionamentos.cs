using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Orcamento.Migrations
{
    /// <inheritdoc />
    public partial class relacionamentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtUltimaAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ElementoDespesa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtUltimaAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementoDespesa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FonteRecurso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtUltimaAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FonteRecurso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GrupoDespesa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtUltimaAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoDespesa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModalidadeAplicacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtUltimaAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModalidadeAplicacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ObjetivoEstrategico",
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
                    table.PrimaryKey("PK_ObjetivoEstrategico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Programa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtUltimaAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Solicitante",
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
                    table.PrimaryKey("PK_Solicitante", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoLancamento",
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
                    table.PrimaryKey("PK_TipoLancamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoTransacao",
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
                    table.PrimaryKey("PK_TipoTransacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unidade",
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
                    table.PrimaryKey("PK_Unidade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnidadeOrcamentaria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtUltimaAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadeOrcamentaria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lancamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LancamentoValido = table.Column<bool>(type: "bit", nullable: false),
                    NumeroLancamento = table.Column<int>(type: "int", nullable: false),
                    DataLancamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GED = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contratado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AnoOrcamento = table.Column<int>(type: "int", nullable: false),
                    TipoLancamentoId = table.Column<int>(type: "int", nullable: false),
                    UnidadeId = table.Column<int>(type: "int", nullable: false),
                    UnidadeOrcamentariaId = table.Column<int>(type: "int", nullable: false),
                    ElementoDespesaId = table.Column<int>(type: "int", nullable: false),
                    AcaoId = table.Column<int>(type: "int", nullable: false),
                    ProgramaId = table.Column<int>(type: "int", nullable: false),
                    SolicitanteId = table.Column<int>(type: "int", nullable: false),
                    ObjetivoEstrategicoId = table.Column<int>(type: "int", nullable: false),
                    GrupoDespesaId = table.Column<int>(type: "int", nullable: false),
                    ModalidadeAplicacaoId = table.Column<int>(type: "int", nullable: false),
                    TipoTransacaoId = table.Column<int>(type: "int", nullable: false),
                    FonteRecursoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lancamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lancamentos_Acao_AcaoId",
                        column: x => x.AcaoId,
                        principalTable: "Acao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lancamentos_ElementoDespesa_ElementoDespesaId",
                        column: x => x.ElementoDespesaId,
                        principalTable: "ElementoDespesa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lancamentos_FonteRecurso_FonteRecursoId",
                        column: x => x.FonteRecursoId,
                        principalTable: "FonteRecurso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lancamentos_GrupoDespesa_GrupoDespesaId",
                        column: x => x.GrupoDespesaId,
                        principalTable: "GrupoDespesa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lancamentos_ModalidadeAplicacao_ModalidadeAplicacaoId",
                        column: x => x.ModalidadeAplicacaoId,
                        principalTable: "ModalidadeAplicacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lancamentos_ObjetivoEstrategico_ObjetivoEstrategicoId",
                        column: x => x.ObjetivoEstrategicoId,
                        principalTable: "ObjetivoEstrategico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lancamentos_Programa_ProgramaId",
                        column: x => x.ProgramaId,
                        principalTable: "Programa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lancamentos_Solicitante_SolicitanteId",
                        column: x => x.SolicitanteId,
                        principalTable: "Solicitante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lancamentos_TipoLancamento_TipoLancamentoId",
                        column: x => x.TipoLancamentoId,
                        principalTable: "TipoLancamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lancamentos_TipoTransacao_TipoTransacaoId",
                        column: x => x.TipoTransacaoId,
                        principalTable: "TipoTransacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lancamentos_UnidadeOrcamentaria_UnidadeOrcamentariaId",
                        column: x => x.UnidadeOrcamentariaId,
                        principalTable: "UnidadeOrcamentaria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lancamentos_Unidade_UnidadeId",
                        column: x => x.UnidadeId,
                        principalTable: "Unidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lancamentos_AcaoId",
                table: "Lancamentos",
                column: "AcaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Lancamentos_ElementoDespesaId",
                table: "Lancamentos",
                column: "ElementoDespesaId");

            migrationBuilder.CreateIndex(
                name: "IX_Lancamentos_FonteRecursoId",
                table: "Lancamentos",
                column: "FonteRecursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Lancamentos_GrupoDespesaId",
                table: "Lancamentos",
                column: "GrupoDespesaId");

            migrationBuilder.CreateIndex(
                name: "IX_Lancamentos_ModalidadeAplicacaoId",
                table: "Lancamentos",
                column: "ModalidadeAplicacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Lancamentos_ObjetivoEstrategicoId",
                table: "Lancamentos",
                column: "ObjetivoEstrategicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Lancamentos_ProgramaId",
                table: "Lancamentos",
                column: "ProgramaId");

            migrationBuilder.CreateIndex(
                name: "IX_Lancamentos_SolicitanteId",
                table: "Lancamentos",
                column: "SolicitanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Lancamentos_TipoLancamentoId",
                table: "Lancamentos",
                column: "TipoLancamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Lancamentos_TipoTransacaoId",
                table: "Lancamentos",
                column: "TipoTransacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Lancamentos_UnidadeId",
                table: "Lancamentos",
                column: "UnidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Lancamentos_UnidadeOrcamentariaId",
                table: "Lancamentos",
                column: "UnidadeOrcamentariaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lancamentos");

            migrationBuilder.DropTable(
                name: "Acao");

            migrationBuilder.DropTable(
                name: "ElementoDespesa");

            migrationBuilder.DropTable(
                name: "FonteRecurso");

            migrationBuilder.DropTable(
                name: "GrupoDespesa");

            migrationBuilder.DropTable(
                name: "ModalidadeAplicacao");

            migrationBuilder.DropTable(
                name: "ObjetivoEstrategico");

            migrationBuilder.DropTable(
                name: "Programa");

            migrationBuilder.DropTable(
                name: "Solicitante");

            migrationBuilder.DropTable(
                name: "TipoLancamento");

            migrationBuilder.DropTable(
                name: "TipoTransacao");

            migrationBuilder.DropTable(
                name: "UnidadeOrcamentaria");

            migrationBuilder.DropTable(
                name: "Unidade");
        }
    }
}
