using API_Orcamento.Models;
using API_Orcamento.Repository.Interfaces;
using API_Orcamento.Rest.Dto;
using API_Orcamento.Rest.Form;
using API_Orcamento.Service.Exceptions;
using AutoMapper;

namespace API_Orcamento.Service
{
    public class SolicitanteService
    {
        // Injeção de dependência com a camada de repositório para persistir ou consultar as informações no banco
        // Injeção de dependência com o AutoMapper para fazer o mapeamento de Model para Dto
        private readonly ISolicitanteRepository _solicitanteRepository;
        private readonly IMapper _mapper;
        public SolicitanteService(ISolicitanteRepository solicitanteRepository, IMapper mapper)
        {
            _solicitanteRepository = solicitanteRepository;
            _mapper = mapper;
        }

        public async Task<List<SolicitanteDto>> ObterTodos()
        {
            try
            {
                List<SolicitanteModel> solicitanteModels = await _solicitanteRepository.BuscarTodosSolicitantes();

                return (List<SolicitanteDto>)_mapper.Map<IEnumerable<SolicitanteDto>>(solicitanteModels);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível consultar os Solicitantes!");
            }
        }

        public async Task<SolicitanteDto> ObterPorId(int id)
        {
            try
            {
                SolicitanteModel solicitanteModel = await _solicitanteRepository.BuscarPorId(id);
                if (solicitanteModel == null)
                {
                    throw new ObjectNotFound($"Solicitante não encontrado para o ID: {id}");
                }
                else
                {
                    return _mapper.Map<SolicitanteDto>(solicitanteModel);
                }
            }
            catch (ObjectNotFound ex)
            {
                throw new ObjectNotFound(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível consultar o Solicitante para o ID: {id}!");
            }
        }

        public async Task<SolicitanteDto> Cadastrar(SolicitanteForm solicitanteForm)
        {
            try
            {
                SolicitanteModel solicitanteCadastrado = _mapper.Map<SolicitanteModel>(solicitanteForm);
                solicitanteCadastrado.DtCadastro = DateTime.Now;

                solicitanteCadastrado = await _solicitanteRepository.AdicionarSolicitante(solicitanteCadastrado);
                return _mapper.Map<SolicitanteDto>(solicitanteCadastrado);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível cadastrar o Solicitante desejado!");
            }
        }

        public async Task<SolicitanteDto> Atualizar(SolicitanteForm solicitanteForm, int id)
        {
            try
            {
                SolicitanteModel solicitanteExistente = await _solicitanteRepository.BuscarPorId(id);
                if (solicitanteExistente == null)
                {
                    throw new ObjectNotFound($"Solicitante não encontrado para o ID: {id}");
                }
                else
                {
                    SolicitanteModel solicitanteAtualizado = solicitanteExistente;
                    solicitanteAtualizado.Nome = solicitanteForm.nome;
                    solicitanteAtualizado.DtUltimaAlteracao = DateTime.Now;
                    solicitanteAtualizado = await _solicitanteRepository.AtualizarSolicitante(solicitanteAtualizado);
                    return _mapper.Map<SolicitanteDto>(solicitanteAtualizado);
                }
            }
            catch (ObjectNotFound ex)
            {
                throw new ObjectNotFound(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar o Solicitante desejado!");
            }
        }

        public async Task Apagar(int id)
        {
            try
            {
                SolicitanteModel solicitanteExistente = await _solicitanteRepository.BuscarPorId(id);
                if (solicitanteExistente == null)
                {
                    throw new ObjectNotFound($"Solicitante não encontrado para o ID: {id}");
                }
                else
                {
                    await _solicitanteRepository.ApagarSolicitante(solicitanteExistente);
                }
            }
            catch (ObjectNotFound ex)
            {
                throw new ObjectNotFound(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível apagar o Solicitante desejado!");
            }
        }
    }
}
