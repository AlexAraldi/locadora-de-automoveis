using LocadoraDeAutomoveis.Dominio.ModuloFuncionario;

namespace LocadoraDeAutomoveis.Dominio.ModuloFuncionario
{
    public interface IFuncionarioRepository
    {
        Task AdicionarAsync(Funcionario funcionario);
        Task AtualizarAsync(Funcionario funcionario);
        Task ExcluirAsync(Funcionario funcionario);

        Task<Funcionario?> SelecionarPorIdAsync(Guid id);
        Task<Funcionario?> BuscarPorEmailAsync(string email);
        Task<List<Funcionario>> SelecionarTodosAsync();
    }
}
