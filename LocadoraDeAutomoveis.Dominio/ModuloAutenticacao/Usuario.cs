namespace LocadoraDeAutomoveis.Dominio.ModuloAutenticacao
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string SenhaHash { get; set; } = string.Empty;
        public RoleUsuario Role { get; set; }

        public Usuario() { }

        public Usuario(string nome, string email, string senhaHash, RoleUsuario role)
        {
            Nome = nome;
            Email = email;
            SenhaHash = senhaHash;
            Role = role;
        }
    }
}
