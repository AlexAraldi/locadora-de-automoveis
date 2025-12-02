using Microsoft.AspNetCore.Mvc;
using LocadoraDeAutomoveis.Aplicacao.ModuloPlanoCobranca.Commands.Criar;
using LocadoraDeAutomoveis.Aplicacao.ModuloPlanoCobranca.Commands.Editar;
using LocadoraDeAutomoveis.Aplicacao.ModuloPlanoCobranca.Commands.Excluir;
using LocadoraDeAutomoveis.Aplicacao.ModuloPlanoCobranca.Commands.SelecionarPorId;
using LocadoraDeAutomoveis.Aplicacao.ModuloPlanoCobranca.Commands.SelecionarTodos;
using MediatR;

namespace LocadoraDeAutomoveis.WebApi.Controllers
{
    [ApiController]
    [Route("api/planos-cobranca")]
    public class PlanoCobrancaController : ControllerBase
    {
       
        private readonly IMediator _mediator;

        public PlanoCobrancaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("criar")]
        public async Task<IActionResult> Criar([FromBody] CriarPlanoCobrancaRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPut("editar")]
        public async Task<IActionResult> Editar([FromBody] EditarPlanoCobrancaRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpDelete("excluir/{id}")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            var result = await _mediator.Send(new ExcluirPlanoCobrancaRequest { Id = id });
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> SelecionarPorId(Guid id)
        {
            var result = await _mediator.Send(
                new SelecionarPlanoCobrancaPorIdRequest { Id = id });

            return Ok(result);
        }

        [HttpGet("todos")]
        public async Task<IActionResult> SelecionarTodos()
        {
            var result = await _mediator.Send(
                new SelecionarTodosPlanosCobrancaRequest());

            return Ok(result);
        }
    }
}
