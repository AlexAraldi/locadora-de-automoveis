using MediatR;
using Microsoft.AspNetCore.Mvc;
using LocadoraDeAutomoveis.Aplicacao.ModuloTaxaServico.Commands.Criar;
using LocadoraDeAutomoveis.Aplicacao.ModuloTaxaServico.Commands.Editar;
using LocadoraDeAutomoveis.Aplicacao.ModuloTaxaServico.Commands.SelecionarPorId;
using LocadoraDeAutomoveis.Aplicacao.ModuloTaxaServico.Commands.SelecionarTodos;
using LocadoraDeAutomoveis.Aplicacao.ModuloTaxaServico.Commands.Excluir;

[ApiController]
[Route("api/taxas-servico")]
public class TaxaServicoController : ControllerBase
{
    private readonly IMediator _mediator;
    public TaxaServicoController(IMediator mediator) => _mediator = mediator;

    [HttpPost ("criar")]
    public async Task<IActionResult> Criar([FromBody] CriarTaxaServicoRequest request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }

    [HttpPut("editar")]
    public async Task<IActionResult> Editar( [FromBody] EditarTaxaServicoRequest request)
    {
         var result = await _mediator.Send(request);
            return Ok(result);
    }

    [HttpDelete("excluir/{id}")]
    public async Task<IActionResult> Excluir(Guid id)
    {
        var result = await _mediator.Send(new ExcluirTaxaServicoRequest { Id = id });
            return Ok(result);;
    }

     [HttpGet("{id}")]
    public async Task<IActionResult> SelecionarPorId(Guid id)
    {
         var result = await _mediator.Send(new SelecionarTaxaServicoPorIdRequest { Id = id });
            return Ok(result);
    }

    [HttpGet("todos")]
    public async Task<IActionResult> SelecionarTodos()
    {
         var result = await _mediator.Send(new SelecionarTodosTaxasServicoRequest());
            return Ok(result);
    }
}
