using API_Orcamento.Rest.Dto;
using API_Orcamento.Rest.Form;
using API_Orcamento.Service;
using Microsoft.AspNetCore.Mvc;

namespace API_Orcamento.Rest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrgaoController : ControllerBase
    {
        // Injeção de dependência com a camada de serviço
        private readonly OrgaoService _orgaoService;
        public OrgaoController(OrgaoService orgaoService)
        {
            _orgaoService = orgaoService;
        }

        /// <summary>
        /// Lista todos os Órgãos
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Retorna os Órgãos cadastrados</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpGet]
        public async Task<ActionResult<List<OrgaoDto>>> BuscarTodos()
        {
            List<OrgaoDto> orgaoDtos = await _orgaoService.ObterTodos();
            return Ok(orgaoDtos);
        }

        /// <summary>
        /// Lista o Órgão pelo id informado
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Retorna o Órgão</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpGet("{id}")]
        public async Task<ActionResult<OrgaoDto>> BuscarPorId(int id)
        {
            OrgaoDto orgaoDto = await _orgaoService.ObterPorId(id);
            return Ok(orgaoDto);
        }

        /// <summary>
        /// Cadastra o Órgão
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Órgão cadastrado com sucesso</response>>
        /// <response code = "400">Requisição enviada inválida</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpPost]
        public async Task<ActionResult<OrgaoDto>> Cadastrar([FromBody] OrgaoForm orgaoForm)
        {
            OrgaoDto orgaoCadastrado = await _orgaoService.Cadastrar(orgaoForm);
            return Ok(orgaoCadastrado);
        }

        /// <summary>
        /// Atualiza o Órgão pelo id informado
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Órgão atualizado com sucesso</response>>
        /// <response code = "400">Requisição enviada inválida</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpPut("{id}")]
        public async Task<ActionResult<OrgaoDto>> Atualizar([FromBody] OrgaoForm orgaoForm, int id)
        {
            OrgaoDto orgaoAtualizado = await _orgaoService.Atualizar(orgaoForm, id);
            return Ok(orgaoAtualizado);
        }

        /// <summary>
        /// Apaga o Órgão pelo id informado
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Órgão apagado com sucesso</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Apagar(int id)
        {
            await _orgaoService.Apagar(id);
            return Ok();
        }
    }
}
