namespace LocadoraDeAutomoveis.Dominio.ModuloAluguel;

public interface IAluguelRepository
{
    Task AdicionarAsync(Aluguel aluguel);
    Task AtualizarAsync(Aluguel aluguel);
    Task ExcluirAsync(Aluguel aluguel);
    Task<Aluguel?> SelecionarPorIdAsync(Guid id);
    Task<List<Aluguel>> SelecionarTodosAsync();

    Task<List<Aluguel>> SelecionarPorClienteAsync(Guid clienteId);

    Task<bool> VeiculoEstaAlugadoAsync(Guid veiculoId);
}