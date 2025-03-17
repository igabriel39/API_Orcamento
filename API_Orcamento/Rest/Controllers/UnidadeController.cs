using API_Orcamento.Rest.Dto;
using API_Orcamento.Rest.Form;
using API_Orcamento.Service;
using Microsoft.AspNetCore.Mvc;

namespace API_Orcamento.Rest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnidadeController : ControllerBase
    {
        // Injeção de dependência com a camada de serviço
        private readonly UnidadeService _unidadeService;
        public UnidadeController(UnidadeService unidadeService)
        {
            _unidadeService = unidadeService;
        }

        /// <summary>
        /// Lista todas as Unidades
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Retorna as Unidades cadastradas</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpGet]
        public async Task<ActionResult<List<UnidadeDto>>> BuscarTodos()
        {
            List<UnidadeDto> unidadeDtos = await _unidadeService.ObterTodos();
            return Ok(unidadeDtos);
        }

        /// <summary>
        /// Lista a Unidade pelo id informado
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Retorna a Unidade</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpGet("{id}")]
        public async Task<ActionResult<UnidadeDto>> BuscarPorId(int id)
        {
            UnidadeDto unidadeDto = await _unidadeService.ObterPorId(id);
            return Ok(unidadeDto);
        }

        /// <summary>
        /// Cadastra a Unidade
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Unidade cadastrada com sucesso</response>>
        /// <response code = "400">Requisição enviada inválida</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpPost]
        public async Task<ActionResult<UnidadeDto>> Cadastrar([FromBody] UnidadeForm unidadeForm)
        {
            UnidadeDto unidadeCadastrada = await _unidadeService.Cadastrar(unidadeForm);
            return Ok(unidadeCadastrada);
        }

        /// <summary>
        /// Atualiza a Unidade pelo id informado
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Unidade atualizada com sucesso</response>>
        /// <response code = "400">Requisição enviada inválida</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpPut("{id}")]
        public async Task<ActionResult<UnidadeDto>> Atualizar([FromBody] UnidadeForm unidadeForm, int id)
        {
            UnidadeDto unidadeAtualizada = await _unidadeService.Atualizar(unidadeForm, id);
            return Ok(unidadeAtualizada);
        }

        /// <summary>
        /// Apaga a Unidade pelo id informado
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Unidade apagada com sucesso</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Apagar(int id)
        {
            await _unidadeService.Apagar(id);
            return Ok();
        }
    }
}
