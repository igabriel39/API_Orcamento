using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Orcamento.Migrations
{
    /// <inheritdoc />
    public partial class nometabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lancamentos_Acao_AcaoId",
                table: "Lancamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Lancamentos_ElementoDespesa_ElementoDespesaId",
                table: "Lancamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Lancamentos_FonteRecurso_FonteRecursoId",
                table: "Lancamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Lancamentos_GrupoDespesa_GrupoDespesaId",
                table: "Lancamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Lancamentos_ModalidadeAplicacao_ModalidadeAplicacaoId",
                table: "Lancamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Lancamentos_ObjetivoEstrategico_ObjetivoEstrategicoId",
                table: "Lancamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Lancamentos_Programa_ProgramaId",
                table: "Lancamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Lancamentos_Solicitante_SolicitanteId",
                table: "Lancamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Lancamentos_TipoLancamento_TipoLancamentoId",
                table: "Lancamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Lancamentos_TipoTransacao_TipoTransacaoId",
                table: "Lancamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Lancamentos_UnidadeOrcamentaria_UnidadeOrcamentariaId",
                table: "Lancamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Lancamentos_Unidade_UnidadeId",
                table: "Lancamentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnidadeOrcamentaria",
                table: "UnidadeOrcamentaria");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Unidade",
                table: "Unidade");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoTransacao",
                table: "TipoTransacao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoLancamento",
                table: "TipoLancamento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Solicitante",
                table: "Solicitante");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Programa",
                table: "Programa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ObjetivoEstrategico",
                table: "ObjetivoEstrategico");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ModalidadeAplicacao",
                table: "ModalidadeAplicacao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lancamentos",
                table: "Lancamentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GrupoDespesa",
                table: "GrupoDespesa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FonteRecurso",
                table: "FonteRecurso");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ElementoDespesa",
                table: "ElementoDespesa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Acao",
                table: "Acao");

            migrationBuilder.RenameTable(
                name: "UnidadeOrcamentaria",
                newName: "tbUnidadeOrcamentaria");

            migrationBuilder.RenameTable(
                name: "Unidade",
                newName: "tbUnidade");

            migrationBuilder.RenameTable(
                name: "TipoTransacao",
                newName: "tbTipoTransacao");

            migrationBuilder.RenameTable(
                name: "TipoLancamento",
                newName: "tbTipoLancamento");

            migrationBuilder.RenameTable(
                name: "Solicitante",
                newName: "tbSolicitante");

            migrationBuilder.RenameTable(
                name: "Programa",
                newName: "tbPrograma");

            migrationBuilder.RenameTable(
                name: "ObjetivoEstrategico",
                newName: "tbObjetivoEstrategico");

            migrationBuilder.RenameTable(
                name: "ModalidadeAplicacao",
                newName: "tbModalidadeAplicacao");

            migrationBuilder.RenameTable(
                name: "Lancamentos",
                newName: "tbLancamentos");

            migrationBuilder.RenameTable(
                name: "GrupoDespesa",
                newName: "tbGrupoDespesa");

            migrationBuilder.RenameTable(
                name: "FonteRecurso",
                newName: "tbFonteRecurso");

            migrationBuilder.RenameTable(
                name: "ElementoDespesa",
                newName: "tbElementoDespesa");

            migrationBuilder.RenameTable(
                name: "Acao",
                newName: "tbAcao");

            migrationBuilder.RenameIndex(
                name: "IX_Lancamentos_UnidadeOrcamentariaId",
                table: "tbLancamentos",
                newName: "IX_tbLancamentos_UnidadeOrcamentariaId");

            migrationBuilder.RenameIndex(
                name: "IX_Lancamentos_UnidadeId",
                table: "tbLancamentos",
                newName: "IX_tbLancamentos_UnidadeId");

            migrationBuilder.RenameIndex(
                name: "IX_Lancamentos_TipoTransacaoId",
                table: "tbLancamentos",
                newName: "IX_tbLancamentos_TipoTransacaoId");

            migrationBuilder.RenameIndex(
                name: "IX_Lancamentos_TipoLancamentoId",
                table: "tbLancamentos",
                newName: "IX_tbLancamentos_TipoLancamentoId");

            migrationBuilder.RenameIndex(
                name: "IX_Lancamentos_SolicitanteId",
                table: "tbLancamentos",
                newName: "IX_tbLancamentos_SolicitanteId");

            migrationBuilder.RenameIndex(
                name: "IX_Lancamentos_ProgramaId",
                table: "tbLancamentos",
                newName: "IX_tbLancamentos_ProgramaId");

            migrationBuilder.RenameIndex(
                name: "IX_Lancamentos_ObjetivoEstrategicoId",
                table: "tbLancamentos",
                newName: "IX_tbLancamentos_ObjetivoEstrategicoId");

            migrationBuilder.RenameIndex(
                name: "IX_Lancamentos_ModalidadeAplicacaoId",
                table: "tbLancamentos",
                newName: "IX_tbLancamentos_ModalidadeAplicacaoId");

            migrationBuilder.RenameIndex(
                name: "IX_Lancamentos_GrupoDespesaId",
                table: "tbLancamentos",
                newName: "IX_tbLancamentos_GrupoDespesaId");

            migrationBuilder.RenameIndex(
                name: "IX_Lancamentos_FonteRecursoId",
                table: "tbLancamentos",
                newName: "IX_tbLancamentos_FonteRecursoId");

            migrationBuilder.RenameIndex(
                name: "IX_Lancamentos_ElementoDespesaId",
                table: "tbLancamentos",
                newName: "IX_tbLancamentos_ElementoDespesaId");

            migrationBuilder.RenameIndex(
                name: "IX_Lancamentos_AcaoId",
                table: "tbLancamentos",
                newName: "IX_tbLancamentos_AcaoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbUnidadeOrcamentaria",
                table: "tbUnidadeOrcamentaria",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbUnidade",
                table: "tbUnidade",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbTipoTransacao",
                table: "tbTipoTransacao",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbTipoLancamento",
                table: "tbTipoLancamento",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbSolicitante",
                table: "tbSolicitante",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbPrograma",
                table: "tbPrograma",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbObjetivoEstrategico",
                table: "tbObjetivoEstrategico",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbModalidadeAplicacao",
                table: "tbModalidadeAplicacao",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbLancamentos",
                table: "tbLancamentos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbGrupoDespesa",
                table: "tbGrupoDespesa",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbFonteRecurso",
                table: "tbFonteRecurso",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbElementoDespesa",
                table: "tbElementoDespesa",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbAcao",
                table: "tbAcao",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbLancamentos_tbAcao_AcaoId",
                table: "tbLancamentos",
                column: "AcaoId",
                principalTable: "tbAcao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbLancamentos_tbElementoDespesa_ElementoDespesaId",
                table: "tbLancamentos",
                column: "ElementoDespesaId",
                principalTable: "tbElementoDespesa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbLancamentos_tbFonteRecurso_FonteRecursoId",
                table: "tbLancamentos",
                column: "FonteRecursoId",
                principalTable: "tbFonteRecurso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbLancamentos_tbGrupoDespesa_GrupoDespesaId",
                table: "tbLancamentos",
                column: "GrupoDespesaId",
                principalTable: "tbGrupoDespesa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbLancamentos_tbModalidadeAplicacao_ModalidadeAplicacaoId",
                table: "tbLancamentos",
                column: "ModalidadeAplicacaoId",
                principalTable: "tbModalidadeAplicacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbLancamentos_tbObjetivoEstrategico_ObjetivoEstrategicoId",
                table: "tbLancamentos",
                column: "ObjetivoEstrategicoId",
                principalTable: "tbObjetivoEstrategico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbLancamentos_tbPrograma_ProgramaId",
                table: "tbLancamentos",
                column: "ProgramaId",
                principalTable: "tbPrograma",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbLancamentos_tbSolicitante_SolicitanteId",
                table: "tbLancamentos",
                column: "SolicitanteId",
                principalTable: "tbSolicitante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbLancamentos_tbTipoLancamento_TipoLancamentoId",
                table: "tbLancamentos",
                column: "TipoLancamentoId",
                principalTable: "tbTipoLancamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbLancamentos_tbTipoTransacao_TipoTransacaoId",
                table: "tbLancamentos",
                column: "TipoTransacaoId",
                principalTable: "tbTipoTransacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbLancamentos_tbUnidadeOrcamentaria_UnidadeOrcamentariaId",
                table: "tbLancamentos",
                column: "UnidadeOrcamentariaId",
                principalTable: "tbUnidadeOrcamentaria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbLancamentos_tbUnidade_UnidadeId",
                table: "tbLancamentos",
                column: "UnidadeId",
                principalTable: "tbUnidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbLancamentos_tbAcao_AcaoId",
                table: "tbLancamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_tbLancamentos_tbElementoDespesa_ElementoDespesaId",
                table: "tbLancamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_tbLancamentos_tbFonteRecurso_FonteRecursoId",
                table: "tbLancamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_tbLancamentos_tbGrupoDespesa_GrupoDespesaId",
                table: "tbLancamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_tbLancamentos_tbModalidadeAplicacao_ModalidadeAplicacaoId",
                table: "tbLancamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_tbLancamentos_tbObjetivoEstrategico_ObjetivoEstrategicoId",
                table: "tbLancamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_tbLancamentos_tbPrograma_ProgramaId",
                table: "tbLancamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_tbLancamentos_tbSolicitante_SolicitanteId",
                table: "tbLancamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_tbLancamentos_tbTipoLancamento_TipoLancamentoId",
                table: "tbLancamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_tbLancamentos_tbTipoTransacao_TipoTransacaoId",
                table: "tbLancamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_tbLancamentos_tbUnidadeOrcamentaria_UnidadeOrcamentariaId",
                table: "tbLancamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_tbLancamentos_tbUnidade_UnidadeId",
                table: "tbLancamentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbUnidadeOrcamentaria",
                table: "tbUnidadeOrcamentaria");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbUnidade",
                table: "tbUnidade");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbTipoTransacao",
                table: "tbTipoTransacao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbTipoLancamento",
                table: "tbTipoLancamento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbSolicitante",
                table: "tbSolicitante");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbPrograma",
                table: "tbPrograma");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbObjetivoEstrategico",
                table: "tbObjetivoEstrategico");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbModalidadeAplicacao",
                table: "tbModalidadeAplicacao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbLancamentos",
                table: "tbLancamentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbGrupoDespesa",
                table: "tbGrupoDespesa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbFonteRecurso",
                table: "tbFonteRecurso");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbElementoDespesa",
                table: "tbElementoDespesa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbAcao",
                table: "tbAcao");

            migrationBuilder.RenameTable(
                name: "tbUnidadeOrcamentaria",
                newName: "UnidadeOrcamentaria");

            migrationBuilder.RenameTable(
                name: "tbUnidade",
                newName: "Unidade");

            migrationBuilder.RenameTable(
                name: "tbTipoTransacao",
                newName: "TipoTransacao");

            migrationBuilder.RenameTable(
                name: "tbTipoLancamento",
                newName: "TipoLancamento");

            migrationBuilder.RenameTable(
                name: "tbSolicitante",
                newName: "Solicitante");

            migrationBuilder.RenameTable(
                name: "tbPrograma",
                newName: "Programa");

            migrationBuilder.RenameTable(
                name: "tbObjetivoEstrategico",
                newName: "ObjetivoEstrategico");

            migrationBuilder.RenameTable(
                name: "tbModalidadeAplicacao",
                newName: "ModalidadeAplicacao");

            migrationBuilder.RenameTable(
                name: "tbLancamentos",
                newName: "Lancamentos");

            migrationBuilder.RenameTable(
                name: "tbGrupoDespesa",
                newName: "GrupoDespesa");

            migrationBuilder.RenameTable(
                name: "tbFonteRecurso",
                newName: "FonteRecurso");

            migrationBuilder.RenameTable(
                name: "tbElementoDespesa",
                newName: "ElementoDespesa");

            migrationBuilder.RenameTable(
                name: "tbAcao",
                newName: "Acao");

            migrationBuilder.RenameIndex(
                name: "IX_tbLancamentos_UnidadeOrcamentariaId",
                table: "Lancamentos",
                newName: "IX_Lancamentos_UnidadeOrcamentariaId");

            migrationBuilder.RenameIndex(
                name: "IX_tbLancamentos_UnidadeId",
                table: "Lancamentos",
                newName: "IX_Lancamentos_UnidadeId");

            migrationBuilder.RenameIndex(
                name: "IX_tbLancamentos_TipoTransacaoId",
                table: "Lancamentos",
                newName: "IX_Lancamentos_TipoTransacaoId");

            migrationBuilder.RenameIndex(
                name: "IX_tbLancamentos_TipoLancamentoId",
                table: "Lancamentos",
                newName: "IX_Lancamentos_TipoLancamentoId");

            migrationBuilder.RenameIndex(
                name: "IX_tbLancamentos_SolicitanteId",
                table: "Lancamentos",
                newName: "IX_Lancamentos_SolicitanteId");

            migrationBuilder.RenameIndex(
                name: "IX_tbLancamentos_ProgramaId",
                table: "Lancamentos",
                newName: "IX_Lancamentos_ProgramaId");

            migrationBuilder.RenameIndex(
                name: "IX_tbLancamentos_ObjetivoEstrategicoId",
                table: "Lancamentos",
                newName: "IX_Lancamentos_ObjetivoEstrategicoId");

            migrationBuilder.RenameIndex(
                name: "IX_tbLancamentos_ModalidadeAplicacaoId",
                table: "Lancamentos",
                newName: "IX_Lancamentos_ModalidadeAplicacaoId");

            migrationBuilder.RenameIndex(
                name: "IX_tbLancamentos_GrupoDespesaId",
                table: "Lancamentos",
                newName: "IX_Lancamentos_GrupoDespesaId");

            migrationBuilder.RenameIndex(
                name: "IX_tbLancamentos_FonteRecursoId",
                table: "Lancamentos",
                newName: "IX_Lancamentos_FonteRecursoId");

            migrationBuilder.RenameIndex(
                name: "IX_tbLancamentos_ElementoDespesaId",
                table: "Lancamentos",
                newName: "IX_Lancamentos_ElementoDespesaId");

            migrationBuilder.RenameIndex(
                name: "IX_tbLancamentos_AcaoId",
                table: "Lancamentos",
                newName: "IX_Lancamentos_AcaoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnidadeOrcamentaria",
                table: "UnidadeOrcamentaria",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Unidade",
                table: "Unidade",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoTransacao",
                table: "TipoTransacao",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoLancamento",
                table: "TipoLancamento",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Solicitante",
                table: "Solicitante",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Programa",
                table: "Programa",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ObjetivoEstrategico",
                table: "ObjetivoEstrategico",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModalidadeAplicacao",
                table: "ModalidadeAplicacao",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lancamentos",
                table: "Lancamentos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GrupoDespesa",
                table: "GrupoDespesa",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FonteRecurso",
                table: "FonteRecurso",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ElementoDespesa",
                table: "ElementoDespesa",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Acao",
                table: "Acao",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lancamentos_Acao_AcaoId",
                table: "Lancamentos",
                column: "AcaoId",
                principalTable: "Acao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lancamentos_ElementoDespesa_ElementoDespesaId",
                table: "Lancamentos",
                column: "ElementoDespesaId",
                principalTable: "ElementoDespesa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lancamentos_FonteRecurso_FonteRecursoId",
                table: "Lancamentos",
                column: "FonteRecursoId",
                principalTable: "FonteRecurso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lancamentos_GrupoDespesa_GrupoDespesaId",
                table: "Lancamentos",
                column: "GrupoDespesaId",
                principalTable: "GrupoDespesa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lancamentos_ModalidadeAplicacao_ModalidadeAplicacaoId",
                table: "Lancamentos",
                column: "ModalidadeAplicacaoId",
                principalTable: "ModalidadeAplicacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lancamentos_ObjetivoEstrategico_ObjetivoEstrategicoId",
                table: "Lancamentos",
                column: "ObjetivoEstrategicoId",
                principalTable: "ObjetivoEstrategico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lancamentos_Programa_ProgramaId",
                table: "Lancamentos",
                column: "ProgramaId",
                principalTable: "Programa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lancamentos_Solicitante_SolicitanteId",
                table: "Lancamentos",
                column: "SolicitanteId",
                principalTable: "Solicitante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lancamentos_TipoLancamento_TipoLancamentoId",
                table: "Lancamentos",
                column: "TipoLancamentoId",
                principalTable: "TipoLancamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lancamentos_TipoTransacao_TipoTransacaoId",
                table: "Lancamentos",
                column: "TipoTransacaoId",
                principalTable: "TipoTransacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lancamentos_UnidadeOrcamentaria_UnidadeOrcamentariaId",
                table: "Lancamentos",
                column: "UnidadeOrcamentariaId",
                principalTable: "UnidadeOrcamentaria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lancamentos_Unidade_UnidadeId",
                table: "Lancamentos",
                column: "UnidadeId",
                principalTable: "Unidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
