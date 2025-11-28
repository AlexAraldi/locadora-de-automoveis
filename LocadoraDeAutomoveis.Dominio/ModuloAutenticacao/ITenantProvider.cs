using System;

namespace LocadoraDeAutomoveis.Dominio.ModuloAutenticacao
{
    public interface ITenantProvider
    {
        Guid? EmpresaId { get; }
        bool IsInRole(string role);
    }
}
