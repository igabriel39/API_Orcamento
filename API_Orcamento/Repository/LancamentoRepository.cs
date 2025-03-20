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
        // Script para consultar os lançamentos fazendo relação com as tabelas de apoio
        #region Script de consulta lançamentos
        string script = @"SELECT
                              L.id,
                              L.lancamentoValido,
                              L.numeroLancamento,
                              L.descricao,
                              L.dataLancamento,
                              L.lancamentoId AS idLancamentoPai,
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

        public LancamentoRepository(_DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ConsultaLancamento> BuscarPorId(int id)
        {
            var sql = FormattableStringFactory.Create(script);
            return await _dbContext.Database.SqlQuery<ConsultaLancamento>(sql).Where(l => l.Id == id).FirstOrDefaultAsync();
        }

        public async Task<LancamentoModel> BuscarModelPorId(int id)
        {
            return await _dbContext.tbLancamentos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ConsultaLancamento>> BuscarTodosLancamentos()
        {
            var sql = FormattableStringFactory.Create(script);
            return await _dbContext.Database.SqlQuery<ConsultaLancamento>(sql).ToListAsync();
        }

        public async Task<LancamentoModel> AdicionarLancamento(LancamentoModel lancamento)
        {
            await _dbContext.tbLancamentos.AddAsync(lancamento);
            await _dbContext.SaveChangesAsync();

            return lancamento;
        }

        public async Task ApagarLancamento(LancamentoModel lancamento)
        {
            _dbContext.tbLancamentos.Remove(lancamento);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<LancamentoModel> AtualizarLancamento(LancamentoModel lancamento)
        {
            _dbContext.tbLancamentos.Update(lancamento);
            await _dbContext.SaveChangesAsync();

            return lancamento;
        }
    }
}
