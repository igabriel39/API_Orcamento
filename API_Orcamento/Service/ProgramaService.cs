using API_Orcamento.Models;
using API_Orcamento.Repository.Interfaces;
using API_Orcamento.Rest.Dto;
using API_Orcamento.Rest.Form;
using API_Orcamento.Service.Exceptions;
using AutoMapper;

namespace API_Orcamento.Service
{
    public class ProgramaService
    {
        // Injeção de dependência com a camada de repositório para persistir ou consultar as informações no banco
        // Injeção de dependência com o AutoMapper para fazer o mapeamento de Model para Dto
        private readonly IProgramaRepository _programaRepository;
        private readonly IMapper _mapper;
        public ProgramaService(IProgramaRepository programaRepository, IMapper mapper)
        {
            _programaRepository = programaRepository;
            _mapper = mapper;
        }

        public async Task<List<ProgramaDto>> ObterTodos()
        {
            try
            {
                List<ProgramaModel> programaModels = await _programaRepository.BuscarTodosProgramas();

                return (List<ProgramaDto>)_mapper.Map<IEnumerable<ProgramaDto>>(programaModels);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível consultar os Programas!");
            }
        }

        public async Task<ProgramaDto> ObterPorId(int id)
        {
            try
            {
                ProgramaModel programaModel = await _programaRepository.BuscarPorId(id);
                if (programaModel == null)
                {
                    throw new ObjectNotFound($"Programa não encontrado para o ID: {id}");
                }
                else
                {
                    return _mapper.Map<ProgramaDto>(programaModel);
                }
            }
            catch (ObjectNotFound ex)
            {
                throw new ObjectNotFound(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível consultar o Programa para o ID: {id}!");
            }
        }

        public async Task<ProgramaDto> Cadastrar(ProgramaForm programaForm)
        {
            try
            {
                ProgramaModel programaCadastrado = _mapper.Map<ProgramaModel>(programaForm);
                programaCadastrado.DtCadastro = DateTime.Now;

                programaCadastrado = await _programaRepository.AdicionarPrograma(programaCadastrado);
                return _mapper.Map<ProgramaDto>(programaCadastrado);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível cadastrar o Programa desejado!");
            }
        }

        public async Task<ProgramaDto> Atualizar(ProgramaForm programaForm, int id)
        {
            try
            {
                ProgramaModel programaExistente = await _programaRepository.BuscarPorId(id);
                if (programaExistente == null)
                {
                    throw new ObjectNotFound($"Programa não encontrado para o ID: {id}");
                }
                else
                {
                    ProgramaModel programaAtualizado = programaExistente;
                    programaAtualizado.Codigo = programaForm.codigo;
                    programaAtualizado.Nome = programaForm.nome;
                    programaAtualizado.DtUltimaAlteracao = DateTime.Now;
                    programaAtualizado = await _programaRepository.AtualizarPrograma(programaAtualizado);
                    return _mapper.Map<ProgramaDto>(programaAtualizado);
                }
            }
            catch (ObjectNotFound ex)
            {
                throw new ObjectNotFound(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar o Programa desejado!");
            }
        }

        public async Task Apagar(int id)
        {
            try
            {
                ProgramaModel programaExistente = await _programaRepository.BuscarPorId(id);
                if (programaExistente == null)
                {
                    throw new ObjectNotFound($"Programa não encontrado para o ID: {id}");
                }
                else
                {
                    await _programaRepository.ApagarPrograma(programaExistente);
                }
            }
            catch (ObjectNotFound ex)
            {
                throw new ObjectNotFound(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível apagar o Programa desejado!");
            }
        }
    }
}
