using API_Orcamento.Models;

namespace API_Orcamento.Repository.Interfaces
{
    public interface IProgramaRepository
    {
        Task<List<ProgramaModel>> BuscarTodosProgramas();
        Task<ProgramaModel> BuscarPorId(int id);
        Task<ProgramaModel> AdicionarPrograma(ProgramaModel programa);
        Task<ProgramaModel> AtualizarPrograma(ProgramaModel programa);
        Task ApagarPrograma(ProgramaModel programa);
    }
}
