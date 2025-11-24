using LocadoraDeAutomoveis.Dominio.ModuloTaxaServico;
using LocadoraDeAutomoveis.Infraestrutura.Database;
using LocadoraDeAutomoveis.Infraestrutura.DataBase;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeAutomoveis.Infraestrutura.ModuloTaxaServico.Repositories;

public class TaxaServicoRepository : ITaxaServicoRepository
{
    private readonly LocadoraDbContext _dbContext;

    public TaxaServicoRepository(LocadoraDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AdicionarAsync(TaxaServico taxa)
    {
        await _dbContext.TaxasServico.AddAsync(taxa);
        await _dbContext.SaveChangesAsync();
    }

    public async Task AtualizarAsync(TaxaServico taxa)
    {
        _dbContext.TaxasServico.Update(taxa);
        await _dbContext.SaveChangesAsync();
    }

    public async Task ExcluirAsync(TaxaServico taxa)
    {
        _dbContext.TaxasServico.Remove(taxa);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<TaxaServico?> SelecionarPorIdAsync(Guid id)
    {
        return await _dbContext.TaxasServico
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<TaxaServico>> SelecionarTodosAsync()
    {
        return await _dbContext.TaxasServico
            .OrderBy(x => x.Nome)
            .ToListAsync();
    }

    public async Task<bool> NomeDuplicadoAsync(string nome)
    {
        return await _dbContext.TaxasServico
            .AnyAsync(x => x.Nome.ToLower() == nome.ToLower());
    }
}
