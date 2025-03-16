using API_Orcamento.Rest.Dto;
using API_Orcamento.Rest.Form;
using API_Orcamento.Service;
using Microsoft.AspNetCore.Mvc;

namespace API_Orcamento.Rest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoLancamentoController : ControllerBase
    {
        // Injeção de dependência com a camada de serviço
        private readonly TipoLancamentoService _tipoLancamentoService;
        public TipoLancamentoController(TipoLancamentoService tipoLancamentoService)
        {
            _tipoLancamentoService = tipoLancamentoService;
        }

        /// <summary>
        /// Lista todos os Tipos Lançamentos
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Retorna os Tipos Lançamentos cadastrados</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpGet]
        public async Task<ActionResult<List<TipoLancamentoDto>>> BuscarTodos()
        {
            List<TipoLancamentoDto> tipoLancamentoDtos = await _tipoLancamentoService.ObterTodos();
            return Ok(tipoLancamentoDtos);
        }

        /// <summary>
        /// Lista o Tipo Lançamento pelo id informado
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Retorna o Tipo Lançamento</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoLancamentoDto>> BuscarPorId(int id)
        {
            TipoLancamentoDto tipoLancamentoDto = await _tipoLancamentoService.ObterPorId(id);
            return Ok(tipoLancamentoDto);
        }

        /// <summary>
        /// Cadastra o Tipo Lançamento
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Tipo Lançamento cadastrado com sucesso</response>>
        /// <response code = "400">Requisição enviada inválida</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpPost]
        public async Task<ActionResult<TipoLancamentoDto>> Cadastrar([FromBody] TipoLancamentoForm tipoLancamentoForm)
        {
            TipoLancamentoDto tipoLancamentoCadastrado = await _tipoLancamentoService.Cadastrar(tipoLancamentoForm);
            return Ok(tipoLancamentoCadastrado);
        }

        /// <summary>
        /// Atualiza o Tipo Lançamento pelo id informado
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Tipo Lançamento atualizado com sucesso</response>>
        /// <response code = "400">Requisição enviada inválida</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpPut("{id}")]
        public async Task<ActionResult<TipoLancamentoDto>> Atualizar([FromBody] TipoLancamentoForm tipoLancamentoForm, int id)
        {
            TipoLancamentoDto tipoLancamentoAtualizado = await _tipoLancamentoService.Atualizar(tipoLancamentoForm, id);
            return Ok(tipoLancamentoAtualizado);
        }

        /// <summary>
        /// Apaga o Tipo Lançamento pelo id informado
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Ação apagada com sucesso</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Apagar(int id)
        {
            await _tipoLancamentoService.Apagar(id);
            return Ok();
        }
    }
}
