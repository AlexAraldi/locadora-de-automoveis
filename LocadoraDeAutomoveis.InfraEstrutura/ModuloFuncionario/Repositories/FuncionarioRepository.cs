using LocadoraDeAutomoveis.Dominio.ModuloFuncionario;
using Microsoft.EntityFrameworkCore;
using LocadoraDeAutomoveis.Infraestrutura.DataBase;

namespace LocadoraDeAutomoveis.InfraEstrutura.ModuloFuncionario.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly LocadoraDbContext _context;

        public FuncionarioRepository(LocadoraDbContext context)
        {
            _context = context;
        }

        public async Task Adicionar(Funcionario funcionario)
        {
            await _context.Funcionarios.AddAsync(funcionario);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(Funcionario funcionario)
        {
            _context.Funcionarios.Update(funcionario);
            await _context.SaveChangesAsync();
        }

        public async Task Excluir(Funcionario funcionario)
        {
            _context.Funcionarios.Remove(funcionario);
            await _context.SaveChangesAsync();
        }

        public async Task<Funcionario?> SelecionarPorId(Guid id)
        {
            return await _context.Funcionarios
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Funcionario?> BuscarPorEmail(string email)
        {
            return await _context.Funcionarios
                .FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<List<Funcionario>> SelecionarTodos()
        {
            return await _context.Funcionarios
                .OrderBy(x => x.Nome)
                .ToListAsync();
        }
    }
}
