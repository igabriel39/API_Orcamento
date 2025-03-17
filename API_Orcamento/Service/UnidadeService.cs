using API_Orcamento.Models;
using API_Orcamento.Repository.Interfaces;
using API_Orcamento.Rest.Dto;
using API_Orcamento.Rest.Form;
using API_Orcamento.Service.Exceptions;
using AutoMapper;

namespace API_Orcamento.Service
{
    public class UnidadeService
    {
        // Injeção de dependência com a camada de repositório para persistir ou consultar as informações no banco
        // Injeção de dependência com o AutoMapper para fazer o mapeamento de Model para Dto
        private readonly IUnidadeRepository _unidadeRepository;
        private readonly IMapper _mapper;
        public UnidadeService(IUnidadeRepository unidadeRepository, IMapper mapper)
        {
            _unidadeRepository = unidadeRepository;
            _mapper = mapper;
        }

        public async Task<List<UnidadeDto>> ObterTodos()
        {
            try
            {
                List<UnidadeModel> unidadeModels = await _unidadeRepository.BuscarTodasUnidades();

                return (List<UnidadeDto>)_mapper.Map<IEnumerable<UnidadeDto>>(unidadeModels);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível consultar as Unidades!");
            }
        }

        public async Task<UnidadeDto> ObterPorId(int id)
        {
            try
            {
                UnidadeModel unidadeModel = await _unidadeRepository.BuscarPorId(id);
                if (unidadeModel == null)
                {
                    throw new ObjectNotFound($"Unidade não encontrada para o ID: {id}");
                }
                else
                {
                    return _mapper.Map<UnidadeDto>(unidadeModel);
                }
            }
            catch (ObjectNotFound ex)
            {
                throw new ObjectNotFound(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível consultar a Unidade para o ID: {id}!");
            }
        }

        public async Task<UnidadeDto> Cadastrar(UnidadeForm unidadeForm)
        {
            try
            {
                UnidadeModel unidadeCadastrada = _mapper.Map<UnidadeModel>(unidadeForm);
                unidadeCadastrada.DtCadastro = DateTime.Now;

                unidadeCadastrada = await _unidadeRepository.AdicionarUnidade(unidadeCadastrada);
                return _mapper.Map<UnidadeDto>(unidadeCadastrada);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível cadastrar a Unidade desejada!");
            }
        }

        public async Task<UnidadeDto> Atualizar(UnidadeForm unidadeForm, int id)
        {
            try
            {
                UnidadeModel unidadeExistente = await _unidadeRepository.BuscarPorId(id);
                if (unidadeExistente == null)
                {
                    throw new ObjectNotFound($"Unidade não encontrada para o ID: {id}");
                }
                else
                {
                    UnidadeModel unidadeAtualizada = unidadeExistente;
                    unidadeAtualizada.Nome = unidadeForm.nome;
                    unidadeAtualizada.DtUltimaAlteracao = DateTime.Now;
                    unidadeAtualizada = await _unidadeRepository.AtualizarUnidade(unidadeAtualizada);
                    return _mapper.Map<UnidadeDto>(unidadeAtualizada);
                }
            }
            catch (ObjectNotFound ex)
            {
                throw new ObjectNotFound(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar a Unidade desejada!");
            }
        }

        public async Task Apagar(int id)
        {
            try
            {
                UnidadeModel unidadeExistente = await _unidadeRepository.BuscarPorId(id);
                if (unidadeExistente == null)
                {
                    throw new ObjectNotFound($"Unidade não encontrada para o ID: {id}");
                }
                else
                {
                    await _unidadeRepository.ApagarUnidade(unidadeExistente);
                }
            }
            catch (ObjectNotFound ex)
            {
                throw new ObjectNotFound(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível apagar a Unidade desejada!");
            }
        }
    }
}
