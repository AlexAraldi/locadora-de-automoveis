using LocadoraDeAutomoveis.Dominio.ModuloAutenticacao;
using System.Security.Claims;

public class IdentityTenantProvider(IHttpContextAccessor contextAccessor) : ITenantProvider
{
    public Guid? EmpresaId
    {
        get
        {
            var user = contextAccessor.HttpContext?.User;

            var empresaIdClaim = user?.FindFirst("EmpresaId")?.Value;

            if (Guid.TryParse(empresaIdClaim, out var empresaId))
                return empresaId;

            return null;
        }
    }

    public bool IsInRole(string role)
    {
        return contextAccessor.HttpContext?.User?.IsInRole(role) ?? false;
    }
}