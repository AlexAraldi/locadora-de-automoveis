using LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca;
using LocadoraDeAutomoveis.Infraestrutura.DataBase;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeAutomoveis.InfraEstrutura.ModuloPlanoCobranca.Repositories;

public class PlanoCobrancaRepository : IPlanoCobrancaRepository
{
    private readonly LocadoraDbContext _context;

    public PlanoCobrancaRepository(LocadoraDbContext context)
    {
        _context = context;
    }

    public async Task Adicionar(PlanoCobranca plano)
    {
        await _context.PlanosCobranca.AddAsync(plano);
        await _context.SaveChangesAsync();
    }

    public async Task Atualizar(PlanoCobranca plano)
    {
        _context.PlanosCobranca.Update(plano);
        await _context.SaveChangesAsync();
    }

    public async Task Excluir(PlanoCobranca plano)
    {
        _context.PlanosCobranca.Remove(plano);
        await _context.SaveChangesAsync();
    }

    public async Task<PlanoCobranca?> BuscarPorId(Guid id)
    {
        return await _context.PlanosCobranca.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<PlanoCobranca>> SelecionarTodos()
    {
        return await _context.PlanosCobranca.ToListAsync();
    }

    public async Task<List<PlanoCobranca>> SelecionarPorGrupo(Guid grupoAutomovelId)
    {
        return await _context.PlanosCobranca
            .Where(x => x.GrupoAutomovelId == grupoAutomovelId)
            .ToListAsync();
    }

    public async Task<PlanoCobranca?> BuscarDuplicado(Guid grupoId, TipoPlano tipoPlano)
    {
        return await _context.PlanosCobranca
            .FirstOrDefaultAsync(x => x.GrupoAutomovelId == grupoId && x.TipoPlano == tipoPlano);
    }
}
