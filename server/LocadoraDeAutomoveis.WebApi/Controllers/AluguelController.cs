using Microsoft.AspNetCore.Mvc;
using LocadoraDeAutomoveis.Aplicacao.ModuloAluguel.Commands.Criar;
using LocadoraDeAutomoveis.Aplicacao.ModuloAluguel.Commands.Editar;
using LocadoraDeAutomoveis.Aplicacao.ModuloAluguel.Commands.Excluir;
using LocadoraDeAutomoveis.Aplicacao.ModuloAluguel.Commands.SelecionarPorId;
using LocadoraDeAutomoveis.Aplicacao.ModuloAluguel.Commands.SelecionarTodos;
using MediatR;

namespace LocadoraDeAutomoveis.WebApi.Controllers
{
    [ApiController]
    [Route("api/alugueis")]
    public class AluguelController : ControllerBase    {
            

            private readonly IMediator _mediator;

            public AluguelController(IMediator mediator)
            {
                _mediator = mediator;
            }

            [HttpPost("criar")]
            public async Task<IActionResult> Criar([FromBody] CriarAluguelRequest request)
            {                
                var result = await _mediator.Send(request);
                return Ok(result);
            }

            [HttpPut("editar")]
            public async Task<IActionResult> Editar([FromBody] EditarAluguelRequest request)
            {
                var result = await _mediator.Send(request);
                return Ok(result);
            }

            [HttpDelete("excluir/{id}")]
            public async Task<IActionResult> Excluir(Guid id)
            {
                var result = await _mediator.Send(new ExcluirAluguelRequest { Id = id });
                return Ok(result);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> SelecionarPorId(Guid id)
            {
                var result = await _mediator.Send(new SelecionarAluguelPorIdRequest { Id = id });
                return Ok(result);
            }

            [HttpGet("todos")]
            public async Task<IActionResult> SelecionarTodos()
            {
                var result = await _mediator.Send(new SelecionarTodosAlugueisRequest());
                return Ok(result);
            }

        

    }
}
