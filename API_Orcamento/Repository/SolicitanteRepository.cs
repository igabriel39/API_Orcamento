using API_Orcamento.Models;
using API_Orcamento.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_Orcamento.Repository
{
    public class SolicitanteRepository : ISolicitanteRepository
    {
        // Injeção de dependência com o banco de dados para pode realizar as tarefas básicas que precisa conexão com a base
        private readonly _DbContext _dbContext;
        public SolicitanteRepository(_DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<SolicitanteModel> BuscarPorId(int id)
        {
            return await _dbContext.tbSolicitante.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<SolicitanteModel>> BuscarTodosSolicitantes()
        {
            return await _dbContext.tbSolicitante.ToListAsync();
        }

        public async Task<SolicitanteModel> AdicionarSolicitante(SolicitanteModel solicitante)
        {
            await _dbContext.tbSolicitante.AddAsync(solicitante);
            await _dbContext.SaveChangesAsync();

            return solicitante;
        }

        public async Task ApagarSolicitante(SolicitanteModel solicitante)
        {
            _dbContext.tbSolicitante.Remove(solicitante);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<SolicitanteModel> AtualizarSolicitante(SolicitanteModel solicitante)
        {
            _dbContext.tbSolicitante.Update(solicitante);
            await _dbContext.SaveChangesAsync();

            return solicitante;
        }
    }
}
