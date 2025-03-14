using API_Orcamento.Models;
using API_Orcamento.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_Orcamento.Repository
{
    public class FonteRecursoRepository : IFonteRecursoRepository
    {
        // Injeção de dependência com o banco de dados para pode realizar as tarefas básicas que precisa conexão com a base
        private readonly _DbContext _dbContext;
        public FonteRecursoRepository(_DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<FonteRecursoModel> BuscarPorId(int id)
        {
            return await _dbContext.tbFonteRecurso.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<FonteRecursoModel>> BuscarTodasFontesRecursos()
        {
            return await _dbContext.tbFonteRecurso.ToListAsync();
        }

        public async Task<FonteRecursoModel> AdicionarFonteRecurso(FonteRecursoModel fonteRecurso)
        {
            await _dbContext.tbFonteRecurso.AddAsync(fonteRecurso);
            await _dbContext.SaveChangesAsync();

            return fonteRecurso;
        }

        public async Task ApagarFonteRecurso(FonteRecursoModel fonteRecurso)
        {
            _dbContext.tbFonteRecurso.Remove(fonteRecurso);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<FonteRecursoModel> AtualizarFonteRecurso(FonteRecursoModel fonteRecurso)
        {
            _dbContext.tbFonteRecurso.Update(fonteRecurso);
            await _dbContext.SaveChangesAsync();

            return fonteRecurso;
        }
    }
}
