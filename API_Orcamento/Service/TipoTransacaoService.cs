using API_Orcamento.Models;
using API_Orcamento.Repository.Interfaces;
using API_Orcamento.Rest.Dto;
using API_Orcamento.Rest.Form;
using API_Orcamento.Service.Exceptions;
using AutoMapper;

namespace API_Orcamento.Service
{
    public class TipoTransacaoService
    {
        // Injeção de dependência com a camada de repositório para persistir ou consultar as informações no banco
        // Injeção de dependência com o AutoMapper para fazer o mapeamento de Model para Dto
        private readonly ITipoTransacaoRepository _tipoTransacaoRepository;
        private readonly IMapper _mapper;
        public TipoTransacaoService(ITipoTransacaoRepository tipoTransacaoRepository, IMapper mapper)
        {
            _tipoTransacaoRepository = tipoTransacaoRepository;
            _mapper = mapper;
        }

        public async Task<List<TipoTransacaoDto>> ObterTodos()
        {
            try
            {
                List<TipoTransacaoModel> tipoTransacaoModels = await _tipoTransacaoRepository.BuscarTodosTiposTransacoes();

                return (List<TipoTransacaoDto>)_mapper.Map<IEnumerable<TipoTransacaoDto>>(tipoTransacaoModels);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível consultar os Tipos Transações!");
            }
        }

        public async Task<TipoTransacaoDto> ObterPorId(int id)
        {
            try
            {
                TipoTransacaoModel tipoTransacaoModel = await _tipoTransacaoRepository.BuscarPorId(id);
                if (tipoTransacaoModel == null)
                {
                    throw new ObjectNotFound($"Tipo Transação não encontrado para o ID: {id}");
                }
                else
                {
                    return _mapper.Map<TipoTransacaoDto>(tipoTransacaoModel);
                }
            }
            catch (ObjectNotFound ex)
            {
                throw new ObjectNotFound(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível consultar o Tipo Transação para o ID: {id}!");
            }
        }

        public async Task<TipoTransacaoDto> Cadastrar(TipoTransacaoForm tipoTransacaoForm)
        {
            try
            {
                TipoTransacaoModel tipoTransacaoCadastrado = _mapper.Map<TipoTransacaoModel>(tipoTransacaoForm);
                tipoTransacaoCadastrado.DtCadastro = DateTime.Now;

                tipoTransacaoCadastrado = await _tipoTransacaoRepository.AdicionarTipoTransacao(tipoTransacaoCadastrado);
                return _mapper.Map<TipoTransacaoDto>(tipoTransacaoCadastrado);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível cadastrar o Tipo Transação desejado!");
            }
        }

        public async Task<TipoTransacaoDto> Atualizar(TipoTransacaoForm tipoTransacaoForm, int id)
        {
            try
            {
                TipoTransacaoModel tipoTransacaoExistente = await _tipoTransacaoRepository.BuscarPorId(id);
                if (tipoTransacaoExistente == null)
                {
                    throw new ObjectNotFound($"Tipo Transação não encontrado para o ID: {id}");
                }
                else
                {
                    TipoTransacaoModel tipoTransacaoAtualizado = tipoTransacaoExistente;
                    tipoTransacaoAtualizado.Nome = tipoTransacaoForm.nome;
                    tipoTransacaoAtualizado.DtUltimaAlteracao = DateTime.Now;
                    tipoTransacaoAtualizado = await _tipoTransacaoRepository.AtualizarTipoTransacao(tipoTransacaoAtualizado);
                    return _mapper.Map<TipoTransacaoDto>(tipoTransacaoAtualizado);
                }
            }
            catch (ObjectNotFound ex)
            {
                throw new ObjectNotFound(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar o Tipo Transação desejado!");
            }
        }

        public async Task Apagar(int id)
        {
            try
            {
                TipoTransacaoModel tipoTransacaoExistente = await _tipoTransacaoRepository.BuscarPorId(id);
                if (tipoTransacaoExistente == null)
                {
                    throw new ObjectNotFound($"Tipo Transação não encontrada para o ID: {id}");
                }
                else
                {
                    await _tipoTransacaoRepository.ApagarTipoTransacao(tipoTransacaoExistente);
                }
            }
            catch (ObjectNotFound ex)
            {
                throw new ObjectNotFound(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível apagar o Tipo Transação desejado!");
            }
        }
    }
}
