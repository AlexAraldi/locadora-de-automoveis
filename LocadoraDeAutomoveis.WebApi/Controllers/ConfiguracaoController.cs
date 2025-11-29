using Microsoft.AspNetCore.Mvc;
using LocadoraDeAutomoveis.Aplicacao.ModuloConfiguracao.Commands.Editar;
using LocadoraDeAutomoveis.Aplicacao.ModuloConfiguracao.Commands.Selecionar;
using MediatR;

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

        // ======================================================================
        // GET api/configuracoes
        // Seleciona a configuração do sistema (sempre existe apenas 1 registro)
        // ======================================================================
        [HttpGet]
        public async Task<IActionResult> Selecionar()
        {
            var result = await _mediator.Send(new SelecionarConfiguracaoRequest());
            return Ok(result);
        }

        // ======================================================================
        // PUT api/configuracoes/editar
        // Edita a configuração existente
        // ======================================================================
        [HttpPut("editar")]
        public async Task<IActionResult> Editar([FromBody] EditarConfiguracaoRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
