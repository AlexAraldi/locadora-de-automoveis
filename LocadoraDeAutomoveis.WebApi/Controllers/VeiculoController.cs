using LocadoraDeAutomoveis.Aplicacao.ModuloVeiculo.Commands.Criar;
using LocadoraDeAutomoveis.Aplicacao.ModuloVeiculo.Commands.Editar;
using LocadoraDeAutomoveis.Aplicacao.ModuloVeiculo.Commands.Excluir;
using LocadoraDeAutomoveis.Aplicacao.ModuloVeiculo.Commands.SelecionarPorId;
using LocadoraDeAutomoveis.Aplicacao.ModuloVeiculo.Commands.SelecionarTodos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraDeAutomoveis.WebApi.Controllers
{
    [ApiController]
    [Route("api/veiculos")]
    public class VeiculoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VeiculoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("criar")]
        public async Task<IActionResult> Criar([FromBody] CriarVeiculoRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPut("editar")]
        public async Task<IActionResult> Editar([FromBody] EditarVeiculoRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpDelete("excluir/{id}")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            var result = await _mediator.Send(new ExcluirVeiculoRequest { Id = id });
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> SelecionarPorId(Guid id)
        {
            var result = await _mediator.Send(new SelecionarVeiculoPorIdRequest { Id = id });
            return Ok(result);
        }
        [HttpGet("todos")]
        public async Task<IActionResult> SelecionarTodos()
        {
            var result = await _mediator.Send(new SelecionarTodosVeiculosRequest());
            return Ok(result);
        }
    }
}
