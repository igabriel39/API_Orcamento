using API_Orcamento.Rest.Dto;
using API_Orcamento.Rest.Form;
using API_Orcamento.Service;
using Microsoft.AspNetCore.Mvc;

namespace API_Orcamento.Rest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ElementoDespesaController : ControllerBase
    {
        // Injeção de dependência com a camada de serviço
        private readonly ElementoDespesaService _elementoDespesaService;
        public ElementoDespesaController(ElementoDespesaService elementoDespesaService)
        {
            _elementoDespesaService = elementoDespesaService;
        }

        /// <summary>
        /// Lista todas os Elementos Despesas
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Retorna os Elementos Despesas cadastrados</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpGet]
        public async Task<ActionResult<List<ElementoDespesaDto>>> BuscarTodos()
        {
            List<ElementoDespesaDto> elementoDespesaDtos = await _elementoDespesaService.ObterTodos();
            return Ok(elementoDespesaDtos);
        }

        /// <summary>
        /// Lista o Elemento Despesa pelo id informado
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Retorna o Elemento Despesa</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpGet("{id}")]
        public async Task<ActionResult<ElementoDespesaDto>> BuscarPorId(int id)
        {
            ElementoDespesaDto elementoDespesaDto = await _elementoDespesaService.ObterPorId(id);
            return Ok(elementoDespesaDto);
        }

        /// <summary>
        /// Cadastra o Elemento Despesa
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Elemento Despesa cadastrado com sucesso</response>>
        /// <response code = "400">Requisição enviada inválida</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpPost]
        public async Task<ActionResult<ElementoDespesaDto>> Cadastrar([FromBody] ElementoDespesaForm elementoDespesaForm)
        {
            ElementoDespesaDto elementoDespesaCadastrado = await _elementoDespesaService.Cadastrar(elementoDespesaForm);
            return Ok(elementoDespesaCadastrado);
        }

        /// <summary>
        /// Atualiza o Elemento Despesa pelo id informado
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Elemento Despesa atualizado com sucesso</response>>
        /// <response code = "400">Requisição enviada inválida</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpPut("{id}")]
        public async Task<ActionResult<ElementoDespesaDto>> Atualizar([FromBody] ElementoDespesaForm elementoDespesaForm, int id)
        {
            ElementoDespesaDto elementoDespesaAtualizado = await _elementoDespesaService.Atualizar(elementoDespesaForm, id);
            return Ok(elementoDespesaAtualizado);
        }

        /// <summary>
        /// Apaga o Elemento Despesa pelo id informado
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Elemento Despesa apagado com sucesso</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Apagar(int id)
        {
            await _elementoDespesaService.Apagar(id);
            return Ok();
        }
    }
}
