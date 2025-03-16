using API_Orcamento.Models;
using API_Orcamento.Repository.Interfaces;
using API_Orcamento.Rest.Dto;
using API_Orcamento.Rest.Form;
using API_Orcamento.Service.Exceptions;
using AutoMapper;

namespace API_Orcamento.Service
{
    public class TipoLancamentoService
    {
        // Injeção de dependência com a camada de repositório para persistir ou consultar as informações no banco
        // Injeção de dependência com o AutoMapper para fazer o mapeamento de Model para Dto
        private readonly ITipoLancamentoRepository _tipoLancamentoRepository;
        private readonly IMapper _mapper;
        public TipoLancamentoService(ITipoLancamentoRepository tipoLancamentoRepository, IMapper mapper)
        {
            _tipoLancamentoRepository = tipoLancamentoRepository;
            _mapper = mapper;
        }

        public async Task<List<TipoLancamentoDto>> ObterTodos()
        {
            try
            {
                List<TipoLancamentoModel> tipoLancamentoModels = await _tipoLancamentoRepository.BuscarTodosTiposLancamentos();

                return (List<TipoLancamentoDto>)_mapper.Map<IEnumerable<TipoLancamentoDto>>(tipoLancamentoModels);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível consultar os Tipos Lançamentos!");
            }
        }

        public async Task<TipoLancamentoDto> ObterPorId(int id)
        {
            try
            {
                TipoLancamentoModel tipoLancamentoModel = await _tipoLancamentoRepository.BuscarPorId(id);
                if (tipoLancamentoModel == null)
                {
                    throw new ObjectNotFound($"Tipo Lançamento não encontrado para o ID: {id}");
                }
                else
                {
                    return _mapper.Map<TipoLancamentoDto>(tipoLancamentoModel);
                }
            }
            catch (ObjectNotFound ex)
            {
                throw new ObjectNotFound(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível consultar o Tipo Lançamento para o ID: {id}!");
            }
        }

        public async Task<TipoLancamentoDto> Cadastrar(TipoLancamentoForm tipoLancamentoForm)
        {
            try
            {
                TipoLancamentoModel tipoLancamentoCadastrado = _mapper.Map<TipoLancamentoModel>(tipoLancamentoForm);
                tipoLancamentoCadastrado.DtCadastro = DateTime.Now;

                tipoLancamentoCadastrado = await _tipoLancamentoRepository.AdicionarTipoLancamento(tipoLancamentoCadastrado);
                return _mapper.Map<TipoLancamentoDto>(tipoLancamentoCadastrado);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível cadastrar o Tipo Lançamento desejado!");
            }
        }

        public async Task<TipoLancamentoDto> Atualizar(TipoLancamentoForm tipoLancamentoForm, int id)
        {
            try
            {
                TipoLancamentoModel tipoLancamentoExistente = await _tipoLancamentoRepository.BuscarPorId(id);
                if (tipoLancamentoExistente == null)
                {
                    throw new ObjectNotFound($"Tipo Lançamento não encontrado para o ID: {id}");
                }
                else
                {
                    TipoLancamentoModel tipoLancamentoAtualizado = tipoLancamentoExistente;
                    tipoLancamentoAtualizado.Nome = tipoLancamentoForm.nome;
                    tipoLancamentoAtualizado.DtUltimaAlteracao = DateTime.Now;
                    tipoLancamentoAtualizado = await _tipoLancamentoRepository.AtualizarTipoLancamento(tipoLancamentoAtualizado);
                    return _mapper.Map<TipoLancamentoDto>(tipoLancamentoAtualizado);
                }
            }
            catch (ObjectNotFound ex)
            {
                throw new ObjectNotFound(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar o Tipo Lançamento desejado!");
            }
        }

        public async Task Apagar(int id)
        {
            try
            {
                TipoLancamentoModel tipoLancamentoExistente = await _tipoLancamentoRepository.BuscarPorId(id);
                if (tipoLancamentoExistente == null)
                {
                    throw new ObjectNotFound($"Tipo Lançamento não encontrado para o ID: {id}");
                }
                else
                {
                    await _tipoLancamentoRepository.ApagarTipoLancamento(tipoLancamentoExistente);
                }
            }
            catch (ObjectNotFound ex)
            {
                throw new ObjectNotFound(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível apagar o Tipo Lançamento desejado!");
            }
        }
    }
}
