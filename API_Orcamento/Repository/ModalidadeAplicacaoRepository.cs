using API_Orcamento.Models;
using API_Orcamento.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_Orcamento.Repository
{
    public class ModalidadeAplicacaoRepository : IModalidadeAplicacaoRepository
    {
        // Injeção de dependência com o banco de dados para pode realizar as tarefas básicas que precisa conexão com a base
        private readonly _DbContext _dbContext;
        public ModalidadeAplicacaoRepository(_DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ModalidadeAplicacaoModel> BuscarPorId(int id)
        {
            return await _dbContext.tbModalidadeAplicacao.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ModalidadeAplicacaoModel>> BuscarTodasModalidadesAplicacoes()
        {
            return await _dbContext.tbModalidadeAplicacao.ToListAsync();
        }

        public async Task<ModalidadeAplicacaoModel> AdicionarModalidadeAplicacao(ModalidadeAplicacaoModel modalidadeAplicacao)
        {
            await _dbContext.tbModalidadeAplicacao.AddAsync(modalidadeAplicacao);
            await _dbContext.SaveChangesAsync();

            return modalidadeAplicacao;
        }

        public async Task ApagarModalidadeAplicacao(ModalidadeAplicacaoModel modalidadeAplicacao)
        {
            _dbContext.tbModalidadeAplicacao.Remove(modalidadeAplicacao);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ModalidadeAplicacaoModel> AtualizarModalidadeAplicacao(ModalidadeAplicacaoModel modalidadeAplicacao)
        {
            _dbContext.tbModalidadeAplicacao.Update(modalidadeAplicacao);
            await _dbContext.SaveChangesAsync();

            return modalidadeAplicacao;
        }
    }
}
