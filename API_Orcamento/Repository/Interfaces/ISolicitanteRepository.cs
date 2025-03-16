using API_Orcamento.Models;

namespace API_Orcamento.Repository.Interfaces
{
    public interface ISolicitanteRepository
    {
        Task<List<SolicitanteModel>> BuscarTodosSolicitantes();
        Task<SolicitanteModel> BuscarPorId(int id);
        Task<SolicitanteModel> AdicionarSolicitante(SolicitanteModel solicitante);
        Task<SolicitanteModel> AtualizarSolicitante(SolicitanteModel solicitante);
        Task ApagarSolicitante(SolicitanteModel solicitante);
    }
}
