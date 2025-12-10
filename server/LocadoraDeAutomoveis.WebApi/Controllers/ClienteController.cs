using LocadoraDeAutomoveis.Aplicacao.ModuloCliente.Commands.Criar;
using LocadoraDeAutomoveis.Aplicacao.ModuloCliente.Commands.Editar;
using LocadoraDeAutomoveis.Aplicacao.ModuloCliente.Commands.Excluir;
using LocadoraDeAutomoveis.Aplicacao.ModuloCliente.Commands.SelecionarPorId;
using LocadoraDeAutomoveis.Aplicacao.ModuloCliente.Commands.SelecionarTodos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraDeAutomoveis.WebApi.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClienteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("criar")]
        public async Task<IActionResult> Criar([FromBody] CriarClienteRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPut("editar")]
        public async Task<IActionResult> Editar([FromBody] EditarClienteRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpDelete("excluir/{id}")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            var result = await _mediator.Send(new ExcluirClienteRequest { Id = id });
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> SelecionarPorId(Guid id)
        {
            var result = await _mediator.Send(new SelecionarClientePorIdRequest { Id = id });
            return Ok(result);
        }

        [HttpGet("todos")]
        public async Task<IActionResult> SelecionarTodos()
        {
            var result = await _mediator.Send(new SelecionarTodosClientesRequest());
            return Ok(result);
        }
    }
}
