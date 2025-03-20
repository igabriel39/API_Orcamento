using API_Orcamento.Models;
using API_Orcamento.Repository;
using API_Orcamento.Repository.Interfaces;
using API_Orcamento.Rest.Dto;
using API_Orcamento.Rest.Form;
using API_Orcamento.Service.Exceptions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API_Orcamento.Service
{
    public class LancamentoService
    {
        // Injeção de dependência com a camada de repositório para persistir ou consultar as informações no banco
        // Injeção de dependência com o AutoMapper para fazer o mapeamento de Model para Dto
        private readonly ILancamentoRepository _lancamentoRepository;
        private readonly IMapper _mapper;
        public LancamentoService(ILancamentoRepository lancamentoRepository, IMapper mapper)
        {
            _lancamentoRepository = lancamentoRepository;
            _mapper = mapper;
        }

        public async Task<List<LancamentoDto>> ObterTodos()
        {
            try
            {
                List<ConsultaLancamento> lancamentos = await _lancamentoRepository.BuscarTodosLancamentos();

                return (List<LancamentoDto>)_mapper.Map<IEnumerable<LancamentoDto>>(lancamentos);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível consultar os Lançamentos!");
            }
        }

        public async Task<LancamentoDto> ObterPorId(int id)
        {
            try
            {
                ConsultaLancamento lancamento = await _lancamentoRepository.BuscarPorId(id);
                if (lancamento == null)
                {
                    throw new ObjectNotFound($"Lançamento não encontrado para o ID: {id}");
                }
                else
                {
                    return _mapper.Map<LancamentoDto>(lancamento);
                }
            }
            catch (ObjectNotFound ex)
            {
                throw new ObjectNotFound(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível consultar o Lançamento para o ID: {id}!");
            }
        }

        public async Task<LancamentoDto> Cadastrar(LancamentoForm lancamentoForm)
        {
            try
            {
                LancamentoModel lancamentoCadastrado = _mapper.Map<LancamentoModel>(lancamentoForm);
                lancamentoCadastrado.DataCadastro = DateTime.Now;

                lancamentoCadastrado = await _lancamentoRepository.AdicionarLancamento(lancamentoCadastrado);
                return _mapper.Map<LancamentoDto>(lancamentoCadastrado);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível cadastrar o Lançamento desejado!");
            }
        }

        public async Task<LancamentoDto> Atualizar(LancamentoForm lancamentoForm, int id)
        {
            try
            {
                LancamentoModel lancamentoExistente = await _lancamentoRepository.BuscarModelPorId(id);
                if (lancamentoExistente == null)
                {
                    throw new ObjectNotFound($"Lançamento não encontrado para o ID: {id}");
                }
                else
                {
                    LancamentoModel lancamentoAtualizado = lancamentoExistente;
                    lancamentoAtualizado.LancamentoValido = (bool)lancamentoForm.lancamentoValido;
                    lancamentoAtualizado.NumeroLancamento = lancamentoForm.numeroLancamento;
                    lancamentoAtualizado.Descricao = lancamentoForm.descricao;
                    lancamentoAtualizado.DataLancamento = lancamentoForm.dataLancamento;
                    lancamentoAtualizado.LancamentoId = lancamentoForm.idLancamentoPai;
                    lancamentoAtualizado.Valor = (decimal)lancamentoForm.valor;
                    lancamentoAtualizado.TipoLancamentoId = lancamentoForm.idTipoLancamento;
                    lancamentoAtualizado.UnidadeId = lancamentoForm.idUnidade;
                    lancamentoAtualizado.UnidadeOrcamentariaId = lancamentoForm.idUnidadeOrcamentaria;
                    lancamentoAtualizado.ProgramaId = lancamentoForm.idPrograma;
                    lancamentoAtualizado.AcaoId = lancamentoForm.idAcao;
                    lancamentoAtualizado.FonteRecursoId = lancamentoForm.idFonteRecurso;
                    lancamentoAtualizado.TipoLancamentoId = lancamentoForm.idTipoLancamento;
                    lancamentoAtualizado.ModalidadeAplicacaoId = lancamentoForm.idModalidadeAplicacao;
                    lancamentoAtualizado.ElementoDespesaId = lancamentoForm.idElementoDespesa;
                    lancamentoAtualizado.SolicitanteId = lancamentoForm.idSolicitante;
                    lancamentoAtualizado.ObjetivoEstrategicoId = lancamentoForm.idObjetivoEstrategico;
                    lancamentoAtualizado.TipoTransacaoId = lancamentoForm.idTipoTransacao;
                    lancamentoAtualizado.GED = lancamentoForm.ged;
                    lancamentoAtualizado.Contratado = lancamentoForm.contratado;
                    lancamentoAtualizado.AnoOrcamento = lancamentoForm.anoOrcamento;
                    lancamentoAtualizado.DataAlteracao = DateTime.Now;
                    lancamentoAtualizado = await _lancamentoRepository.AtualizarLancamento(lancamentoAtualizado);

                    ConsultaLancamento lancamentoAtualizadoConsulta = await _lancamentoRepository.BuscarPorId(lancamentoAtualizado.Id);
                    return _mapper.Map<LancamentoDto>(lancamentoAtualizadoConsulta);
                }
            }
            catch (ObjectNotFound ex)
            {
                throw new ObjectNotFound(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar o Lançamento desejado!");
            }
        }

        public async Task Apagar(int id)
        {
            try
            {
                LancamentoModel lancamentoExistente = await _lancamentoRepository.BuscarModelPorId(id);
                if (lancamentoExistente == null)
                {
                    throw new ObjectNotFound($"Lançamento não encontrado para o ID: {id}");
                }
                else
                {
                    await _lancamentoRepository.ApagarLancamento(lancamentoExistente);
                }
            }
            catch (ObjectNotFound ex)
            {
                throw new ObjectNotFound(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível apagar o Lançamento desejado!");
            }
        }
    }
}
