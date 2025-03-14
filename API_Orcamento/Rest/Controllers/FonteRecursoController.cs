using API_Orcamento.Rest.Dto;
using API_Orcamento.Rest.Form;
using API_Orcamento.Service;
using Microsoft.AspNetCore.Mvc;

namespace API_Orcamento.Rest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FonteRecursoController : ControllerBase
    {
        // Injeção de dependência com a camada de serviço
        private readonly FonteRecursoService _fonteRecursoService;
        public FonteRecursoController(FonteRecursoService fonteRecursoService)
        {
            _fonteRecursoService = fonteRecursoService;
        }

        /// <summary>
        /// Lista todas as Fontes Recursos
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Retorna as Fontes Recursos cadastradas</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpGet]
        public async Task<ActionResult<List<FonteRecursoDto>>> BuscarTodos()
        {
            List<FonteRecursoDto> fonteRecursoDtos = await _fonteRecursoService.ObterTodos();
            return Ok(fonteRecursoDtos);
        }

        /// <summary>
        /// Lista a Fonte Recurso pelo id informado
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Retorna a Fonte Recurso</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpGet("{id}")]
        public async Task<ActionResult<FonteRecursoDto>> BuscarPorId(int id)
        {
            FonteRecursoDto fonteRecursoDto = await _fonteRecursoService.ObterPorId(id);
            return Ok(fonteRecursoDto);
        }

        /// <summary>
        /// Cadastra a Fonte Recurso
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Fonte Recurso cadastrada com sucesso</response>>
        /// <response code = "400">Requisição enviada inválida</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpPost]
        public async Task<ActionResult<FonteRecursoDto>> Cadastrar([FromBody] FonteRecursoForm fonteRecursoForm)
        {
            FonteRecursoDto fonteRecursoCadastrada = await _fonteRecursoService.Cadastrar(fonteRecursoForm);
            return Ok(fonteRecursoCadastrada);
        }

        /// <summary>
        /// Atualiza a Fonte Recurso pelo id informado
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Fonte Recurso atualizada com sucesso</response>>
        /// <response code = "400">Requisição enviada inválida</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpPut("{id}")]
        public async Task<ActionResult<FonteRecursoDto>> Atualizar([FromBody] FonteRecursoForm fonteRecursoForm, int id)
        {
            FonteRecursoDto fonteRecursoAtualizada = await _fonteRecursoService.Atualizar(fonteRecursoForm, id);
            return Ok(fonteRecursoAtualizada);
        }

        /// <summary>
        /// Apaga a Fonte Recurso pelo id informado
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Fonte Recurso apagada com sucesso</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Apagar(int id)
        {
            await _fonteRecursoService.Apagar(id);
            return Ok();
        }
    }
}
