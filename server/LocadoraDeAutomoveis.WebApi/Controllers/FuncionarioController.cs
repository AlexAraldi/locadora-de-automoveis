using LocadoraDeAutomoveis.Aplicacao.ModuloFuncionario.Commands.Criar;
using LocadoraDeAutomoveis.Aplicacao.ModuloFuncionario.Commands.Editar;
using LocadoraDeAutomoveis.Aplicacao.ModuloFuncionario.Commands.Excluir;
using LocadoraDeAutomoveis.Aplicacao.ModuloFuncionario.Commands.SelecionarPorId;
using LocadoraDeAutomoveis.Aplicacao.ModuloFuncionario.Commands.SelecionarTodos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraDeAutomoveis.WebApi.Controllers
{
    [ApiController]
    [Route("api/funcionarios")]
    public class FuncionarioController : ControllerBase
    {
       
        private readonly IMediator _mediator;

        public FuncionarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("criar")]
        public async Task<IActionResult> Criar([FromBody] CriarFuncionarioRequest request)
        {
            var resultado = await _mediator.Send(request);
            return Ok(resultado);
        }

        [HttpPut("editar")]
        public async Task<IActionResult> Editar([FromBody] EditarFuncionarioRequest request)
        {
            var resultado = await _mediator.Send(request);
            return Ok(resultado);
        }

        [HttpDelete("excluir/{id}")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            var resultado = await _mediator.Send(new ExcluirFuncionarioRequest { Id = id });
            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> SelecionarPorId(Guid id)
        {
            var resultado = await _mediator.Send(new SelecionarFuncionarioPorIdRequest { Id = id });              
            return Ok(resultado);
        }

        [HttpGet]
        public async Task<IActionResult> SelecionarTodos()
        {
            var resultado = await _mediator.Send(new SelecionarTodosFuncionariosRequest());
            return Ok(resultado);
        }
    }
}
