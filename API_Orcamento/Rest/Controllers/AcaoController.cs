using API_Orcamento.Rest.Dto;
using API_Orcamento.Rest.Form;
using API_Orcamento.Service;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API_Orcamento.Rest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AcaoController : ControllerBase
    {
        // Injeção de dependência com a camada de serviço
        private readonly AcaoService _acaoService;
        public AcaoController(AcaoService acaoService)
        {
            _acaoService = acaoService;
        }

        /// <summary>
        /// Lista todas as Ações
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Retorna as Ações cadastradas</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpGet]
        public async Task<ActionResult<List<AcaoDto>>> BuscarTodos()
        {
            List<AcaoDto> acaoDtos = await _acaoService.ObterTodos();
            return Ok(acaoDtos);
        }

        /// <summary>
        /// Lista a Ação pelo id informado
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Ação cadastrada com sucesso</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpGet("{id}")]
        public async Task<ActionResult<AcaoDto>> BuscarPorId(int id)
        {
            AcaoDto acaoDto = await _acaoService.ObterPorId(id);
            return Ok(acaoDto);
        }

        /// <summary>
        /// Cadastra a Ação
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Ação cadastrada com sucesso</response>>
        /// <response code = "400">Requisição enviada inválida</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpPost]
        public async Task<ActionResult<AcaoDto>> Cadastrar([FromBody] AcaoForm acaoForm)
        {
            AcaoDto acaoCadastrada = await _acaoService.Cadastrar(acaoForm);
            return Ok(acaoCadastrada);
        }

        /// <summary>
        /// Atualiza a Ação pelo id informado
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Ação atualizada com sucesso</response>>
        /// <response code = "400">Requisição enviada inválida</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpPut("{id}")]
        public async Task<ActionResult<AcaoDto>> Atualizar([FromBody] AcaoForm acaoForm, int id)
        {
            AcaoDto acaoAtualizada = await _acaoService.Atualizar(acaoForm, id);
            return Ok(acaoAtualizada);
        }

        /// <summary>
        /// Apaga a Ação pelo id informado
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Ação apagada com sucesso</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Apagar(int id)
        {
            await _acaoService.Apagar(id);
            return Ok();
        }
    }
}
