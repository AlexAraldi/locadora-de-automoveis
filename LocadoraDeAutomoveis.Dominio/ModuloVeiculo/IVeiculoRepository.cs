namespace LocadoraDeAutomoveis.Dominio.ModuloVeiculo;

public interface IVeiculoRepository
{
    Task Adicionar(Veiculo veiculo);
    Task Editar(Veiculo veiculo);
    Task Excluir(Veiculo veiculo);
    Task<Veiculo?> SelecionarPorId(Guid id);
    Task<List<Veiculo>> SelecionarTodos();
}
