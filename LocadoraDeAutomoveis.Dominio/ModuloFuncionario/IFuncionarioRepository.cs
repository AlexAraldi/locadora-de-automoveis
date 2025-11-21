using LocadoraDeAutomoveis.Dominio.ModuloFuncionario;

namespace LocadoraDeAutomoveis.Dominio.ModuloFuncionario
{
    public interface IFuncionarioRepository
    {
        Task Adicionar(Funcionario funcionario);
        Task Atualizar(Funcionario funcionario);
        Task Excluir(Funcionario funcionario);

        Task<Funcionario?> SelecionarPorId(Guid id);
        Task<Funcionario?> BuscarPorEmail(string email);
        Task<List<Funcionario>> SelecionarTodos();
    }
}
