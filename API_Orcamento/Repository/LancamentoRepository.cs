using API_Orcamento.Models;
using API_Orcamento.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace API_Orcamento.Repository
{
    public class LancamentoRepository : ILancamentoRepository
    {
        // Injeção de dependência com o banco de dados para pode realizar as tarefas básicas que precisa conexão com a base
        private readonly _DbContext _dbContext;
        public LancamentoRepository(_DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ConsultaLancamento>> BuscarTodosLancamentos()
        {
            // Script para consultar os lançamentos fazendo relação com as tabelas de apoio
            #region script
            string script = @"SELECT
                              L.id,
                              L.lancamentoValido,
                              L.numeroLancamento,
                              L.descricao,
                              L.dataLancamento,
                              L.idLancamentoPai,
                              L.valor,
                              TL.nome as dsTipoLancamento,
                              U.nome AS dsUnidade,
                              UO.nome AS dsUnidadeOrcamentaria,
                              P.nome AS dsPrograma,
                              A.nome AS dsAcao,
                              FR.nome AS dsFonteRecurso,
                              GD.nome AS dsGrupoDespesa,
                              MA.nome AS dsModalidadeAplicacao,
                              ED.nome AS dsElementoDespesa,
                              CASE WHEN S.nome IS NULL THEN 'Não Informado' ELSE S.nome END AS dsSolicitante,
                              CASE WHEN OE.nome IS NULL THEN 'Não Informado' ELSE OE.nome END AS dsObjetivoEstrategico,
                              TT.nome AS dsTipoTransacao,
                              L.GED,
                              L.contratado,
                              L.anoOrcamento
                              FROM TBLANCAMENTOS L
                              JOIN TBTIPOLANCAMENTO TL ON L.TipoLancamentoId = TL.id
                              JOIN TBUNIDADE U ON L.UnidadeId = U.id
                              JOIN TBUNIDADEORCAMENTARIA UO ON L.UnidadeOrcamentariaId = UO.id
                              JOIN TBELEMENTODESPESA ED ON L.ElementoDespesaId = ED.id
                              JOIN TBACAO A ON L.AcaoId = A.id
                              JOIN TBPROGRAMA P ON L.ProgramaId = P.id
                              LEFT JOIN TBSOLICITANTE S ON L.SolicitanteId = S.id
                              LEFT JOIN TBOBJETIVOESTRATEGICO OE ON L.ObjetivoEstrategicoId = OE.id
                              JOIN TBGRUPODESPESA GD ON L.GrupoDespesaId = GD.id
                              JOIN TBMODALIDADEAPLICACAO MA ON L.ModalidadeAplicacaoId = MA.id
                              JOIN TBTIPOTRANSACAO TT ON L.TipoTransacaoId = TT.id
                              JOIN TBFONTERECURSO FR ON L.FonteRecursoId = FR.id";
            #endregion

            var sql = FormattableStringFactory.Create(script);
            return await _dbContext.Database.SqlQuery<ConsultaLancamento>(sql).ToListAsync();
        }
    }
}
