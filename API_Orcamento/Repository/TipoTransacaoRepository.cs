using API_Orcamento.Models;
using API_Orcamento.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_Orcamento.Repository
{
    public class TipoTransacaoRepository : ITipoTransacaoRepository
    {
        private readonly _DbContext _dbContext;
        public TipoTransacaoRepository(_DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TipoTransacaoModel> BuscarPorId(int id)
        {
            return await _dbContext.tbTipoTransacao.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TipoTransacaoModel>> BuscarTodosTiposTransacoes()
        {
            return await _dbContext.tbTipoTransacao.ToListAsync();
        }

        public async Task<TipoTransacaoModel> AdicionarTipoTransacao(TipoTransacaoModel tipoTransacao)
        {
            await _dbContext.tbTipoTransacao.AddAsync(tipoTransacao);
            await _dbContext.SaveChangesAsync();

            return tipoTransacao;
        }

        public async Task ApagarTipoTransacao(TipoTransacaoModel tipoTransacao)
        {
            _dbContext.tbTipoTransacao.Remove(tipoTransacao);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<TipoTransacaoModel> AtualizarTipoTransacao(TipoTransacaoModel tipoTransacao)
        {
            _dbContext.tbTipoTransacao.Update(tipoTransacao);
            await _dbContext.SaveChangesAsync();

            return tipoTransacao;
        }
    }
}
