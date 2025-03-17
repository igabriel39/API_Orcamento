using API_Orcamento.Rest.Dto;
using API_Orcamento.Rest.Form;
using API_Orcamento.Service;
using Microsoft.AspNetCore.Mvc;

namespace API_Orcamento.Rest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoTransacaoController : ControllerBase
    {
        // Injeção de dependência com a camada de serviço
        private readonly TipoTransacaoService _tipoTransacaoService;
        public TipoTransacaoController(TipoTransacaoService tipoTransacaoService)
        {
            _tipoTransacaoService = tipoTransacaoService;
        }

        /// <summary>
        /// Lista todos os Tipos Transações
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Retorna os Tipos Transações cadastrados</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpGet]
        public async Task<ActionResult<List<TipoTransacaoDto>>> BuscarTodos()
        {
            List<TipoTransacaoDto> tipoTransacaoDtos = await _tipoTransacaoService.ObterTodos();
            return Ok(tipoTransacaoDtos);
        }

        /// <summary>
        /// Lista o Tipo Transação pelo id informado
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Retorna o Tipo Transação</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoTransacaoDto>> BuscarPorId(int id)
        {
            TipoTransacaoDto tipoTransacaoDto = await _tipoTransacaoService.ObterPorId(id);
            return Ok(tipoTransacaoDto);
        }

        /// <summary>
        /// Cadastra o Tipo Transação
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Tipo Transação cadastrado com sucesso</response>>
        /// <response code = "400">Requisição enviada inválida</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpPost]
        public async Task<ActionResult<TipoTransacaoDto>> Cadastrar([FromBody] TipoTransacaoForm tipoTransacaoForm)
        {
            TipoTransacaoDto tipoTransacaoCadastrado = await _tipoTransacaoService.Cadastrar(tipoTransacaoForm);
            return Ok(tipoTransacaoCadastrado);
        }

        /// <summary>
        /// Atualiza o Tipo Transação pelo id informado
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Tipo Transação atualizado com sucesso</response>>
        /// <response code = "400">Requisição enviada inválida</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpPut("{id}")]
        public async Task<ActionResult<TipoTransacaoDto>> Atualizar([FromBody] TipoTransacaoForm tipoTransacaoForm, int id)
        {
            TipoTransacaoDto tipoTransacaoAtualizado = await _tipoTransacaoService.Atualizar(tipoTransacaoForm, id);
            return Ok(tipoTransacaoAtualizado);
        }

        /// <summary>
        /// Apaga o Tipo Transação pelo id informado
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Tipo Transação apagado com sucesso</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Apagar(int id)
        {
            await _tipoTransacaoService.Apagar(id);
            return Ok();
        }
    }
}
