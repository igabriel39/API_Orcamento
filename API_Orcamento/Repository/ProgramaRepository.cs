using API_Orcamento.Models;
using API_Orcamento.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_Orcamento.Repository
{
    public class ProgramaRepository : IProgramaRepository
    {
        // Injeção de dependência com o banco de dados para pode realizar as tarefas básicas que precisa conexão com a base
        private readonly _DbContext _dbContext;
        public ProgramaRepository(_DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProgramaModel> BuscarPorId(int id)
        {
            return await _dbContext.tbPrograma.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ProgramaModel>> BuscarTodosProgramas()
        {
            return await _dbContext.tbPrograma.ToListAsync();
        }

        public async Task<ProgramaModel> AdicionarPrograma(ProgramaModel programa)
        {
            await _dbContext.tbPrograma.AddAsync(programa);
            await _dbContext.SaveChangesAsync();

            return programa;
        }

        public async Task ApagarPrograma(ProgramaModel programa)
        {
            _dbContext.tbPrograma.Remove(programa);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ProgramaModel> AtualizarPrograma(ProgramaModel programa)
        {
            _dbContext.tbPrograma.Update(programa);
            await _dbContext.SaveChangesAsync();

            return programa;
        }
    }
}
