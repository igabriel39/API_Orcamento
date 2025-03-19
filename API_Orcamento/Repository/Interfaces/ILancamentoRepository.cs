using API_Orcamento.Models;

namespace API_Orcamento.Repository.Interfaces
{
    public interface ILancamentoRepository
    {
        Task<List<ConsultaLancamento>> BuscarTodosLancamentos();
        //Task<AcaoModel> BuscarPorId(int id);
        //Task<AcaoModel> AdicionarAcao(AcaoModel acao);
        //Task<AcaoModel> AtualizarAcao(AcaoModel acao);
        //Task ApagarAcao(AcaoModel acao);
    }
}
