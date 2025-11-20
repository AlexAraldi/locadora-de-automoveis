using Microsoft.AspNetCore.Mvc;
using LocadoraDeAutomoveis.Aplicacao.ModuloPlanoCobranca.Commands.Criar;
using LocadoraDeAutomoveis.Aplicacao.ModuloPlanoCobranca.Commands.Editar;
using LocadoraDeAutomoveis.Aplicacao.ModuloPlanoCobranca.Commands.Excluir;
using LocadoraDeAutomoveis.Aplicacao.ModuloPlanoCobranca.Commands.SelecionarPorId;
using LocadoraDeAutomoveis.Aplicacao.ModuloPlanoCobranca.Commands.SelecionarTodos;

namespace LocadoraDeAutomoveis.WebApi.Controllers
{
    [ApiController]
    [Route("api/planos-cobranca")]
    public class PlanoCobrancaController : ControllerBase
    {
        private readonly CriarPlanoCobrancaRequestHandler _criarHandler;
        private readonly EditarPlanoCobrancaRequestHandler _editarHandler;
        private readonly ExcluirPlanoCobrancaRequestHandler _excluirHandler;
        private readonly SelecionarPlanoCobrancaPorIdRequestHandler _selecionarPorIdHandler;
        private readonly SelecionarTodosPlanosCobrancaRequestHandler _selecionarTodosHandler;

        public PlanoCobrancaController(
            CriarPlanoCobrancaRequestHandler criarHandler,
            EditarPlanoCobrancaRequestHandler editarHandler,
            ExcluirPlanoCobrancaRequestHandler excluirHandler,
            SelecionarPlanoCobrancaPorIdRequestHandler selecionarPorIdHandler,
            SelecionarTodosPlanosCobrancaRequestHandler selecionarTodosHandler)
        {
            _criarHandler = criarHandler;
            _editarHandler = editarHandler;
            _excluirHandler = excluirHandler;
            _selecionarPorIdHandler = selecionarPorIdHandler;
            _selecionarTodosHandler = selecionarTodosHandler;
        }

        [HttpPost("criar")]
        public async Task<IActionResult> Criar([FromBody] CriarPlanoCobrancaRequest request)
        {
            var resultado = await _criarHandler.Handle(request);
            return Ok(resultado);
        }

        [HttpPut("editar")]
        public async Task<IActionResult> Editar([FromBody] EditarPlanoCobrancaRequest request)
        {
            var resultado = await _editarHandler.Handle(request);
            return Ok(resultado);
        }

        [HttpDelete("excluir/{id}")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            var resultado = await _excluirHandler.Handle(new ExcluirPlanoCobrancaRequest { Id = id });
            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> SelecionarPorId(Guid id)
        {
            var resultado = await _selecionarPorIdHandler.Handle(
                new SelecionarPlanoCobrancaPorIdRequest { Id = id });

            return Ok(resultado);
        }

        [HttpGet("todos")]
        public async Task<IActionResult> SelecionarTodos()
        {
            var resultado = await _selecionarTodosHandler.Handle(
                new SelecionarTodosPlanosCobrancaRequest());

            return Ok(resultado);
        }
    }
}
