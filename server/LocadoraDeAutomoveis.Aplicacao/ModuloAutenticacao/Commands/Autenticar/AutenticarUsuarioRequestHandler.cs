using FluentValidation;
using LocadoraDeAutomoveis.Aplicacao.ModuloAutenticacao.DTOs;
using LocadoraDeAutomoveis.Aplicacao.ModuloAutenticacao.Service;
using LocadoraDeAutomoveis.InfraEstrutura.ModuloAutenticacao.Repositories;
using MediatR;

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

            var token = await _jwtService.GerarToken(usuario);
            return token;            
        }
    }
}
