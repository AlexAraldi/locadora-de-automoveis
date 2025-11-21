namespace LocadoraDeAutomoveis.Dominio.ModuloAluguel;

public interface IAluguelRepository
{
    Task Adicionar(Aluguel aluguel);
    Task Atualizar(Aluguel aluguel);
    Task Excluir(Aluguel aluguel);
    Task<Aluguel?> SelecionarPorId(Guid id);
    Task<List<Aluguel>> SelecionarTodos();

    Task<List<Aluguel>> SelecionarPorCliente(Guid clienteId);

    Task<bool> VeiculoEstaAlugado(Guid veiculoId);
}
