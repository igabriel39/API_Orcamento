using API_Orcamento.Models;
using API_Orcamento.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_Orcamento.Repository
{
    public class OrgaoRepository : IOrgaoRepository
    {
        // Injeção de dependência com o banco de dados para pode realizar as tarefas básicas que precisa conexão com a base
        private readonly _DbContext _dbContext;
        public OrgaoRepository(_DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OrgaoModel> BuscarPorId(int id)
        {
            return await _dbContext.tbOrgao.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<OrgaoModel>> BuscarTodosOrgaos()
        {
            return await _dbContext.tbOrgao.ToListAsync();
        }

        public async Task<OrgaoModel> AdicionarOrgao(OrgaoModel orgao)
        {
            await _dbContext.tbOrgao.AddAsync(orgao);
            await _dbContext.SaveChangesAsync();

            return orgao;
        }

        public async Task ApagarOrgao(OrgaoModel orgao)
        {
            _dbContext.tbOrgao.Remove(orgao);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<OrgaoModel> AtualizarOrgao(OrgaoModel orgao)
        {
            _dbContext.tbOrgao.Update(orgao);
            await _dbContext.SaveChangesAsync();

            return orgao;
        }
    }
}
