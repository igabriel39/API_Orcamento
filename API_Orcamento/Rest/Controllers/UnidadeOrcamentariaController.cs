using API_Orcamento.Rest.Dto;
using API_Orcamento.Rest.Form;
using API_Orcamento.Service;
using Microsoft.AspNetCore.Mvc;

namespace API_Orcamento.Rest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnidadeOrcamentariaController : ControllerBase
    {
        // Injeção de dependência com a camada de serviço
        private readonly UnidadeOrcamentariaService _unidadeOrcamentariaService;
        public UnidadeOrcamentariaController(UnidadeOrcamentariaService unidadeOrcamentariaService)
        {
            _unidadeOrcamentariaService = unidadeOrcamentariaService;
        }

        /// <summary>
        /// Lista todas as Unidades Orçamentárias
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Retorna as Unidades Orçamentárias cadastradas</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpGet]
        public async Task<ActionResult<List<UnidadeOrcamentariaDto>>> BuscarTodos()
        {
            List<UnidadeOrcamentariaDto> unidadeOrcamentariaDtos = await _unidadeOrcamentariaService.ObterTodos();
            return Ok(unidadeOrcamentariaDtos);
        }

        /// <summary>
        /// Lista a Unidade Orçamentária pelo id informado
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Retorna a Unidade Orçamentária</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpGet("{id}")]
        public async Task<ActionResult<UnidadeOrcamentariaDto>> BuscarPorId(int id)
        {
            UnidadeOrcamentariaDto unidadeOrcamentariaDto = await _unidadeOrcamentariaService.ObterPorId(id);
            return Ok(unidadeOrcamentariaDto);
        }

        /// <summary>
        /// Cadastra a Unidade Orçamentária
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Unidade orçamentária cadastrada com sucesso</response>>
        /// <response code = "400">Requisição enviada inválida</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpPost]
        public async Task<ActionResult<UnidadeOrcamentariaDto>> Cadastrar([FromBody] UnidadeOrcamentariaForm unidadeOrcamentariaForm)
        {
            UnidadeOrcamentariaDto unidadeOrcamentariaCadastrada = await _unidadeOrcamentariaService.Cadastrar(unidadeOrcamentariaForm);
            return Ok(unidadeOrcamentariaCadastrada);
        }

        /// <summary>
        /// Atualiza a Unidade Orçamentária pelo id informado
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Unidade Orçamentária atualizada com sucesso</response>>
        /// <response code = "400">Requisição enviada inválida</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpPut("{id}")]
        public async Task<ActionResult<UnidadeOrcamentariaDto>> Atualizar([FromBody] UnidadeOrcamentariaForm unidadeOrcamentariaForm, int id)
        {
            UnidadeOrcamentariaDto unidadeOrcamentariaAtualizada = await _unidadeOrcamentariaService.Atualizar(unidadeOrcamentariaForm, id);
            return Ok(unidadeOrcamentariaAtualizada);
        }

        /// <summary>
        /// Apaga a Unidade Orçamentária pelo id informado
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Unidade Orçamentária apagada com sucesso</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Apagar(int id)
        {
            await _unidadeOrcamentariaService.Apagar(id);
            return Ok();
        }
    }
}
