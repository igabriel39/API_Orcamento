using API_Orcamento.Rest.Dto;
using API_Orcamento.Rest.Form;
using API_Orcamento.Service;
using Microsoft.AspNetCore.Mvc;

namespace API_Orcamento.Rest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProgramaController : ControllerBase
    {
        // Injeção de dependência com a camada de serviço
        private readonly ProgramaService _programaService;
        public ProgramaController(ProgramaService programaService)
        {
            _programaService = programaService;
        }

        /// <summary>
        /// Lista todos os Programas
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Retorna os Programas cadastrados</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpGet]
        public async Task<ActionResult<List<ProgramaDto>>> BuscarTodos()
        {
            List<ProgramaDto> programaDtos = await _programaService.ObterTodos();
            return Ok(programaDtos);
        }

        /// <summary>
        /// Lista o Programa pelo id informado
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Retorna o Programa</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpGet("{id}")]
        public async Task<ActionResult<ProgramaDto>> BuscarPorId(int id)
        {
            ProgramaDto programaDto = await _programaService.ObterPorId(id);
            return Ok(programaDto);
        }

        /// <summary>
        /// Cadastra o Programa
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Programa cadastrado com sucesso</response>>
        /// <response code = "400">Requisição enviada inválida</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpPost]
        public async Task<ActionResult<ProgramaDto>> Cadastrar([FromBody] ProgramaForm programaForm)
        {
            ProgramaDto programaCadastrado = await _programaService.Cadastrar(programaForm);
            return Ok(programaCadastrado);
        }

        /// <summary>
        /// Atualiza o Programa pelo id informado
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Programa atualizado com sucesso</response>>
        /// <response code = "400">Requisição enviada inválida</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpPut("{id}")]
        public async Task<ActionResult<ProgramaDto>> Atualizar([FromBody] ProgramaForm programaForm, int id)
        {
            ProgramaDto programaAtualizado = await _programaService.Atualizar(programaForm, id);
            return Ok(programaAtualizado);
        }

        /// <summary>
        /// Apaga o Programa pelo id informado
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Programa apagado com sucesso</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Apagar(int id)
        {
            await _programaService.Apagar(id);
            return Ok();
        }
    }
}
