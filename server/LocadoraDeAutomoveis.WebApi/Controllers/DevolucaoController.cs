using Microsoft.AspNetCore.Mvc;
using LocadoraDeAutomoveis.Aplicacao.ModuloDevolucao.Commands.Registrar;
using LocadoraDeAutomoveis.Aplicacao.ModuloDevolucao.Commands.SelecionarPorId;
using LocadoraDeAutomoveis.Aplicacao.ModuloDevolucao.Commands.SelecionarTodos;
using MediatR;

namespace LocadoraDeAutomoveis.WebApi.Controllers
{
    [ApiController]
    [Route("api/devolucoes")]
    public class DevolucaoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DevolucaoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar([FromBody] RegistrarDevolucaoRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> SelecionarPorId(Guid id)
        {
            return Ok(await _mediator.Send(new SelecionarDevolucaoPorIdRequest { Id = id }));
        }

        [HttpGet("todos")]
        public async Task<IActionResult> SelecionarTodos()
        {
            return Ok(await _mediator.Send(new SelecionarTodasDevolucoesRequest()));
        }
    }
}
