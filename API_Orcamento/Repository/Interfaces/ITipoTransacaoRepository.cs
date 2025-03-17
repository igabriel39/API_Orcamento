using API_Orcamento.Models;

namespace API_Orcamento.Repository.Interfaces
{
    public interface ITipoTransacaoRepository
    {
        Task<List<TipoTransacaoModel>> BuscarTodosTiposTransacoes();
        Task<TipoTransacaoModel> BuscarPorId(int id);
        Task<TipoTransacaoModel> AdicionarTipoTransacao(TipoTransacaoModel tipoTransacaoModel);
        Task<TipoTransacaoModel> AtualizarTipoTransacao(TipoTransacaoModel tipoTransacaoModel);
        Task ApagarTipoTransacao(TipoTransacaoModel tipoTransacaoModel);
    }
}
