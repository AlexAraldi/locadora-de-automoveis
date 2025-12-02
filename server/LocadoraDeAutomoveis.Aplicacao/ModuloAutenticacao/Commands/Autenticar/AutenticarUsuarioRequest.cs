using FluentResults;
using LocadoraDeAutomoveis.Aplicacao.ModuloAutenticacao.DTOs;
using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloAutenticacao.Commands.Autenticar
{
    public record AutenticarUsuarioRequest : IRequest<object>
    {
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
    }
}
