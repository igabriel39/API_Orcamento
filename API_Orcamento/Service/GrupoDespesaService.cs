using API_Orcamento.Models;
using API_Orcamento.Repository.Interfaces;
using API_Orcamento.Rest.Dto;
using API_Orcamento.Rest.Form;
using API_Orcamento.Service.Exceptions;
using AutoMapper;

namespace API_Orcamento.Service
{
    public class GrupoDespesaService
    {
        // Injeção de dependência com a camada de repositório para persistir ou consultar as informações no banco
        // Injeção de dependência com o AutoMapper para fazer o mapeamento de Model para Dto
        private readonly IGrupoDespesaRepository _grupoDespesaRepository;
        private readonly IMapper _mapper;
        public GrupoDespesaService(IGrupoDespesaRepository grupoDespesaRepository, IMapper mapper)
        {
            _grupoDespesaRepository = grupoDespesaRepository;
            _mapper = mapper;
        }

        public async Task<List<GrupoDespesaDto>> ObterTodos()
        {
            try
            {
                List<GrupoDespesaModel> grupoDespesaModels = await _grupoDespesaRepository.BuscarTodosGruposDespesas();

                return (List<GrupoDespesaDto>)_mapper.Map<IEnumerable<GrupoDespesaDto>>(grupoDespesaModels);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível consultar os Grupos Despesas!");
            }
        }

        public async Task<GrupoDespesaDto> ObterPorId(int id)
        {
            try
            {
                GrupoDespesaModel grupoDespesaModel = await _grupoDespesaRepository.BuscarPorId(id);
                if (grupoDespesaModel == null)
                {
                    throw new ObjectNotFound($"Grupo Despesa não encontrado para o ID: {id}");
                }
                else
                {
                    return _mapper.Map<GrupoDespesaDto>(grupoDespesaModel);
                }
            }
            catch (ObjectNotFound ex)
            {
                throw new ObjectNotFound(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível consultar o Grupo Despesa para o ID: {id}!");
            }
        }

        public async Task<GrupoDespesaDto> Cadastrar(GrupoDespesaForm grupoDespesaForm)
        {
            try
            {
                GrupoDespesaModel grupoDespesaCadastrado = _mapper.Map<GrupoDespesaModel>(grupoDespesaForm);
                grupoDespesaCadastrado.DtCadastro = DateTime.Now;

                grupoDespesaCadastrado = await _grupoDespesaRepository.AdicionarGrupoDespesa(grupoDespesaCadastrado);
                return _mapper.Map<GrupoDespesaDto>(grupoDespesaCadastrado);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível cadastrar o Grupo Despesa desejado!");
            }
        }

        public async Task<GrupoDespesaDto> Atualizar(GrupoDespesaForm grupoDespesaForm, int id)
        {
            try
            {
                GrupoDespesaModel grupoDespesaExistente = await _grupoDespesaRepository.BuscarPorId(id);
                if (grupoDespesaExistente == null)
                {
                    throw new ObjectNotFound($"Grupo Despesa não encontrado para o ID: {id}");
                }
                else
                {
                    GrupoDespesaModel grupoDespesaAtualizado = grupoDespesaExistente;
                    grupoDespesaAtualizado.Codigo = grupoDespesaForm.codigo;
                    grupoDespesaAtualizado.Nome = grupoDespesaForm.nome;
                    grupoDespesaAtualizado.DtUltimaAlteracao = DateTime.Now;
                    grupoDespesaAtualizado = await _grupoDespesaRepository.AtualizarGrupoDespesa(grupoDespesaAtualizado);
                    return _mapper.Map<GrupoDespesaDto>(grupoDespesaAtualizado);
                }
            }
            catch (ObjectNotFound ex)
            {
                throw new ObjectNotFound(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar o Grupo Despesa desejado!");
            }
        }

        public async Task Apagar(int id)
        {
            try
            {
                GrupoDespesaModel grupoDespesaExistente = await _grupoDespesaRepository.BuscarPorId(id);
                if (grupoDespesaExistente == null)
                {
                    throw new ObjectNotFound($"Grupo Despesa não encontrado para o ID: {id}");
                }
                else
                {
                    await _grupoDespesaRepository.ApagarGrupoDespesa(grupoDespesaExistente);
                }
            }
            catch (ObjectNotFound ex)
            {
                throw new ObjectNotFound(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível apagar o Grupo Despesa desejado!");
            }
        }
    }
}
