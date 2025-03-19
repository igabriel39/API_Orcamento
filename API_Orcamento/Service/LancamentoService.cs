using API_Orcamento.Models;
using API_Orcamento.Repository;
using API_Orcamento.Repository.Interfaces;
using API_Orcamento.Rest.Dto;
using API_Orcamento.Rest.Form;
using API_Orcamento.Service.Exceptions;
using AutoMapper;

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
                List<ConsultaLancamento> consultaLancamentos = await _lancamentoRepository.BuscarTodosLancamentos();

                return (List<LancamentoDto>)_mapper.Map<IEnumerable<LancamentoDto>>(consultaLancamentos);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível consultar os Lançamentos!");
            }
        }

        //public async Task<AcaoDto> ObterPorId(int id)
        //{
        //    try
        //    {
        //        AcaoModel acaoModel = await _acaoRepository.BuscarPorId(id);
        //        if (acaoModel == null)
        //        {
        //            throw new ObjectNotFound($"Ação não encontrada para o ID: {id}");
        //        }
        //        else
        //        {
        //            return _mapper.Map<AcaoDto>(acaoModel);
        //        }
        //    }
        //    catch (ObjectNotFound ex)
        //    {
        //        throw new ObjectNotFound(ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"Não foi possível consultar a Ação para o ID: {id}!");
        //    }
        //}

        //public async Task<AcaoDto> Cadastrar(AcaoForm acaoForm)
        //{
        //    try
        //    {
        //        AcaoModel acaoCadastrada = _mapper.Map<AcaoModel>(acaoForm);
        //        acaoCadastrada.DtCadastro = DateTime.Now;

        //        acaoCadastrada = await _acaoRepository.AdicionarAcao(acaoCadastrada);
        //        return _mapper.Map<AcaoDto>(acaoCadastrada);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Não foi possível cadastrar a Ação desejada!");
        //    }
        //}

        //public async Task<AcaoDto> Atualizar(AcaoForm acaoForm, int id)
        //{
        //    try
        //    {
        //        AcaoModel acaoExistente = await _acaoRepository.BuscarPorId(id);
        //        if (acaoExistente == null)
        //        {
        //            throw new ObjectNotFound($"Ação não encontrada para o ID: {id}");
        //        }
        //        else
        //        {
        //            AcaoModel acaoAtualizada = acaoExistente;
        //            acaoAtualizada.Codigo = acaoForm.codigo;
        //            acaoAtualizada.Nome = acaoForm.nome;
        //            acaoAtualizada.DtUltimaAlteracao = DateTime.Now;
        //            acaoAtualizada = await _acaoRepository.AtualizarAcao(acaoAtualizada);
        //            return _mapper.Map<AcaoDto>(acaoAtualizada);
        //        }
        //    }
        //    catch (ObjectNotFound ex)
        //    {
        //        throw new ObjectNotFound(ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Não foi possível atualizar a Ação desejada!");
        //    }
        //}

        //public async Task Apagar(int id)
        //{
        //    try
        //    {
        //        AcaoModel acaoExistente = await _acaoRepository.BuscarPorId(id);
        //        if (acaoExistente == null)
        //        {
        //            throw new ObjectNotFound($"Ação não encontrada para o ID: {id}");
        //        }
        //        else
        //        {
        //            await _acaoRepository.ApagarAcao(acaoExistente);
        //        }
        //    }
        //    catch (ObjectNotFound ex)
        //    {
        //        throw new ObjectNotFound(ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Não foi possível apagar a Ação desejada!");
        //    }
        //}
    }
}
