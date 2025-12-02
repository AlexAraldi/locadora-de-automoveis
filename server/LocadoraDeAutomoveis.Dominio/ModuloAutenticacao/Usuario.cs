using LocadoraDeAutomoveis.Dominio.Compartilhado;
using Microsoft.AspNetCore.Identity;

namespace LocadoraDeAutomoveis.Dominio.ModuloAutenticacao
{
    public class Usuario : IdentityUser<Guid>
    {
        public Usuario()
        {
            Id = Guid.NewGuid();
            EmailConfirmed = true;
        }
              
    }
}
