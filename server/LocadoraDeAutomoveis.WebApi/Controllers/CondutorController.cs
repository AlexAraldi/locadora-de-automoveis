using LocadoraDeAutomoveis.Aplicacao.ModuloCondutor.Commands.Criar;
using LocadoraDeAutomoveis.Aplicacao.ModuloCondutor.Commands.Editar;
using LocadoraDeAutomoveis.Aplicacao.ModuloCondutor.Commands.Excluir;
using LocadoraDeAutomoveis.Aplicacao.ModuloCondutor.Commands.SelecionarPorId;
using LocadoraDeAutomoveis.Aplicacao.ModuloCondutor.Commands.SelecionarTodos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraDeAutomoveis.WebApi.Controllers
{
    [ApiController]
    [Route("api/condutores")]   
            

        public class CondutorController : ControllerBase
        {
            private readonly IMediator _mediator;

            public CondutorController(IMediator mediator)
            {
                _mediator = mediator;
            }

            [HttpPost("criar")]
            public async Task<IActionResult> Criar([FromBody] CriarCondutorRequest request)
            {
                var resultado = await _mediator.Send(request);
                return Ok(resultado);
            }

            [HttpPut("editar")]
            public async Task<IActionResult> Editar([FromBody] EditarCondutorRequest request)
            {
                var resultado = await _mediator.Send(request);
                return Ok(resultado);
            }

            [HttpDelete("excluir/{id}")]
            public async Task<IActionResult> Excluir(Guid id)
            {
                var result = await _mediator.Send(new ExcluirCondutorRequest { Id = id });
                return Ok(result);  
        }

            [HttpGet("{id}")]
            public async Task<IActionResult> SelecionarPorId(Guid id)
            {
                var result = await _mediator.Send(new SelecionarCondutorPorIdRequest { Id = id });
                return Ok(result);  
        }

            [HttpGet("todos")]
            public async Task<IActionResult> SelecionarTodos()
            {
                var result = await _mediator.Send(new SelecionarTodosCondutoresRequest());
                return Ok(result);
        }


        }
       
    
}
