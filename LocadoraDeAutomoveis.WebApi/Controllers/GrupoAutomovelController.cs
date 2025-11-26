using LocadoraDeAutomoveis.Aplicacao.ModuloGrupoAutomovel.Commands.Criar;
using LocadoraDeAutomoveis.Aplicacao.ModuloGrupoAutomovel.Commands.Editar;
using LocadoraDeAutomoveis.Aplicacao.ModuloGrupoAutomovel.Commands.Excluir;
using LocadoraDeAutomoveis.Aplicacao.ModuloGrupoAutomovel.Commands.SelecionarPorId;
using LocadoraDeAutomoveis.Aplicacao.ModuloGrupoAutomovel.Commands.SelecionarTodos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraDeAutomoveis.WebApi.Controllers
{
    [ApiController]
    [Route("api/grupos")]
    public class GrupoAutomovelController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GrupoAutomovelController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("criar")]
        public async Task<IActionResult> Criar([FromBody] CriarGrupoAutomovelRequest request)
        {
            var resultado = await _mediator.Send(request);
            return Ok(resultado);
        }

        [HttpPut("editar")]
        public async Task<IActionResult> Editar([FromBody] EditarGrupoAutomovelRequest request)
        {
            var resultado = await _mediator.Send(request);
            return Ok(resultado);
        }

        [HttpDelete("excluir/{id}")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            var request = new ExcluirGrupoAutomovelRequest { Id = id };

            var resultado = await _mediator.Send(request);
            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> SelecionarPorId(Guid id)
        {
            var request = new SelecionarGrupoAutomovelPorIdRequest { Id = id };
            var resultado = await _mediator.Send(request);
            return Ok(resultado);
        }

        [HttpGet("todos")]
        public async Task<IActionResult> SelecionarTodos()
        {
            var request = new SelecionarTodosGruposAutomovelRequest();
            var resultado = await _mediator.Send(request);
            return Ok(resultado);
        }
    }
}
