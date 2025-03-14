using API_Orcamento.Models;
using API_Orcamento.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_Orcamento.Repository
{
    public class GrupoDespesaRepository : IGrupoDespesaRepository
    {
        // Injeção de dependência com o banco de dados para pode realizar as tarefas básicas que precisa conexão com a base
        private readonly _DbContext _dbContext;
        public GrupoDespesaRepository(_DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GrupoDespesaModel> BuscarPorId(int id)
        {
            return await _dbContext.tbGrupoDespesa.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<GrupoDespesaModel>> BuscarTodosGruposDespesas()
        {
            return await _dbContext.tbGrupoDespesa.ToListAsync();
        }

        public async Task<GrupoDespesaModel> AdicionarGrupoDespesa(GrupoDespesaModel grupoDespesa)
        {
            await _dbContext.tbGrupoDespesa.AddAsync(grupoDespesa);
            await _dbContext.SaveChangesAsync();

            return grupoDespesa;
        }

        public async Task ApagarGrupoDespesa(GrupoDespesaModel grupoDespesa)
        {
            _dbContext.tbGrupoDespesa.Remove(grupoDespesa);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<GrupoDespesaModel> AtualizarGrupoDespesa(GrupoDespesaModel grupoDespesa)
        {
            _dbContext.tbGrupoDespesa.Update(grupoDespesa);
            await _dbContext.SaveChangesAsync();

            return grupoDespesa;
        }
    }
}
