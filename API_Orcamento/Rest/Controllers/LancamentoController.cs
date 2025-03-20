using API_Orcamento.Rest.Dto;
using API_Orcamento.Rest.Form;
using API_Orcamento.Service;
using Microsoft.AspNetCore.Mvc;

namespace API_Orcamento.Rest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LancamentoController : ControllerBase
    {
        // Injeção de dependência com a camada de serviço
        private readonly LancamentoService _lancamentoService;
        public LancamentoController(LancamentoService lancamentoService)
        {
            _lancamentoService = lancamentoService;
        }

        /// <summary>
        /// Lista todas os Lançamentos
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Retorna os Lançamentos cadastrados</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpGet]
        public async Task<ActionResult<List<LancamentoDto>>> BuscarTodos()
        {
            List<LancamentoDto> lancamentoDtos = await _lancamentoService.ObterTodos();
            return Ok(lancamentoDtos);
        }

        /// <summary>
        /// Lista o Lançamento pelo id informado
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Retorna o Lançamento</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpGet("{id}")]
        public async Task<ActionResult<LancamentoDto>> BuscarPorId(int id)
        {
            LancamentoDto lancamentoDto = await _lancamentoService.ObterPorId(id);
            return Ok(lancamentoDto);
        }

        /// <summary>
        /// Cadastra o Lançamento
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Lançamento cadastrado com sucesso</response>>
        /// <response code = "400">Requisição enviada inválida</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpPost]
        public async Task<ActionResult<LancamentoDto>> Cadastrar([FromBody] LancamentoForm lancamentoForm)
        {
            LancamentoDto lancamentoCadastrado = await _lancamentoService.Cadastrar(lancamentoForm);
            return Ok(lancamentoCadastrado);
        }

        /// <summary>
        /// Atualiza o Lançamento pelo id informado
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Lançamento atualizado com sucesso</response>>
        /// <response code = "400">Requisição enviada inválida</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpPut("{id}")]
        public async Task<ActionResult<LancamentoDto>> Atualizar([FromBody] LancamentoForm lancamentoForm, int id)
        {
            LancamentoDto lancamentoAtualizado = await _lancamentoService.Atualizar(lancamentoForm, id);
            return Ok(lancamentoAtualizado);
        }

        /// <summary>
        /// Apaga o Lançamento pelo id informado
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Lançamento apagado com sucesso</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Apagar(int id)
        {
            await _lancamentoService.Apagar(id);
            return Ok();
        }
    }
}
