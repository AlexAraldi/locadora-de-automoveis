using LocadoraDeAutomoveis.Dominio.ModuloConfiguracao;
using LocadoraDeAutomoveis.Infraestrutura.DataBase;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeAutomoveis.InfraEstrutura.ModuloConfiguracao.Repositories;

public class ConfiguracaoRepository : IConfiguracaoRepository
{
    private readonly LocadoraDbContext _context;

    public ConfiguracaoRepository(LocadoraDbContext context)
    {
        _context = context;
    }

    public async Task<Configuracao?> SelecionarAsync()
    {
        return await _context.Configuracoes.FirstOrDefaultAsync();
    }

    public async Task AdicionarAsync(Configuracao configuracao)
    {
        await _context.Configuracoes.AddAsync(configuracao);
        await _context.SaveChangesAsync();
    }

    public async Task EditarAsync(Configuracao configuracao)
    {
        _context.Configuracoes.Update(configuracao);
        await _context.SaveChangesAsync();
    }
}
