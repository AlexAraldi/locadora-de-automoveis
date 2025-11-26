using FluentValidation;
using LocadoraDeAutomoveis.Aplicacao.ModuloAutenticacao.DTOs;
using LocadoraDeAutomoveis.Aplicacao.ModuloAutenticacao.Service;
using LocadoraDeAutomoveis.InfraEstrutura.ModuloAutenticacao.Repositories;
using MediatR;
using BC = BCrypt.Net.BCrypt;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloAutenticacao.Commands.Autenticar
{
    public class AutenticarUsuarioRequestHandler : IRequestHandler< AutenticarUsuarioRequest, object>
    {
        private readonly UsuarioRepository _repository;
        private readonly JwtService _jwtService;
        private readonly IValidator<AutenticarUsuarioRequest> _validator;

        public AutenticarUsuarioRequestHandler(
            UsuarioRepository repository,
            JwtService jwtService,
            IValidator<AutenticarUsuarioRequest> validator)
        {
            _repository = repository;
            _jwtService = jwtService;
            _validator = validator;
        }

        public async Task<object> Handle(AutenticarUsuarioRequest request,CancellationToken cancellationToken)
        {
            var validation = await _validator.ValidateAsync(request);

            if (!validation.IsValid)
                return validation.Errors.Select(x => x.ErrorMessage);

            var usuario = await _repository.BuscarPorEmail(request.Email);

            if (usuario == null)
                return AutenticacaoErrorResults.UsuarioNaoEncontrado;

            if (!BC.Verify(request.Senha, usuario.SenhaHash))
                return AutenticacaoErrorResults.CredenciaisInvalidas;

            var token = _jwtService.GerarToken(usuario);

            var usuarioDto = new UsuarioAutenticadoDto
            {
                Id = usuario.Id,
                UserName = usuario.Nome,
                Email = usuario.Email
            };

            return new
            {
                Token = token,
                Usuario = usuarioDto
            };
        }
    }
}
