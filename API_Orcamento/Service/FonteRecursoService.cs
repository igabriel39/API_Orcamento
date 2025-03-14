using API_Orcamento.Models;
using API_Orcamento.Repository.Interfaces;
using API_Orcamento.Rest.Dto;
using API_Orcamento.Rest.Form;
using API_Orcamento.Service.Exceptions;
using AutoMapper;

namespace API_Orcamento.Service
{
    public class FonteRecursoService
    {
        // Injeção de dependência com a camada de repositório para persistir ou consultar as informações no banco
        // Injeção de dependência com o AutoMapper para fazer o mapeamento de Model para Dto
        private readonly IFonteRecursoRepository _fonteRecursoRepository;
        private readonly IMapper _mapper;
        public FonteRecursoService(IFonteRecursoRepository fonteRecursoRepository, IMapper mapper)
        {
            _fonteRecursoRepository = fonteRecursoRepository;
            _mapper = mapper;
        }

        public async Task<List<FonteRecursoDto>> ObterTodos()
        {
            try
            {
                List<FonteRecursoModel> fonteRecursoModels = await _fonteRecursoRepository.BuscarTodasFontesRecursos();

                return (List<FonteRecursoDto>)_mapper.Map<IEnumerable<FonteRecursoDto>>(fonteRecursoModels);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível consultar as Fontes Recursos!");
            }
        }

        public async Task<FonteRecursoDto> ObterPorId(int id)
        {
            try
            {
                FonteRecursoModel fonteRecursoModel = await _fonteRecursoRepository.BuscarPorId(id);
                if (fonteRecursoModel == null)
                {
                    throw new ObjectNotFound($"Fonte Recurso não encontrada para o ID: {id}");
                }
                else
                {
                    return _mapper.Map<FonteRecursoDto>(fonteRecursoModel);
                }
            }
            catch (ObjectNotFound ex)
            {
                throw new ObjectNotFound(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível consultar a Fonte Recurso para o ID: {id}!");
            }
        }

        public async Task<FonteRecursoDto> Cadastrar(FonteRecursoForm fonteRecursoForm)
        {
            try
            {
                FonteRecursoModel fonteRecursoCadastrada = _mapper.Map<FonteRecursoModel>(fonteRecursoForm);
                fonteRecursoCadastrada.DtCadastro = DateTime.Now;

                fonteRecursoCadastrada = await _fonteRecursoRepository.AdicionarFonteRecurso(fonteRecursoCadastrada);
                return _mapper.Map<FonteRecursoDto>(fonteRecursoCadastrada);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível cadastrar a Fonte Recurso desejada!");
            }
        }

        public async Task<FonteRecursoDto> Atualizar(FonteRecursoForm fonteRecursoForm, int id)
        {
            try
            {
                FonteRecursoModel fonteRecursoExistente = await _fonteRecursoRepository.BuscarPorId(id);
                if (fonteRecursoExistente == null)
                {
                    throw new ObjectNotFound($"Fonte Recurso não encontrada para o ID: {id}");
                }
                else
                {
                    FonteRecursoModel fonteRecursoAtualizada = fonteRecursoExistente;
                    fonteRecursoAtualizada.Codigo = fonteRecursoForm.codigo;
                    fonteRecursoAtualizada.Nome = fonteRecursoForm.nome;
                    fonteRecursoAtualizada.DtUltimaAlteracao = DateTime.Now;
                    fonteRecursoAtualizada = await _fonteRecursoRepository.AtualizarFonteRecurso(fonteRecursoAtualizada);
                    return _mapper.Map<FonteRecursoDto>(fonteRecursoAtualizada);
                }
            }
            catch (ObjectNotFound ex)
            {
                throw new ObjectNotFound(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar a Fonte Recurso desejada!");
            }
        }

        public async Task Apagar(int id)
        {
            try
            {
                FonteRecursoModel fonteRecursoExistente = await _fonteRecursoRepository.BuscarPorId(id);
                if (fonteRecursoExistente == null)
                {
                    throw new ObjectNotFound($"Fonte Recurso não encontrada para o ID: {id}");
                }
                else
                {
                    await _fonteRecursoRepository.ApagarFonteRecurso(fonteRecursoExistente);
                }
            }
            catch (ObjectNotFound ex)
            {
                throw new ObjectNotFound(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível apagar a Fonte Recurso desejada!");
            }
        }
    }
}
