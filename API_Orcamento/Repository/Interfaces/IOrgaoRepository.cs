using API_Orcamento.Models;

namespace API_Orcamento.Repository.Interfaces
{
    public interface IOrgaoRepository
    {
        Task<List<OrgaoModel>> BuscarTodosOrgaos();
        Task<OrgaoModel> BuscarPorId(int id);
        Task<OrgaoModel> AdicionarOrgao(OrgaoModel orgao);
        Task<OrgaoModel> AtualizarOrgao(OrgaoModel orgao);
        Task ApagarOrgao(OrgaoModel orgao);
    }
}
