using API_Orcamento.Models;
using API_Orcamento.Repository.Interfaces;
using API_Orcamento.Rest.Dto;
using API_Orcamento.Rest.Form;
using API_Orcamento.Service.Exceptions;
using AutoMapper;

namespace API_Orcamento.Service
{
    public class ModalidadeAplicacaoService
    {
        // Injeção de dependência com a camada de repositório para persistir ou consultar as informações no banco
        // Injeção de dependência com o AutoMapper para fazer o mapeamento de Model para Dto
        private readonly IModalidadeAplicacaoRepository _modalidadeAplicacaoRepository;
        private readonly IMapper _mapper;
        public ModalidadeAplicacaoService(IModalidadeAplicacaoRepository modalidadeAplicacaoRepository, IMapper mapper)
        {
            _modalidadeAplicacaoRepository = modalidadeAplicacaoRepository;
            _mapper = mapper;
        }

        public async Task<List<ModalidadeAplicacaoDto>> ObterTodos()
        {
            try
            {
                List<ModalidadeAplicacaoModel> modalidadeAplicacaoModels = await _modalidadeAplicacaoRepository.BuscarTodasModalidadesAplicacoes();

                return (List<ModalidadeAplicacaoDto>)_mapper.Map<IEnumerable<ModalidadeAplicacaoDto>>(modalidadeAplicacaoModels);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível consultar as Modalidades Aplicações!");
            }
        }

        public async Task<ModalidadeAplicacaoDto> ObterPorId(int id)
        {
            try
            {
                ModalidadeAplicacaoModel modalidadeAplicacaoModel = await _modalidadeAplicacaoRepository.BuscarPorId(id);
                if (modalidadeAplicacaoModel == null)
                {
                    throw new ObjectNotFound($"Modalidade Aplicação não encontrada para o ID: {id}");
                }
                else
                {
                    return _mapper.Map<ModalidadeAplicacaoDto>(modalidadeAplicacaoModel);
                }
            }
            catch (ObjectNotFound ex)
            {
                throw new ObjectNotFound(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível consultar a Modalidade Aplicação para o ID: {id}!");
            }
        }

        public async Task<ModalidadeAplicacaoDto> Cadastrar(ModalidadeAplicacaoForm modalidadeAplicacaoForm)
        {
            try
            {
                ModalidadeAplicacaoModel modalidadeAplicacaoCadastrada = _mapper.Map<ModalidadeAplicacaoModel>(modalidadeAplicacaoForm);
                modalidadeAplicacaoCadastrada.DtCadastro = DateTime.Now;

                modalidadeAplicacaoCadastrada = await _modalidadeAplicacaoRepository.AdicionarModalidadeAplicacao(modalidadeAplicacaoCadastrada);
                return _mapper.Map<ModalidadeAplicacaoDto>(modalidadeAplicacaoCadastrada);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível cadastrar a Modalidade Aplicação desejada!");
            }
        }

        public async Task<ModalidadeAplicacaoDto> Atualizar(ModalidadeAplicacaoForm modalidadeAplicacaoForm, int id)
        {
            try
            {
                ModalidadeAplicacaoModel modalidadeAplicacaoExistente = await _modalidadeAplicacaoRepository.BuscarPorId(id);
                if (modalidadeAplicacaoExistente == null)
                {
                    throw new ObjectNotFound($"Modalidade Aplicação não encontrada para o ID: {id}");
                }
                else
                {
                    ModalidadeAplicacaoModel modalidadeAplicacaoAtualizada = modalidadeAplicacaoExistente;
                    modalidadeAplicacaoAtualizada.Codigo = modalidadeAplicacaoForm.codigo;
                    modalidadeAplicacaoAtualizada.Nome = modalidadeAplicacaoForm.nome;
                    modalidadeAplicacaoAtualizada.DtUltimaAlteracao = DateTime.Now;
                    modalidadeAplicacaoAtualizada = await _modalidadeAplicacaoRepository.AtualizarModalidadeAplicacao(modalidadeAplicacaoAtualizada);
                    return _mapper.Map<ModalidadeAplicacaoDto>(modalidadeAplicacaoAtualizada);
                }
            }
            catch (ObjectNotFound ex)
            {
                throw new ObjectNotFound(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar a Modalidade Aplicação desejada!");
            }
        }

        public async Task Apagar(int id)
        {
            try
            {
                ModalidadeAplicacaoModel modalidadeAplicacaoExistente = await _modalidadeAplicacaoRepository.BuscarPorId(id);
                if (modalidadeAplicacaoExistente == null)
                {
                    throw new ObjectNotFound($"Modalidade Aplicação não encontrada para o ID: {id}");
                }
                else
                {
                    await _modalidadeAplicacaoRepository.ApagarModalidadeAplicacao(modalidadeAplicacaoExistente);
                }
            }
            catch (ObjectNotFound ex)
            {
                throw new ObjectNotFound(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível apagar a Modalidade Aplicação desejada!");
            }
        }
    }
}
