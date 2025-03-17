using API_Orcamento.Models;
using API_Orcamento.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_Orcamento.Repository
{
    public class UnidadeOrcamentariaRepository : IUnidadeOrcamentariaRepository
    {
        // Injeção de dependência com o banco de dados para pode realizar as tarefas básicas que precisa conexão com a base
        private readonly _DbContext _dbContext;
        public UnidadeOrcamentariaRepository(_DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UnidadeOrcamentariaModel> BuscarPorId(int id)
        {
            return await _dbContext.tbUnidadeOrcamentaria.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UnidadeOrcamentariaModel>> BuscarTodasUnidadesOrcamentarias()
        {
            return await _dbContext.tbUnidadeOrcamentaria.ToListAsync();
        }

        public async Task<UnidadeOrcamentariaModel> AdicionarUnidadeOrcamentaria(UnidadeOrcamentariaModel unidadeOrcamentaria)
        {
            await _dbContext.tbUnidadeOrcamentaria.AddAsync(unidadeOrcamentaria);
            await _dbContext.SaveChangesAsync();

            return unidadeOrcamentaria;
        }

        public async Task ApagarUnidadeOrcamentaria(UnidadeOrcamentariaModel unidadeOrcamentaria)
        {
            _dbContext.tbUnidadeOrcamentaria.Remove(unidadeOrcamentaria);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<UnidadeOrcamentariaModel> AtualizarUnidadeOrcamentaria(UnidadeOrcamentariaModel unidadeOrcamentaria)
        {
            _dbContext.tbUnidadeOrcamentaria.Update(unidadeOrcamentaria);
            await _dbContext.SaveChangesAsync();

            return unidadeOrcamentaria;
        }
    }
}
