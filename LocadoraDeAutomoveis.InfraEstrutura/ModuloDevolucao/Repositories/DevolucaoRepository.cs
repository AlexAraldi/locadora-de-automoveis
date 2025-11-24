using LocadoraDeAutomoveis.Dominio.ModuloDevolucao;
using LocadoraDeAutomoveis.Infraestrutura.DataBase;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeAutomoveis.InfraEstrutura.ModuloDevolucao.Repositories
{
    public class DevolucaoRepository : IDevolucaoRepository
    {
        private readonly LocadoraDbContext _context;

        public DevolucaoRepository(LocadoraDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(Devolucao devolucao)
        {
            _context.Devolucoes.Add(devolucao);
            await _context.SaveChangesAsync();
        }

        public async Task<Devolucao?> SelecionarPorIdAsync(Guid id)
        {
            return await _context.Devolucoes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Devolucao>> SelecionarTodosAsync()
        {
            return await _context.Devolucoes.ToListAsync();
        }
    }
}
