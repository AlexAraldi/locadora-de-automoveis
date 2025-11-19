namespace LocadoraDeAutomoveis.Aplicacao.ModuloAutenticacao.DTOs
{
    public class UsuarioAutenticadoDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = "";
        public string Email { get; set; } = "";
    }
}
