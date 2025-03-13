using API_Orcamento.Models;
using API_Orcamento.Repository.Interfaces;
using API_Orcamento.Rest.Dto;
using API_Orcamento.Rest.Form;
using API_Orcamento.Service.Exceptions;
using AutoMapper;

namespace API_Orcamento.Service
{
    public class ElementoDespesaService
    {
        // Injeção de dependência com a camada de repositório para persistir ou consultar as informações no banco
        // Injeção de dependência com o AutoMapper para fazer o mapeamento de Model para Dto
        private readonly IElementoDespesaRepository _elementoDespesaRepository;
        private readonly IMapper _mapper;
        public ElementoDespesaService(IElementoDespesaRepository elementoDespesaRepository, IMapper mapper)
        {
            _elementoDespesaRepository = elementoDespesaRepository;
            _mapper = mapper;
        }

        public async Task<List<ElementoDespesaDto>> ObterTodos()
        {
            try
            {
                List<ElementoDespesaModel> elementoDespesaModels = await _elementoDespesaRepository.BuscarTodosElementosDespesas();

                return (List<ElementoDespesaDto>)_mapper.Map<IEnumerable<ElementoDespesaDto>>(elementoDespesaModels);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível consultar os Elementos Despesas!");
            }
        }

        public async Task<ElementoDespesaDto> ObterPorId(int id)
        {
            try
            {
                ElementoDespesaModel elementoDespesaModel = await _elementoDespesaRepository.BuscarPorId(id);
                if (elementoDespesaModel == null)
                {
                    throw new ObjectNotFound($"Elemento Despesa não encontrado para o ID: {id}");
                }
                else
                {
                    return _mapper.Map<ElementoDespesaDto>(elementoDespesaModel);
                }
            }
            catch (ObjectNotFound ex)
            {
                throw new ObjectNotFound(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível consultar o Elemento Despesa para o ID: {id}!");
            }
        }

        public async Task<ElementoDespesaDto> Cadastrar(ElementoDespesaForm elementoDespesaForm)
        {
            try
            {
                ElementoDespesaModel elementoDespesaCadastrado = _mapper.Map<ElementoDespesaModel>(elementoDespesaForm);
                elementoDespesaCadastrado.DtCadastro = DateTime.Now;

                elementoDespesaCadastrado = await _elementoDespesaRepository.AdicionarElementoDespesa(elementoDespesaCadastrado);
                return _mapper.Map<ElementoDespesaDto>(elementoDespesaCadastrado);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível cadastrar o Elemento Despesa desejado!");
            }
        }

        public async Task<ElementoDespesaDto> Atualizar(ElementoDespesaForm elementoDespesaForm, int id)
        {
            try
            {
                ElementoDespesaModel elementoDespesaExistente = await _elementoDespesaRepository.BuscarPorId(id);
                if (elementoDespesaExistente == null)
                {
                    throw new ObjectNotFound($"Elemento Despesa não encontrado para o ID: {id}");
                }
                else
                {
                    ElementoDespesaModel elementoDespesaAtualizado = elementoDespesaExistente;
                    elementoDespesaExistente.Codigo = elementoDespesaForm.codigo;
                    elementoDespesaExistente.Nome = elementoDespesaForm.nome;
                    elementoDespesaExistente.DtUltimaAlteracao = DateTime.Now;
                    elementoDespesaExistente = await _elementoDespesaRepository.AtualizarElementoDespesa(elementoDespesaExistente);
                    return _mapper.Map<ElementoDespesaDto>(elementoDespesaExistente);
                }
            }
            catch (ObjectNotFound ex)
            {
                throw new ObjectNotFound(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar o Elemento Despesa desejado!");
            }
        }

        public async Task Apagar(int id)
        {
            try
            {
                ElementoDespesaModel elementoDespesaExistente = await _elementoDespesaRepository.BuscarPorId(id);
                if (elementoDespesaExistente == null)
                {
                    throw new ObjectNotFound($"Elemento Despesa não encontrado para o ID: {id}");
                }
                else
                {
                    await _elementoDespesaRepository.ApagarElementoDespesa(elementoDespesaExistente);
                }
            }
            catch (ObjectNotFound ex)
            {
                throw new ObjectNotFound(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível apagar o Elemento Despesa desejado!");
            }
        }
    }
}
