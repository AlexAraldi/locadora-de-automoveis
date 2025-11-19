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

    public async Task Adicionar(GrupoAutomovel grupo)
    {
        await _context.GruposAutomovel.AddAsync(grupo);
        await _context.SaveChangesAsync();
    }

    public async Task Editar(GrupoAutomovel grupo)
    {
        _context.GruposAutomovel.Update(grupo);
        await _context.SaveChangesAsync();
    }

    public async Task Excluir(GrupoAutomovel grupo)
    {
        _context.GruposAutomovel.Remove(grupo);
        await _context.SaveChangesAsync();
    }

    public async Task<GrupoAutomovel?> BuscarPorId(Guid id)
    {
        return await _context.GruposAutomovel.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<GrupoAutomovel?> BuscarPorNome(string nome)
    {
        return await _context.GruposAutomovel.FirstOrDefaultAsync(x => x.Nome == nome);
    }

    public async Task<List<GrupoAutomovel>> SelecionarTodos()
    {
        return await _context.GruposAutomovel.ToListAsync();
    }
}
