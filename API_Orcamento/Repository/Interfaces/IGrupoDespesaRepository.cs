using API_Orcamento.Models;

namespace API_Orcamento.Repository.Interfaces
{
    public interface IGrupoDespesaRepository
    {
        Task<List<GrupoDespesaModel>> BuscarTodosGruposDespesas();
        Task<GrupoDespesaModel> BuscarPorId(int id);
        Task<GrupoDespesaModel> AdicionarGrupoDespesa(GrupoDespesaModel grupoDespesa);
        Task<GrupoDespesaModel> AtualizarGrupoDespesa(GrupoDespesaModel grupoDespesa);
        Task ApagarGrupoDespesa(GrupoDespesaModel grupoDespesa);
    }
}
