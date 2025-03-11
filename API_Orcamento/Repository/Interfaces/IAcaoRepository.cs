using API_Orcamento.Models;

namespace API_Orcamento.Repository.Interfaces
{
    public interface IAcaoRepository  
    {
        Task<List<AcaoModel>> BuscarTodasAcoes();
        Task<AcaoModel> BuscarPorId(int id);
        Task<AcaoModel> AdicionarAcao(AcaoModel acao);
        Task<AcaoModel> AtualizarAcao(AcaoModel acao);
        Task<bool> ApagarAcao(AcaoModel acao);
    }
}
