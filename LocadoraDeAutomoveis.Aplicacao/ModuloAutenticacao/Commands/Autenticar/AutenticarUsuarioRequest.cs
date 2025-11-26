using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloAutenticacao.Commands.Autenticar
{
    public class AutenticarUsuarioRequest : IRequest <object>
    {
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
    }
}
