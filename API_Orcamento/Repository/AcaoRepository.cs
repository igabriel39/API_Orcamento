using API_Orcamento.Models;
using API_Orcamento.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_Orcamento.Repository
{
    public class AcaoRepository : IAcaoRepository
    {
        // Injeção de dependência com o banco de dados para pode realizar as tarefas básicas que precisa conexão com a base
        private readonly _DbContext _dbContext;
        public AcaoRepository(_DbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<AcaoModel> BuscarPorId(int id)
        {
            return await _dbContext.tbAcao.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<AcaoModel>> BuscarTodasAcoes()
        {
            return await _dbContext.tbAcao.ToListAsync();
        }

        public async Task<AcaoModel> AdicionarAcao(AcaoModel acao)
        {
            await _dbContext.tbAcao.AddAsync(acao);
            await _dbContext.SaveChangesAsync();

            return acao;
        }

        public async Task<bool> ApagarAcao(AcaoModel acao)
        {
            _dbContext.tbAcao.Remove(acao);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<AcaoModel> AtualizarAcao(AcaoModel acao)
        {
            _dbContext.tbAcao.Update(acao);
            await _dbContext.SaveChangesAsync();

            return acao;
        }
    }
}
