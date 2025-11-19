using LocadoraDeAutomoveis.Aplicacao.ModuloFuncionario.Commands.Criar;
using LocadoraDeAutomoveis.Aplicacao.ModuloFuncionario.Commands.Editar;
using LocadoraDeAutomoveis.Aplicacao.ModuloFuncionario.Commands.Excluir;
using LocadoraDeAutomoveis.Aplicacao.ModuloFuncionario.Commands.SelecionarPorId;
using LocadoraDeAutomoveis.Aplicacao.ModuloFuncionario.Commands.SelecionarTodos;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraDeAutomoveis.WebApi.Controllers
{
    [ApiController]
    [Route("api/funcionarios")]
    public class FuncionarioController : ControllerBase
    {
        private readonly CriarFuncionarioRequestHandler _criarHandler;
        private readonly EditarFuncionarioRequestHandler _editarHandler;
        private readonly ExcluirFuncionarioRequestHandler _excluirHandler;
        private readonly SelecionarFuncionarioPorIdRequestHandler _selecionarPorIdHandler;
        private readonly SelecionarTodosFuncionariosRequestHandler _selecionarTodosHandler;

        public FuncionarioController(
            CriarFuncionarioRequestHandler criarHandler,
            EditarFuncionarioRequestHandler editarHandler,
            ExcluirFuncionarioRequestHandler excluirHandler,
            SelecionarFuncionarioPorIdRequestHandler selecionarPorIdHandler,
            SelecionarTodosFuncionariosRequestHandler selecionarTodosHandler
        )
        {
            _criarHandler = criarHandler;
            _editarHandler = editarHandler;
            _excluirHandler = excluirHandler;
            _selecionarPorIdHandler = selecionarPorIdHandler;
            _selecionarTodosHandler = selecionarTodosHandler;
        }

        // POST: Criar funcionário
        [HttpPost("criar")]
        public async Task<IActionResult> Criar([FromBody] CriarFuncionarioRequest request)
        {
            var resultado = await _criarHandler.Handle(request);

            if (resultado is string msgErro && msgErro.Contains("não"))
                return BadRequest(msgErro);

            return Ok(resultado);
        }

        // PUT: Editar funcionário
        [HttpPut("editar")]
        public async Task<IActionResult> Editar([FromBody] EditarFuncionarioRequest request)
        {
            var resultado = await _editarHandler.Handle(request);

            if (resultado is string erro && erro.Contains("não encontrado"))
                return NotFound(erro);

            if (resultado is IEnumerable<string> errosValidacao)
                return BadRequest(errosValidacao);

            return Ok(resultado);
        }

        // DELETE: Excluir funcionário
        [HttpDelete("excluir/{id}")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            var resultado = await _excluirHandler.Handle(new ExcluirFuncionarioRequest { Id = id });

            if (resultado is string erro && erro.Contains("não encontrado"))
                return NotFound(erro);

            return Ok(resultado);
        }

        // GET: Selecionar funcionário por Id
        [HttpGet("{id}")]
        public async Task<IActionResult> SelecionarPorId(Guid id)
        {
            var resultado = await _selecionarPorIdHandler.Handle(new SelecionarFuncionarioPorIdRequest { Id = id });

            if (resultado is string erro && erro.Contains("não encontrado"))
                return NotFound(erro);

            return Ok(resultado);
        }

        // GET: Selecionar todos
        [HttpGet]
        public async Task<IActionResult> SelecionarTodos()
        {
            var resultado = await _selecionarTodosHandler.Handle();
            return Ok(resultado);
        }
    }
}
