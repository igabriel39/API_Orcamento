using API_Orcamento.Rest.Dto;
using API_Orcamento.Rest.Form;
using API_Orcamento.Service;
using Microsoft.AspNetCore.Mvc;

namespace API_Orcamento.Rest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SolicitanteController : ControllerBase
    {
        // Injeção de dependência com a camada de serviço
        private readonly SolicitanteService _solicitanteService;
        public SolicitanteController(SolicitanteService solicitanteService)
        {
            _solicitanteService = solicitanteService;
        }

        /// <summary>
        /// Lista todos os Solicitantes
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Retorna os Solicitantes cadastrados</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpGet]
        public async Task<ActionResult<List<SolicitanteDto>>> BuscarTodos()
        {
            List<SolicitanteDto> solicitanteDtos = await _solicitanteService.ObterTodos();
            return Ok(solicitanteDtos);
        }

        /// <summary>
        /// Lista o Solicitante pelo id informado
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Retorna o Solicitante</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpGet("{id}")]
        public async Task<ActionResult<SolicitanteDto>> BuscarPorId(int id)
        {
            SolicitanteDto solicitanteDto = await _solicitanteService.ObterPorId(id);
            return Ok(solicitanteDto);
        }

        /// <summary>
        /// Cadastra o Solicitante
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Solicitante cadastrado com sucesso</response>>
        /// <response code = "400">Requisição enviada inválida</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpPost]
        public async Task<ActionResult<SolicitanteDto>> Cadastrar([FromBody] SolicitanteForm solicitanteForm)
        {
            SolicitanteDto solicitanteCadastrado = await _solicitanteService.Cadastrar(solicitanteForm);
            return Ok(solicitanteCadastrado);
        }

        /// <summary>
        /// Atualiza o Solicitante pelo id informado
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Solicitante atualizado com sucesso</response>>
        /// <response code = "400">Requisição enviada inválida</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpPut("{id}")]
        public async Task<ActionResult<SolicitanteDto>> Atualizar([FromBody] SolicitanteForm solicitanteForm, int id)
        {
            SolicitanteDto solicitanteAtualizado = await _solicitanteService.Atualizar(solicitanteForm, id);
            return Ok(solicitanteAtualizado);
        }

        /// <summary>
        /// Apaga o Solicitante pelo id informado
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Solicitante apagado com sucesso</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Apagar(int id)
        {
            await _solicitanteService.Apagar(id);
            return Ok();
        }
    }
}
