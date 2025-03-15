using API_Orcamento.Models;
using API_Orcamento.Repository.Interfaces;
using API_Orcamento.Rest.Dto;
using API_Orcamento.Rest.Form;
using API_Orcamento.Service.Exceptions;
using AutoMapper;

namespace API_Orcamento.Service
{
    public class ObjetivoEstrategicoService
    {
        // Injeção de dependência com a camada de repositório para persistir ou consultar as informações no banco
        // Injeção de dependência com o AutoMapper para fazer o mapeamento de Model para Dto
        private readonly IObjetivoEstrategicoRepository _objetivoEstrategicoRepository;
        private readonly IMapper _mapper;
        public ObjetivoEstrategicoService(IObjetivoEstrategicoRepository objetivoEstrategicoRepository, IMapper mapper)
        {
            _objetivoEstrategicoRepository = objetivoEstrategicoRepository;
            _mapper = mapper;
        }

        public async Task<List<ObjetivoEstrategicoDto>> ObterTodos()
        {
            try
            {
                List<ObjetivoEstrategicoModel> objetivoEstrategicoModels = await _objetivoEstrategicoRepository.BuscarTodosObjetivosEstrategicos();

                return (List<ObjetivoEstrategicoDto>)_mapper.Map<IEnumerable<ObjetivoEstrategicoDto>>(objetivoEstrategicoModels);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível consultar os Objetivos Estratégicos!");
            }
        }

        public async Task<ObjetivoEstrategicoDto> ObterPorId(int id)
        {
            try
            {
                ObjetivoEstrategicoModel objetivoEstrategicoModel = await _objetivoEstrategicoRepository.BuscarPorId(id);
                if (objetivoEstrategicoModel == null)
                {
                    throw new ObjectNotFound($"Objetivo Estratégico não encontrado para o ID: {id}");
                }
                else
                {
                    return _mapper.Map<ObjetivoEstrategicoDto>(objetivoEstrategicoModel);
                }
            }
            catch (ObjectNotFound ex)
            {
                throw new ObjectNotFound(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível consultar o Objetivo Estratégico para o ID: {id}!");
            }
        }

        public async Task<ObjetivoEstrategicoDto> Cadastrar(ObjetivoEstrategicoForm objetivoEstrategicoForm)
        {
            try
            {
                ObjetivoEstrategicoModel objetivoEstrategicoCadastrado = _mapper.Map<ObjetivoEstrategicoModel>(objetivoEstrategicoForm);
                objetivoEstrategicoCadastrado.DtCadastro = DateTime.Now;

                objetivoEstrategicoCadastrado = await _objetivoEstrategicoRepository.AdicionarObjetivoEstrategico(objetivoEstrategicoCadastrado);
                return _mapper.Map<ObjetivoEstrategicoDto>(objetivoEstrategicoCadastrado);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível cadastrar o Objetivo Estratégico desejado!");
            }
        }

        public async Task<ObjetivoEstrategicoDto> Atualizar(ObjetivoEstrategicoForm objetivoEstrategicoForm, int id)
        {
            try
            {
                ObjetivoEstrategicoModel objetivoEstrategicoExistente = await _objetivoEstrategicoRepository.BuscarPorId(id);
                if (objetivoEstrategicoExistente == null)
                {
                    throw new ObjectNotFound($"Objetivo Estratégico não encontrado para o ID: {id}");
                }
                else
                {
                    ObjetivoEstrategicoModel objetivoEstrategicoAtualizado = objetivoEstrategicoExistente;
                    objetivoEstrategicoAtualizado.Nome = objetivoEstrategicoForm.nome;
                    objetivoEstrategicoAtualizado.DtUltimaAlteracao = DateTime.Now;
                    objetivoEstrategicoAtualizado = await _objetivoEstrategicoRepository.AtualizarObjetivoEstrategico(objetivoEstrategicoAtualizado);
                    return _mapper.Map<ObjetivoEstrategicoDto>(objetivoEstrategicoAtualizado);
                }
            }
            catch (ObjectNotFound ex)
            {
                throw new ObjectNotFound(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar o Objetivo Estratégico desejado!");
            }
        }

        public async Task Apagar(int id)
        {
            try
            {
                ObjetivoEstrategicoModel objetivoEstrategicoExistente = await _objetivoEstrategicoRepository.BuscarPorId(id);
                if (objetivoEstrategicoExistente == null)
                {
                    throw new ObjectNotFound($"Objetivo Estratégico não encontrado para o ID: {id}");
                }
                else
                {
                    await _objetivoEstrategicoRepository.ApagarObjetivoEstrategico(objetivoEstrategicoExistente);
                }
            }
            catch (ObjectNotFound ex)
            {
                throw new ObjectNotFound(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível apagar o Objetivo Estratégico desejado!");
            }
        }
    }
}
