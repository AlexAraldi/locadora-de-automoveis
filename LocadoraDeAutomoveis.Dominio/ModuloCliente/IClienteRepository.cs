namespace LocadoraDeAutomoveis.Dominio.ModuloCliente
{
    public interface IClienteRepository
    {
        Task AdicionarAsync(Cliente cliente);
        Task AtualizarAsync(Cliente cliente);
        Task ExcluirAsync(Cliente cliente);

        Task<Cliente?> SelecionarPorIdAsync(Guid id);
        Task<Cliente?> BuscarPorCpfAsync(string cpf);
        Task<Cliente?> BuscarPorCnpjAsync(string cnpj);
        Task<List<Cliente>> SelecionarTodosAsync();
    }
}
