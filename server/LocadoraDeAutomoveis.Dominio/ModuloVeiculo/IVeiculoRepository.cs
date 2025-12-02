namespace LocadoraDeAutomoveis.Dominio.ModuloVeiculo;

public interface IVeiculoRepository
{
    Task AdicionarAsync(Veiculo veiculo);
    Task EditarAsync(Veiculo veiculo);
    Task ExcluirAsync(Veiculo veiculo);
    Task<Veiculo?> SelecionarPorIdAsync(Guid id);
    Task<List<Veiculo>> SelecionarTodosAsync();
}
