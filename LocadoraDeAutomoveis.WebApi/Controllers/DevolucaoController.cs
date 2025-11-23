using Microsoft.AspNetCore.Mvc;
using LocadoraDeAutomoveis.Aplicacao.ModuloDevolucao.Commands.Registrar;
using LocadoraDeAutomoveis.Aplicacao.ModuloDevolucao.Commands.SelecionarPorId;
using LocadoraDeAutomoveis.Aplicacao.ModuloDevolucao.Commands.SelecionarTodos;

namespace LocadoraDeAutomoveis.WebApi.Controllers
{
    [ApiController]
    [Route("api/devolucoes")]
    public class DevolucaoController : ControllerBase
    {
        private readonly RegistrarDevolucaoRequestHandler _registrarHandler;
        private readonly SelecionarDevolucaoPorIdRequestHandler _porIdHandler;
        private readonly SelecionarTodasDevolucoesRequestHandler _todosHandler;

        public DevolucaoController(
            RegistrarDevolucaoRequestHandler registrar,
            SelecionarDevolucaoPorIdRequestHandler porId,
            SelecionarTodasDevolucoesRequestHandler todos)
        {
            _registrarHandler = registrar;
            _porIdHandler = porId;
            _todosHandler = todos;
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar([FromBody] RegistrarDevolucaoRequest request)
        {
            return Ok(await _registrarHandler.Handle(request));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> SelecionarPorId(Guid id)
        {
            return Ok(await _porIdHandler.Handle(new SelecionarDevolucaoPorIdRequest { Id = id }));
        }

        [HttpGet("todos")]
        public async Task<IActionResult> SelecionarTodos()
        {
            return Ok(await _todosHandler.Handle(new SelecionarTodasDevolucoesRequest()));
        }
    }
}
