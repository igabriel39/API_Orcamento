using API_Orcamento.Models;

namespace API_Orcamento.Repository.Interfaces
{
    public interface ITipoLancamentoRepository
    {
        Task<List<TipoLancamentoModel>> BuscarTodosTiposLancamentos();
        Task<TipoLancamentoModel> BuscarPorId(int id);
        Task<TipoLancamentoModel> AdicionarTipoLancamento(TipoLancamentoModel tipoLancamento);
        Task<TipoLancamentoModel> AtualizarTipoLancamento(TipoLancamentoModel tipoLancamento);
        Task ApagarTipoLancamento(TipoLancamentoModel tipoLancamento);
    }
}
