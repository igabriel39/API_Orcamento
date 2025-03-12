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

        [HttpGet]
        public async Task<ActionResult<List<AcaoDto>>> BuscarTodos()
        {
            List<AcaoDto> acaoDtos = await _acaoService.ObterTodos();
            return Ok(acaoDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AcaoDto>> BuscarPorId(int id)
        {
            AcaoDto acaoDto = await _acaoService.ObterPorId(id);
            return Ok(acaoDto);
        }

        [HttpPost]
        public async Task<ActionResult<AcaoDto>> Cadastrar([FromBody] AcaoForm acaoForm)
        {
            if (!ModelState.IsValid)
            {
                // Caso não seja válido, lance uma exceção com as mensagens de erro
                var erros = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                throw new InvalidOperationException($"Erro de validação: {string.Join(", ", erros)}");
            }

            AcaoDto acaoCadastrada = await _acaoService.Cadastrar(acaoForm);
            return Ok(acaoCadastrada);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AcaoDto>> Atualizar([FromBody] AcaoForm acaoForm, int id)
        {
            AcaoDto acaoAtualizada = await _acaoService.Atualizar(acaoForm, id);
            return Ok(acaoAtualizada);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Apagar(int id)
        {
            await _acaoService.Apagar(id);
            return Ok();
        }
    }
}
