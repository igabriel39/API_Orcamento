using API_Orcamento.Models;
using API_Orcamento.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_Orcamento.Repository
{
    public class UnidadeRepository : IUnidadeRepository
    {
        // Injeção de dependência com o banco de dados para pode realizar as tarefas básicas que precisa conexão com a base
        private readonly _DbContext _dbContext;
        public UnidadeRepository(_DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UnidadeModel> BuscarPorId(int id)
        {
            return await _dbContext.tbUnidade.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UnidadeModel>> BuscarTodasUnidades()
        {
            return await _dbContext.tbUnidade.ToListAsync();
        }

        public async Task<UnidadeModel> AdicionarUnidade(UnidadeModel unidade)
        {
            await _dbContext.tbUnidade.AddAsync(unidade);
            await _dbContext.SaveChangesAsync();

            return unidade;
        }

        public async Task ApagarUnidade(UnidadeModel unidade)
        {
            _dbContext.tbUnidade.Remove(unidade);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<UnidadeModel> AtualizarUnidade(UnidadeModel unidade)
        {
            _dbContext.tbUnidade.Update(unidade);
            await _dbContext.SaveChangesAsync();

            return unidade;
        }
    }
}
