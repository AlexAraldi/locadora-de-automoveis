using LocadoraDeAutomoveis.Dominio.ModuloConfiguracao;
using LocadoraDeAutomoveis.Infraestrutura.DataBase;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeAutomoveis.InfraEstrutura.ModuloConfiguracao.Repositories
{
    public class ConfiguracaoRepository : IConfiguracaoRepository
    {
        private readonly LocadoraDbContext _context;

        public ConfiguracaoRepository(LocadoraDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(Configuracao configuracao)
        {
            await _context.Configuracoes.AddAsync(configuracao);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> EditarAsync(Configuracao configuracao)
        {
            var existente = await _context.Configuracoes.FirstOrDefaultAsync();
            if (existente == null)
                return false;

            existente.PrecoGasolina = configuracao.PrecoGasolina;
            existente.PrecoGas = configuracao.PrecoGas;
            existente.PrecoDiesel = configuracao.PrecoDiesel;
            existente.PrecoAlcool = configuracao.PrecoAlcool;

            _context.Configuracoes.Update(existente);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Configuracao?> SelecionarAsync(Guid id)
        {
            return await _context.Configuracoes.AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
