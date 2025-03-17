using API_Orcamento.Models;

namespace API_Orcamento.Repository.Interfaces
{
    public interface IUnidadeOrcamentariaRepository
    {
        Task<List<UnidadeOrcamentariaModel>> BuscarTodasUnidadesOrcamentarias();
        Task<UnidadeOrcamentariaModel> BuscarPorId(int id);
        Task<UnidadeOrcamentariaModel> AdicionarUnidadeOrcamentaria(UnidadeOrcamentariaModel unidadeOrcamentaria);
        Task<UnidadeOrcamentariaModel> AtualizarUnidadeOrcamentaria(UnidadeOrcamentariaModel unidadeOrcamentaria);
        Task ApagarUnidadeOrcamentaria(UnidadeOrcamentariaModel unidadeOrcamentaria);
    }
}
