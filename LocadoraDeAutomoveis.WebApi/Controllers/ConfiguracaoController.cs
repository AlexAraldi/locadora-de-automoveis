using LocadoraDeAutomoveis.Aplicacao.ModuloConfiguracao.Commands.Criar;
using LocadoraDeAutomoveis.Aplicacao.ModuloConfiguracao.Commands.Editar;
using LocadoraDeAutomoveis.Aplicacao.ModuloConfiguracao.Commands.Selecionar;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraDeAutomoveis.WebApi.Controllers
{
    [ApiController]
    [Route("api/configuracoes")]
    public class ConfiguracaoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ConfiguracaoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("criar")]
        public async Task<IActionResult> Criar([FromBody] CriarConfiguracaoRequest request)
        {
            var resultado = await _mediator.Send(request);
            return Ok(resultado);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Editar(Guid id, [FromBody] EditarConfiguracaoRequest request)
        {
            request.Id = id;
            var resultado = await _mediator.Send(request);
            return Ok(resultado);
        }

        [HttpGet]
        public async Task<IActionResult> Selecionar()
        {
            var resultado = await _mediator.Send(new SelecionarConfiguracaoRequest());
            return Ok(resultado);
        }
    }
}
