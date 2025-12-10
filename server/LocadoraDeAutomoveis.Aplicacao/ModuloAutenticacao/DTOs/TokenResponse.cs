using LocadoraDeAutomoveis.Dominio.ModuloAutenticacao;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloAutenticacao.DTOs
{
    public record AccessToken(
        string Chave,
        DateTime Expiracao,
        UsuarioAutenticado UsuarioAutenticado
    );

    public record UsuarioAutenticado(
        Guid Id,
        string Email,
        RoleUsuario Cargo
    );
}
