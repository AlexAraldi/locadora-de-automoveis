namespace LocadoraDeAutomoveis.Dominio.ModuloCondutor;

public interface ICondutorRepository
{
    Task AdicionarAsync(Condutor condutor);
    Task AtualizarAsync(Condutor condutor);
    Task ExcluirAsync(Condutor condutor);
    Task<Condutor?> SelecionarPorIdAsync(Guid id);
    Task<List<Condutor>> SelecionarTodosAsync();
    Task<Condutor?> BuscarPorCpfAsync(string cpf);
    Task<List<Condutor>> SelecionarPorClienteAsync(Guid clienteId);
}
