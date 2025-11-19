using LocadoraDeAutomoveis.Aplicacao.ModuloAutenticacao.Commands.Autenticar;
using LocadoraDeAutomoveis.Aplicacao.ModuloAutenticacao.Commands.Registrar;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraAutomoveis.WebApi.Controllers
{
    [ApiController]
    [Route("api/autenticacao")]
    public class AutenticacaoController : ControllerBase
    {
        private readonly AutenticarUsuarioRequestHandler _handler;

        public AutenticacaoController(AutenticarUsuarioRequestHandler handler)
        {
            _handler = handler;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(AutenticarUsuarioRequest request)
        {
            var response = await _handler.Handle(request);
            return Ok(response);
        }


        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar([FromBody] RegistrarUsuarioRequest request)
        {
            var handler = HttpContext.RequestServices.GetRequiredService<RegistrarUsuarioRequestHandler>();
            var resposta = await handler.Handle(request);

            return Ok(resposta);
        }
    }
}
