using API_Orcamento.Models;

namespace API_Orcamento.Repository.Interfaces
{
    public interface IModalidadeAplicacaoRepository
    {
        Task<List<ModalidadeAplicacaoModel>> BuscarTodasModalidadesAplicacoes();
        Task<ModalidadeAplicacaoModel> BuscarPorId(int id);
        Task<ModalidadeAplicacaoModel> AdicionarModalidadeAplicacao(ModalidadeAplicacaoModel modalidadeAplicacao);
        Task<ModalidadeAplicacaoModel> AtualizarModalidadeAplicacao(ModalidadeAplicacaoModel modalidadeAplicacao);
        Task ApagarModalidadeAplicacao(ModalidadeAplicacaoModel modalidadeAplicacao);
    }
}
