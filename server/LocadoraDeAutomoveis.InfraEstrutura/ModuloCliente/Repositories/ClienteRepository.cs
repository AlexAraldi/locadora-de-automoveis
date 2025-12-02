using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using LocadoraDeAutomoveis.Infraestrutura.DataBase;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeAutomoveis.InfraEstrutura.ModuloCliente.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly LocadoraDbContext _context;

        public ClienteRepository(LocadoraDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirAsync(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<Cliente?> SelecionarPorIdAsync(Guid id)
        {
            return await _context.Clientes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Cliente?> BuscarPorCpfAsync(string cpf)
        {
            return await _context.Clientes.FirstOrDefaultAsync(x => x.Cpf == cpf);
        }

        public async Task<Cliente?> BuscarPorCnpjAsync(string cnpj)
        {
            return await _context.Clientes.FirstOrDefaultAsync(x => x.Cnpj == cnpj);
        }

        public async Task<List<Cliente>> SelecionarTodosAsync()
        {
            return await _context.Clientes
                .OrderBy(x => x.Nome)
                .ToListAsync();
        }
    }
}
