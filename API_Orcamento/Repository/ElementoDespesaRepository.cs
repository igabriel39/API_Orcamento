using API_Orcamento.Models;
using API_Orcamento.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_Orcamento.Repository
{
    public class ElementoDespesaRepository : IElementoDespesaRepository
    {
        // Injeção de dependência com o banco de dados para pode realizar as tarefas básicas que precisa conexão com a base
        private readonly _DbContext _dbContext;
        public ElementoDespesaRepository(_DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ElementoDespesaModel> BuscarPorId(int id)
        {
            return await _dbContext.tbElementoDespesa.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ElementoDespesaModel>> BuscarTodosElementosDespesas()
        {
            return await _dbContext.tbElementoDespesa.ToListAsync();
        }

        public async Task<ElementoDespesaModel> AdicionarElementoDespesa(ElementoDespesaModel elementoDespesa)
        {
            await _dbContext.tbElementoDespesa.AddAsync(elementoDespesa);
            await _dbContext.SaveChangesAsync();

            return elementoDespesa;
        }

        public async Task ApagarElementoDespesa(ElementoDespesaModel elementoDespesa)
        {
            _dbContext.tbElementoDespesa.Remove(elementoDespesa);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ElementoDespesaModel> AtualizarElementoDespesa(ElementoDespesaModel elementoDespesa)
        {
            _dbContext.tbElementoDespesa.Update(elementoDespesa);
            await _dbContext.SaveChangesAsync();

            return elementoDespesa;
        }
    }
}
