using API_Orcamento.Models;
using API_Orcamento.Repository.Interfaces;
using API_Orcamento.Rest.Dto;
using API_Orcamento.Rest.Form;
using API_Orcamento.Service.Exceptions;
using AutoMapper;

namespace API_Orcamento.Service
{
    public class OrgaoService
    {
        // Injeção de dependência com a camada de repositório para persistir ou consultar as informações no banco
        // Injeção de dependência com o AutoMapper para fazer o mapeamento de Model para Dto
        private readonly IOrgaoRepository _orgaoRepository;
        private readonly IMapper _mapper;
        public OrgaoService(IOrgaoRepository orgaoRepository, IMapper mapper)
        {
            _orgaoRepository = orgaoRepository;
            _mapper = mapper;
        }

        public async Task<List<OrgaoDto>> ObterTodos()
        {
            try
            {
                List<OrgaoModel> orgaoModels = await _orgaoRepository.BuscarTodosOrgaos();

                return (List<OrgaoDto>)_mapper.Map<IEnumerable<OrgaoDto>>(orgaoModels);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível consultar os Órgãos!");
            }
        }

        public async Task<OrgaoDto> ObterPorId(int id)
        {
            try
            {
                OrgaoModel orgaoModel = await _orgaoRepository.BuscarPorId(id);
                if (orgaoModel == null)
                {
                    throw new ObjectNotFound($"Órgão  não encontrado para o ID: {id}");
                }
                else
                {
                    return _mapper.Map<OrgaoDto>(orgaoModel);
                }
            }
            catch (ObjectNotFound ex)
            {
                throw new ObjectNotFound(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível consultar o Órgão para o ID: {id}!");
            }
        }

        public async Task<OrgaoDto> Cadastrar(OrgaoForm orgaoForm)
        {
            try
            {
                OrgaoModel orgaooCadastrado = _mapper.Map<OrgaoModel>(orgaoForm);
                orgaooCadastrado.DtCadastro = DateTime.Now;

                orgaooCadastrado = await _orgaoRepository.AdicionarOrgao(orgaooCadastrado);
                return _mapper.Map<OrgaoDto>(orgaooCadastrado);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível cadastrar o Órgão desejado!");
            }
        }

        public async Task<OrgaoDto> Atualizar(OrgaoForm orgaoForm, int id)
        {
            try
            {
                OrgaoModel orgaoExistente = await _orgaoRepository.BuscarPorId(id);
                if (orgaoExistente == null)
                {
                    throw new ObjectNotFound($"Órgão não encontrado para o ID: {id}");
                }
                else
                {
                    OrgaoModel orgaoAtualizado = orgaoExistente;
                    orgaoAtualizado.Nome = orgaoForm.nome;
                    orgaoAtualizado.DtUltimaAlteracao = DateTime.Now;
                    orgaoAtualizado = await _orgaoRepository.AtualizarOrgao(orgaoAtualizado);
                    return _mapper.Map<OrgaoDto>(orgaoAtualizado);
                }
            }
            catch (ObjectNotFound ex)
            {
                throw new ObjectNotFound(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar o Órgão desejado!");
            }
        }

        public async Task Apagar(int id)
        {
            try
            {
                OrgaoModel orgaoExistente = await _orgaoRepository.BuscarPorId(id);
                if (orgaoExistente == null)
                {
                    throw new ObjectNotFound($"Órgão não encontrado para o ID: {id}");
                }
                else
                {
                    await _orgaoRepository.ApagarOrgao(orgaoExistente);
                }
            }
            catch (ObjectNotFound ex)
            {
                throw new ObjectNotFound(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível apagar o Órgão desejado!");
            }
        }
    }
}
