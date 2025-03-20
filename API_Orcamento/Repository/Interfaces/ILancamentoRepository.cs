using API_Orcamento.Models;

namespace API_Orcamento.Repository.Interfaces
{
    public interface ILancamentoRepository
    {
        Task<List<ConsultaLancamento>> BuscarTodosLancamentos();
        Task<ConsultaLancamento> BuscarPorId(int id);
        Task<LancamentoModel> BuscarModelPorId(int id);
        Task<LancamentoModel> AdicionarLancamento(LancamentoModel lancamento);
        Task<LancamentoModel> AtualizarLancamento(LancamentoModel lancamento);
        Task ApagarLancamento(LancamentoModel lancamento);
    }
}
