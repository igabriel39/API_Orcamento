using API_Orcamento.Models;
using API_Orcamento.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_Orcamento.Repository
{
    public class TipoLancamentoRepository : ITipoLancamentoRepository
    {
        // Injeção de dependência com o banco de dados para pode realizar as tarefas básicas que precisa conexão com a base
        private readonly _DbContext _dbContext;
        public TipoLancamentoRepository(_DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TipoLancamentoModel> BuscarPorId(int id)
        {
            return await _dbContext.tbTipoLancamento.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TipoLancamentoModel>> BuscarTodosTiposLancamentos()
        {
            return await _dbContext.tbTipoLancamento.ToListAsync();
        }

        public async Task<TipoLancamentoModel> AdicionarTipoLancamento(TipoLancamentoModel tipoLancamento)
        {
            await _dbContext.tbTipoLancamento.AddAsync(tipoLancamento);
            await _dbContext.SaveChangesAsync();

            return tipoLancamento;
        }

        public async Task ApagarTipoLancamento(TipoLancamentoModel tipoLancamento)
        {
            _dbContext.tbTipoLancamento.Remove(tipoLancamento);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<TipoLancamentoModel> AtualizarTipoLancamento(TipoLancamentoModel tipoLancamento)
        {
            _dbContext.tbTipoLancamento.Update(tipoLancamento);
            await _dbContext.SaveChangesAsync();

            return tipoLancamento;
        }
    }
}
