using API_Orcamento.Models;

namespace API_Orcamento.Repository.Interfaces
{
    public interface IFonteRecursoRepository
    {
        Task<List<FonteRecursoModel>> BuscarTodasFontesRecursos();
        Task<FonteRecursoModel> BuscarPorId(int id);
        Task<FonteRecursoModel> AdicionarFonteRecurso(FonteRecursoModel fonteRecurso);
        Task<FonteRecursoModel> AtualizarFonteRecurso(FonteRecursoModel fonteRecurso);
        Task ApagarFonteRecurso(FonteRecursoModel fonteRecurso);
    }
}
