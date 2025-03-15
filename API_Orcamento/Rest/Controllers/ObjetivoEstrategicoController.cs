using API_Orcamento.Rest.Dto;
using API_Orcamento.Rest.Form;
using API_Orcamento.Service;
using Microsoft.AspNetCore.Mvc;

namespace API_Orcamento.Rest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ObjetivoEstrategicoController : ControllerBase
    {
        // Injeção de dependência com a camada de serviço
        private readonly ObjetivoEstrategicoService _objetivoEstrategicoService;
        public ObjetivoEstrategicoController(ObjetivoEstrategicoService objetivoEstrategicoService)
        {
            _objetivoEstrategicoService = objetivoEstrategicoService;
        }

        /// <summary>
        /// Lista todos os Objetivos Estratégicos
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Retorna os Objetivos Estratégicos cadastrados</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpGet]
        public async Task<ActionResult<List<ObjetivoEstrategicoDto>>> BuscarTodos()
        {
            List<ObjetivoEstrategicoDto> objetivoEstrategicoDtos = await _objetivoEstrategicoService.ObterTodos();
            return Ok(objetivoEstrategicoDtos);
        }

        /// <summary>
        /// Lista o Objetivo Estratégico pelo id informado
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Retorna o Objetivo Estratégico</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpGet("{id}")]
        public async Task<ActionResult<ObjetivoEstrategicoDto>> BuscarPorId(int id)
        {
            ObjetivoEstrategicoDto objetivoEstrategicoDto = await _objetivoEstrategicoService.ObterPorId(id);
            return Ok(objetivoEstrategicoDto);
        }

        /// <summary>
        /// Cadastra o Objetivo Estratégico
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Objetivo Estratégico cadastrado com sucesso</response>>
        /// <response code = "400">Requisição enviada inválida</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpPost]
        public async Task<ActionResult<ObjetivoEstrategicoDto>> Cadastrar([FromBody] ObjetivoEstrategicoForm objetivoEstrategicoForm)
        {
            ObjetivoEstrategicoDto objetivoEstrategicoCadastrado = await _objetivoEstrategicoService.Cadastrar(objetivoEstrategicoForm);
            return Ok(objetivoEstrategicoCadastrado);
        }

        /// <summary>
        /// Atualiza o Objetivo Estratégico pelo id informado
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Objetivo Estratégico atualizado com sucesso</response>>
        /// <response code = "400">Requisição enviada inválida</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpPut("{id}")]
        public async Task<ActionResult<ObjetivoEstrategicoDto>> Atualizar([FromBody] ObjetivoEstrategicoForm objetivoEstrategicoForm, int id)
        {
            ObjetivoEstrategicoDto objetivoEstrategicoAtualizado = await _objetivoEstrategicoService.Atualizar(objetivoEstrategicoForm, id);
            return Ok(objetivoEstrategicoAtualizado);
        }

        /// <summary>
        /// Apaga o Objetivo Estratégico pelo id informado
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Objetivo Estratégico apagado com sucesso</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Apagar(int id)
        {
            await _objetivoEstrategicoService.Apagar(id);
            return Ok();
        }
    }
}
