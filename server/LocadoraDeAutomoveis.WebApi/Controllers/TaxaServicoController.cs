using MediatR;
using Microsoft.AspNetCore.Mvc;
using LocadoraDeAutomoveis.Aplicacao.ModuloTaxaServico.Commands.Criar;
using LocadoraDeAutomoveis.Aplicacao.ModuloTaxaServico.Commands.Editar;
using LocadoraDeAutomoveis.Aplicacao.ModuloTaxaServico.Commands.Excluir;
using LocadoraDeAutomoveis.Aplicacao.ModuloTaxaServico.Commands.SelecionarPorId;
using LocadoraDeAutomoveis.Aplicacao.ModuloTaxaServico.Commands.SelecionarTodos;

[ApiController]
[Route("api/[controller]")]
public class TaxaServicoController : ControllerBase
{
    private readonly IMediator _mediator;
    public TaxaServicoController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] CriarTaxaServicoRequest request)
    {
        var id = await _mediator.Send(request);
        return Ok(id);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Editar(Guid id, [FromBody] EditarTaxaServicoRequest request)
    {
        request.Id = id;
        var ok = await _mediator.Send(request);
        if (!ok) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Excluir(Guid id)
    {
        var ok = await _mediator.Send(new ExcluirTaxaServicoRequest(id));
        if (!ok) return NotFound();
        return NoContent();
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> SelecionarPorId(Guid id)
    {
        var dto = await _mediator.Send(new SelecionarTaxaServicoPorIdRequest(id));
        if (dto == null) return NotFound();
        return Ok(dto);
    }

    [HttpGet]
    public async Task<IActionResult> SelecionarTodos()
    {
        var list = await _mediator.Send(new SelecionarTodasTaxasServicoRequest());
        return Ok(list);
    }
}
