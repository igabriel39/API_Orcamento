using API_Orcamento.Rest.Dto;
using API_Orcamento.Rest.Form;
using API_Orcamento.Service;
using Microsoft.AspNetCore.Mvc;

namespace API_Orcamento.Rest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GrupoDespesaController : ControllerBase
    {
        // Injeção de dependência com a camada de serviço
        private readonly GrupoDespesaService _grupoDespesaService;
        public GrupoDespesaController(GrupoDespesaService grupoDespesaService)
        {
            _grupoDespesaService = grupoDespesaService;
        }

        /// <summary>
        /// Lista todas os Grupos Despesas
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Retorna os Grupos Despesas cadastrados</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpGet]
        public async Task<ActionResult<List<GrupoDespesaDto>>> BuscarTodos()
        {
            List<GrupoDespesaDto> grupoDespesaDtos = await _grupoDespesaService.ObterTodos();
            return Ok(grupoDespesaDtos);
        }

        /// <summary>
        /// Lista o Grupo Despesa pelo id informado
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Retorna o Grupo Despesa</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpGet("{id}")]
        public async Task<ActionResult<GrupoDespesaDto>> BuscarPorId(int id)
        {
            GrupoDespesaDto grupoDespesaDto = await _grupoDespesaService.ObterPorId(id);
            return Ok(grupoDespesaDto);
        }

        /// <summary>
        /// Cadastra o Grupo Despesa
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Grupo Despesa cadastrado com sucesso</response>>
        /// <response code = "400">Requisição enviada inválida</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpPost]
        public async Task<ActionResult<GrupoDespesaDto>> Cadastrar([FromBody] GrupoDespesaForm grupoDespesaForm)
        {
            GrupoDespesaDto grupoDespesaCadastrado = await _grupoDespesaService.Cadastrar(grupoDespesaForm);
            return Ok(grupoDespesaCadastrado);
        }

        /// <summary>
        /// Atualiza o Grupo Despesa pelo id informado
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Grupo Despesa atualizado com sucesso</response>>
        /// <response code = "400">Requisição enviada inválida</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpPut("{id}")]
        public async Task<ActionResult<GrupoDespesaDto>> Atualizar([FromBody] GrupoDespesaForm grupoDespesaForm, int id)
        {
            GrupoDespesaDto grupoDespesaAtualizado = await _grupoDespesaService.Atualizar(grupoDespesaForm, id);
            return Ok(grupoDespesaAtualizado);
        }

        /// <summary>
        /// Apaga o Grupo Despesa pelo id informado
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Grupo Despesa apagado com sucesso</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Apagar(int id)
        {
            await _grupoDespesaService.Apagar(id);
            return Ok();
        }
    }
}
