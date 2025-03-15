using API_Orcamento.Models;

namespace API_Orcamento.Repository.Interfaces
{
    public interface IObjetivoEstrategicoRepository
    {
        Task<List<ObjetivoEstrategicoModel>> BuscarTodosObjetivosEstrategicos();
        Task<ObjetivoEstrategicoModel> BuscarPorId(int id);
        Task<ObjetivoEstrategicoModel> AdicionarObjetivoEstrategico(ObjetivoEstrategicoModel objetivoEstrategico);
        Task<ObjetivoEstrategicoModel> AtualizarObjetivoEstrategico(ObjetivoEstrategicoModel objetivoEstrategico);
        Task ApagarObjetivoEstrategico(ObjetivoEstrategicoModel objetivoEstrategico);
    }
}
