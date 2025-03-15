using API_Orcamento.Models;
using API_Orcamento.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_Orcamento.Repository
{
    public class ObjetivoEstrategicoRepository : IObjetivoEstrategicoRepository
    {
        // Injeção de dependência com o banco de dados para pode realizar as tarefas básicas que precisa conexão com a base
        private readonly _DbContext _dbContext;
        public ObjetivoEstrategicoRepository(_DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ObjetivoEstrategicoModel> BuscarPorId(int id)
        {
            return await _dbContext.tbObjetivoEstrategico.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ObjetivoEstrategicoModel>> BuscarTodosObjetivosEstrategicos()
        {
            return await _dbContext.tbObjetivoEstrategico.ToListAsync();
        }

        public async Task<ObjetivoEstrategicoModel> AdicionarObjetivoEstrategico(ObjetivoEstrategicoModel objetivoEstrategico)
        {
            await _dbContext.tbObjetivoEstrategico.AddAsync(objetivoEstrategico);
            await _dbContext.SaveChangesAsync();

            return objetivoEstrategico;
        }

        public async Task ApagarObjetivoEstrategico(ObjetivoEstrategicoModel objetivoEstrategico)
        {
            _dbContext.tbObjetivoEstrategico.Remove(objetivoEstrategico);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ObjetivoEstrategicoModel> AtualizarObjetivoEstrategico(ObjetivoEstrategicoModel objetivoEstrategico)
        {
            _dbContext.tbObjetivoEstrategico.Update(objetivoEstrategico);
            await _dbContext.SaveChangesAsync();

            return objetivoEstrategico;
        }
    }
}
