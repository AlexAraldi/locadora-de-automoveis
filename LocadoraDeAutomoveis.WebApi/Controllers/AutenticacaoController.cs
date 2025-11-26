using LocadoraDeAutomoveis.Aplicacao.ModuloAutenticacao.Commands.Autenticar;
using LocadoraDeAutomoveis.Aplicacao.ModuloAutenticacao.Commands.Registrar;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraAutomoveis.WebApi.Controllers
{
    [ApiController]
    [Route("api/autenticacao")]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AutenticacaoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(AutenticarUsuarioRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }


        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar([FromBody] RegistrarUsuarioRequest request)
        {
            var handler = HttpContext.RequestServices.GetRequiredService<RegistrarUsuarioRequestHandler>();
            var resposta = await _mediator.Send(request);

            return Ok(resposta);
        }
    }
}
