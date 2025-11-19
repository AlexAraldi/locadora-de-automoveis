namespace LocadoraDeAutomoveis.Dominio.ModuloCliente
{
    public interface IClienteRepository
    {
        Task Adicionar(Cliente cliente);
        Task Atualizar(Cliente cliente);
        Task Excluir(Cliente cliente);

        Task<Cliente?> BuscarPorId(Guid id);
        Task<Cliente?> BuscarPorCpf(string cpf);
        Task<Cliente?> BuscarPorCnpj(string cnpj);
        Task<List<Cliente>> SelecionarTodos();
    }
}
