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

        // 🔥 ESSA PROPRIEDADE É OBRIGATÓRIA PARA MULTITENANCY
        public Guid EmpresaId { get; set; }
    }
}
