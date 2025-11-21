namespace LocadoraDeAutomoveis.Dominio.ModuloCondutor;

public interface ICondutorRepository
{
    Task Adicionar(Condutor condutor);
    Task Atualizar(Condutor condutor);
    Task Excluir(Condutor condutor);
    Task<Condutor?> SelecionarPorId(Guid id);
    Task<List<Condutor>> SelecionarTodos();
    Task<Condutor?> BuscarPorCpf(string cpf);
    Task<List<Condutor>> SelecionarPorCliente(Guid clienteId);
}
