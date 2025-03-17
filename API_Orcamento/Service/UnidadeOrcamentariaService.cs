using API_Orcamento.Models;
using API_Orcamento.Repository.Interfaces;
using API_Orcamento.Rest.Dto;
using API_Orcamento.Rest.Form;
using API_Orcamento.Service.Exceptions;
using AutoMapper;

namespace API_Orcamento.Service
{
    public class UnidadeOrcamentariaService
    {
        // Injeção de dependência com a camada de repositório para persistir ou consultar as informações no banco
        // Injeção de dependência com o AutoMapper para fazer o mapeamento de Model para Dto
        private readonly IUnidadeOrcamentariaRepository _unidadeOrcamentariaRepository;
        private readonly IMapper _mapper;
        public UnidadeOrcamentariaService(IUnidadeOrcamentariaRepository unidadeOrcamentariaRepository, IMapper mapper)
        {
            _unidadeOrcamentariaRepository = unidadeOrcamentariaRepository;
            _mapper = mapper;
        }

        public async Task<List<UnidadeOrcamentariaDto>> ObterTodos()
        {
            try
            {
                List<UnidadeOrcamentariaModel> unidadeOrcamentariaModels = await _unidadeOrcamentariaRepository.BuscarTodasUnidadesOrcamentarias();

                return (List<UnidadeOrcamentariaDto>)_mapper.Map<IEnumerable<UnidadeOrcamentariaDto>>(unidadeOrcamentariaModels);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível consultar as Unidades Orçamentárias!");
            }
        }

        public async Task<UnidadeOrcamentariaDto> ObterPorId(int id)
        {
            try
            {
                UnidadeOrcamentariaModel unidadeOrcamentariaModel = await _unidadeOrcamentariaRepository.BuscarPorId(id);
                if (unidadeOrcamentariaModel == null)
                {
                    throw new ObjectNotFound($"Unidade Orçamentária não encontrada para o ID: {id}");
                }
                else
                {
                    return _mapper.Map<UnidadeOrcamentariaDto>(unidadeOrcamentariaModel);
                }
            }
            catch (ObjectNotFound ex)
            {
                throw new ObjectNotFound(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível consultar a Unidade Orçamentária para o ID: {id}!");
            }
        }

        public async Task<UnidadeOrcamentariaDto> Cadastrar(UnidadeOrcamentariaForm unidadeOrcamentariaForm)
        {
            try
            {
                UnidadeOrcamentariaModel unidadeOrcamentariaCadastrada = _mapper.Map<UnidadeOrcamentariaModel>(unidadeOrcamentariaForm);
                unidadeOrcamentariaCadastrada.DtCadastro = DateTime.Now;

                unidadeOrcamentariaCadastrada = await _unidadeOrcamentariaRepository.AdicionarUnidadeOrcamentaria(unidadeOrcamentariaCadastrada);
                return _mapper.Map<UnidadeOrcamentariaDto>(unidadeOrcamentariaCadastrada);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível cadastrar a Unidade Orçamentária desejada!");
            }
        }

        public async Task<UnidadeOrcamentariaDto> Atualizar(UnidadeOrcamentariaForm unidadeOrcamentariaForm, int id)
        {
            try
            {
                UnidadeOrcamentariaModel unidadeOrcamentariaExistente = await _unidadeOrcamentariaRepository.BuscarPorId(id);
                if (unidadeOrcamentariaExistente == null)
                {
                    throw new ObjectNotFound($"Unidade Orçamentária não encontrada para o ID: {id}");
                }
                else
                {
                    UnidadeOrcamentariaModel unidadeOrcamentariaAtualizada = unidadeOrcamentariaExistente;
                    unidadeOrcamentariaAtualizada.Codigo = unidadeOrcamentariaForm.codigo;
                    unidadeOrcamentariaAtualizada.Nome = unidadeOrcamentariaForm.nome;
                    unidadeOrcamentariaAtualizada.DtUltimaAlteracao = DateTime.Now;
                    unidadeOrcamentariaAtualizada = await _unidadeOrcamentariaRepository.AtualizarUnidadeOrcamentaria(unidadeOrcamentariaAtualizada);
                    return _mapper.Map<UnidadeOrcamentariaDto>(unidadeOrcamentariaAtualizada);
                }
            }
            catch (ObjectNotFound ex)
            {
                throw new ObjectNotFound(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar a Unidade Orçamentária desejada!");
            }
        }

        public async Task Apagar(int id)
        {
            try
            {
                UnidadeOrcamentariaModel unidadeOrcamentariaExistente = await _unidadeOrcamentariaRepository.BuscarPorId(id);
                if (unidadeOrcamentariaExistente == null)
                {
                    throw new ObjectNotFound($"Unidade Orçamentária não encontrada para o ID: {id}");
                }
                else
                {
                    await _unidadeOrcamentariaRepository.ApagarUnidadeOrcamentaria(unidadeOrcamentariaExistente);
                }
            }
            catch (ObjectNotFound ex)
            {
                throw new ObjectNotFound(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível apagar a Unidade Orçamentária desejada!");
            }
        }
    }
}
