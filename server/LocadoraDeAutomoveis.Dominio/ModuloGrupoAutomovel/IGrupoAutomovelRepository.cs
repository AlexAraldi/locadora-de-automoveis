namespace LocadoraDeAutomoveis.Dominio.ModuloGrupoAutomovel;

public interface IGrupoAutomovelRepository
{
    Task AdicionarAsync(GrupoAutomovel grupo);
    Task EditarAsync(GrupoAutomovel grupo);
    Task ExcluirAsync(GrupoAutomovel grupo);
    Task<GrupoAutomovel?> SelecionarPorIdAsync(Guid id);
    Task<GrupoAutomovel?> BuscarPorNomeAsync(string nome);
    Task<List<GrupoAutomovel>> SelecionarTodosAsync();
}
