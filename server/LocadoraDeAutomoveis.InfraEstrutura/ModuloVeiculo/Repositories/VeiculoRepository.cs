using LocadoraDeAutomoveis.Dominio.ModuloVeiculo;
using LocadoraDeAutomoveis.Infraestrutura.DataBase;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeAutomoveis.InfraEstrutura.ModuloVeiculo.Repositories;

public class VeiculoRepository : IVeiculoRepository
{
    private readonly LocadoraDbContext _context;

    public VeiculoRepository(LocadoraDbContext context)
    {
        _context = context;
    }

    public async Task AdicionarAsync(Veiculo veiculo)
    {
        await _context.Veiculos.AddAsync(veiculo);
        await _context.SaveChangesAsync();
    }

    public async Task EditarAsync(Veiculo veiculo)
    {
        _context.Veiculos.Update(veiculo);
        await _context.SaveChangesAsync();
    }

    public async Task ExcluirAsync(Veiculo veiculo)
    {
        _context.Veiculos.Remove(veiculo);
        await _context.SaveChangesAsync();
    }

    public async Task<Veiculo?> SelecionarPorIdAsync(Guid id)
    {
        return await _context.Veiculos.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Veiculo>> SelecionarTodosAsync()
    {
        return await _context.Veiculos.ToListAsync();
    }

   
}
