using LocadoraDeAutomoveis.Dominio.ModuloCondutor;
using LocadoraDeAutomoveis.Infraestrutura.DataBase;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeAutomoveis.InfraEstrutura.ModuloCondutor.Repositories;

public class CondutorRepository : ICondutorRepository
{
    private readonly LocadoraDbContext _context;

    public CondutorRepository(LocadoraDbContext context)
    {
        _context = context;
    }

    public async Task AdicionarAsync(Condutor condutor)
    {
        await _context.Condutores.AddAsync(condutor);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarAsync(Condutor condutor)
    {
        _context.Condutores.Update(condutor);
        await _context.SaveChangesAsync();
    }

    public async Task ExcluirAsync(Condutor condutor)
    {
        _context.Condutores.Remove(condutor);
        await _context.SaveChangesAsync();
    }

    public async Task<Condutor?> SelecionarPorIdAsync(Guid id)
    {
        return await _context.Condutores.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Condutor?> BuscarPorCpfAsync(string cpf)
    {
        return await _context.Condutores.FirstOrDefaultAsync(x => x.Cpf == cpf);
    }

    public async Task<List<Condutor>> SelecionarTodosAsync()
    {
        return await _context.Condutores.ToListAsync();
    }

    public async Task<List<Condutor>> SelecionarPorClienteAsync(Guid clienteId)
    {
        return await _context.Condutores
            .Where(x => x.ClienteId == clienteId)
            .ToListAsync();
    }
}
