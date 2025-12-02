using LocadoraDeAutomoveis.Dominio.ModuloGrupoAutomovel;
using LocadoraDeAutomoveis.Infraestrutura.DataBase;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeAutomoveis.InfraEstrutura.ModuloGrupoAutomovel.Repositories;

public class GrupoAutomovelRepository : IGrupoAutomovelRepository
{
    private readonly LocadoraDbContext _context;

    public GrupoAutomovelRepository(LocadoraDbContext context)
    {
        _context = context;
    }

    public async Task AdicionarAsync(GrupoAutomovel grupo)
    {
        await _context.GruposAutomovel.AddAsync(grupo);
        await _context.SaveChangesAsync();
    }

    public async Task EditarAsync(GrupoAutomovel grupo)
    {
        _context.GruposAutomovel.Update(grupo);
        await _context.SaveChangesAsync();
    }

    public async Task ExcluirAsync(GrupoAutomovel grupo)
    {
        _context.GruposAutomovel.Remove(grupo);
        await _context.SaveChangesAsync();
    }

    public async Task<GrupoAutomovel?> SelecionarPorIdAsync(Guid id)
    {
        return await _context.GruposAutomovel.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<GrupoAutomovel?> BuscarPorNomeAsync(string nome)
    {
        return await _context.GruposAutomovel.FirstOrDefaultAsync(x => x.Nome == nome);
    }

    public async Task<List<GrupoAutomovel>> SelecionarTodosAsync()
    {
        return await _context.GruposAutomovel.ToListAsync();
    }
}
