using API_Orcamento.Rest.Dto;
using API_Orcamento.Rest.Form;
using API_Orcamento.Service;
using Microsoft.AspNetCore.Mvc;

namespace API_Orcamento.Rest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ModalidadeAplicacaoController : ControllerBase
    {
        // Injeção de dependência com a camada de serviço
        private readonly ModalidadeAplicacaoService _modalidadeAplicacaoService;
        public ModalidadeAplicacaoController(ModalidadeAplicacaoService modalidadeAplicacaoService)
        {
            _modalidadeAplicacaoService = modalidadeAplicacaoService;
        }

        /// <summary>
        /// Lista todas as Modalidades Aplicações
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Retorna as Modalidades Aplicações cadastradas</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpGet]
        public async Task<ActionResult<List<ModalidadeAplicacaoDto>>> BuscarTodos()
        {
            List<ModalidadeAplicacaoDto> modalidadeAplicacaoDtos = await _modalidadeAplicacaoService.ObterTodos();
            return Ok(modalidadeAplicacaoDtos);
        }

        /// <summary>
        /// Lista a Modalidade Aplicação pelo id informado
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Retorna a Modalidade Aplicação</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpGet("{id}")]
        public async Task<ActionResult<ModalidadeAplicacaoDto>> BuscarPorId(int id)
        {
            ModalidadeAplicacaoDto modalidadeAplicacaoDto = await _modalidadeAplicacaoService.ObterPorId(id);
            return Ok(modalidadeAplicacaoDto);
        }

        /// <summary>
        /// Cadastra a Modalidade Aplicação
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Modalidade Aplicação cadastrada com sucesso</response>>
        /// <response code = "400">Requisição enviada inválida</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpPost]
        public async Task<ActionResult<ModalidadeAplicacaoDto>> Cadastrar([FromBody] ModalidadeAplicacaoForm modalidadeAplicacaoForm)
        {
            ModalidadeAplicacaoDto modalidadeAplicacaoCadastrada = await _modalidadeAplicacaoService.Cadastrar(modalidadeAplicacaoForm);
            return Ok(modalidadeAplicacaoCadastrada);
        }

        /// <summary>
        /// Atualiza a Modalidade Aplicação pelo id informado
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Modalidade Aplicação atualizada com sucesso</response>>
        /// <response code = "400">Requisição enviada inválida</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpPut("{id}")]
        public async Task<ActionResult<ModalidadeAplicacaoDto>> Atualizar([FromBody] ModalidadeAplicacaoForm modalidadeAplicacaoForm, int id)
        {
            ModalidadeAplicacaoDto modalidadeAplicacaoAtualizada = await _modalidadeAplicacaoService.Atualizar(modalidadeAplicacaoForm, id);
            return Ok(modalidadeAplicacaoAtualizada);
        }

        /// <summary>
        /// Apaga a Modalidade Aplicãção pelo id informado
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Modalidade Aplicação apagada com sucesso</response>>
        /// <response code = "500">Erro Interno no Servidor</response>>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Apagar(int id)
        {
            await _modalidadeAplicacaoService.Apagar(id);
            return Ok();
        }
    }
}
