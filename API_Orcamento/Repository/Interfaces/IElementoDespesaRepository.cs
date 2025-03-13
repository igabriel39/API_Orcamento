using API_Orcamento.Models;

namespace API_Orcamento.Repository.Interfaces
{
    public interface IElementoDespesaRepository
    {
        Task<List<ElementoDespesaModel>> BuscarTodosElementosDespesas();
        Task<ElementoDespesaModel> BuscarPorId(int id);
        Task<ElementoDespesaModel> AdicionarElementoDespesa(ElementoDespesaModel elementoDespesa);
        Task<ElementoDespesaModel> AtualizarElementoDespesa(ElementoDespesaModel elementoDespesa);
        Task ApagarElementoDespesa(ElementoDespesaModel elementoDespesa);
    }
}
