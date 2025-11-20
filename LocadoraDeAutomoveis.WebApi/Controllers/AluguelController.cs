using Microsoft.AspNetCore.Mvc;
using LocadoraDeAutomoveis.Aplicacao.ModuloAluguel.Commands.Criar;
using LocadoraDeAutomoveis.Aplicacao.ModuloAluguel.Commands.Editar;
using LocadoraDeAutomoveis.Aplicacao.ModuloAluguel.Commands.Excluir;
using LocadoraDeAutomoveis.Aplicacao.ModuloAluguel.Commands.SelecionarPorId;
using LocadoraDeAutomoveis.Aplicacao.ModuloAluguel.Commands.SelecionarTodos;

namespace LocadoraDeAutomoveis.WebApi.Controllers
{
    [ApiController]
    [Route("api/alugueis")]
    public class AluguelController : ControllerBase
    {
        private readonly CriarAluguelRequestHandler _criarHandler;
        private readonly EditarAluguelRequestHandler _editarHandler;
        private readonly ExcluirAluguelRequestHandler _excluirHandler;
        private readonly SelecionarAluguelPorIdRequestHandler _selecionarPorIdHandler;
        private readonly SelecionarTodosAlugueisRequestHandler _selecionarTodosHandler;

        public AluguelController(
            CriarAluguelRequestHandler criarHandler,
            EditarAluguelRequestHandler editarHandler,
            ExcluirAluguelRequestHandler excluirHandler,
            SelecionarAluguelPorIdRequestHandler selecionarPorIdHandler,
            SelecionarTodosAlugueisRequestHandler selecionarTodosHandler)
        {
            _criarHandler = criarHandler;
            _editarHandler = editarHandler;
            _excluirHandler = excluirHandler;
            _selecionarPorIdHandler = selecionarPorIdHandler;
            _selecionarTodosHandler = selecionarTodosHandler;
        }

        [HttpPost("criar")]
        public async Task<IActionResult> Criar([FromBody] CriarAluguelRequest request)
        {
            var result = await _criarHandler.Handle(request);
            return Ok(result);
        }

        [HttpPut("editar")]
        public async Task<IActionResult> Editar([FromBody] EditarAluguelRequest request)
        {
            var result = await _editarHandler.Handle(request);
            return Ok(result);
        }

        [HttpDelete("excluir/{id}")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            var result = await _excluirHandler.Handle(new ExcluirAluguelRequest { Id = id });
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> SelecionarPorId(Guid id)
        {
            var result = await _selecionarPorIdHandler.Handle(new SelecionarAluguelPorIdRequest { Id = id });
            return Ok(result);
        }

        [HttpGet("todos")]
        public async Task<IActionResult> SelecionarTodos()
        {
            var result = await _selecionarTodosHandler.Handle(new SelecionarTodosAlugueisRequest());
            return Ok(result);
        }
    }
}
