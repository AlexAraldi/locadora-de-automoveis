using LocadoraDeAutomoveis.Dominio.ModuloAluguel;
using LocadoraDeAutomoveis.Infraestrutura.DataBase;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeAutomoveis.InfraEstrutura.ModuloAluguel.Repositories;

public class AluguelRepository : IAluguelRepository
{
    private readonly LocadoraDbContext _context;

    public AluguelRepository(LocadoraDbContext context)
    {
        _context = context;
    }

    public async Task Adicionar(Aluguel aluguel)
    {
        await _context.Alugueis.AddAsync(aluguel);
        await _context.SaveChangesAsync();
    }

    public async Task Atualizar(Aluguel aluguel)
    {
        _context.Alugueis.Update(aluguel);
        await _context.SaveChangesAsync();
    }

    public async Task Excluir(Aluguel aluguel)
    {
        _context.Alugueis.Remove(aluguel);
        await _context.SaveChangesAsync();
    }

    public async Task<Aluguel?> SelecionarPorId(Guid id)
    {
        return await _context.Alugueis.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Aluguel>> SelecionarTodos()
    {
        return await _context.Alugueis.ToListAsync();
    }

    public async Task<List<Aluguel>> SelecionarPorCliente(Guid clienteId)
    {
        return await _context.Alugueis
            .Where(x => x.ClienteId == clienteId)
            .ToListAsync();
    }

    public async Task<bool> VeiculoEstaAlugado(Guid veiculoId)
    {
        return await _context.Alugueis
            .AnyAsync(x => x.VeiculoId == veiculoId && x.Situacao != SituacaoAluguel.Fechado);
    }
}
