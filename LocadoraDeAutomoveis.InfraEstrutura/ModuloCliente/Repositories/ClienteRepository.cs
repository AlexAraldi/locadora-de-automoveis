using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using LocadoraDeAutomoveis.Infraestrutura.DataBase;
using LocadoraDeAutomoveis.InfraEstrutura.DataBase;
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

        public async Task Adicionar(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task Excluir(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<Cliente?> SelecionarPorId(Guid id)
        {
            return await _context.Clientes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Cliente?> BuscarPorCpf(string cpf)
        {
            return await _context.Clientes.FirstOrDefaultAsync(x => x.Cpf == cpf);
        }

        public async Task<Cliente?> BuscarPorCnpj(string cnpj)
        {
            return await _context.Clientes.FirstOrDefaultAsync(x => x.Cnpj == cnpj);
        }

        public async Task<List<Cliente>> SelecionarTodos()
        {
            return await _context.Clientes
                .OrderBy(x => x.Nome)
                .ToListAsync();
        }
    }
}
