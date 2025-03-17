using API_Orcamento.Models;

namespace API_Orcamento.Repository.Interfaces
{
    public interface IUnidadeRepository
    {
        Task<List<UnidadeModel>> BuscarTodasUnidades();
        Task<UnidadeModel> BuscarPorId(int id);
        Task<UnidadeModel> AdicionarUnidade(UnidadeModel unidade);
        Task<UnidadeModel> AtualizarUnidade(UnidadeModel unidade);
        Task ApagarUnidade(UnidadeModel unidade);
    }
}
