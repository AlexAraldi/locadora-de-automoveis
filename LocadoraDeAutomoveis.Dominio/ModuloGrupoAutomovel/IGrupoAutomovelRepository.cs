namespace LocadoraDeAutomoveis.Dominio.ModuloGrupoAutomovel;

public interface IGrupoAutomovelRepository
{
    Task Adicionar(GrupoAutomovel grupo);
    Task Editar(GrupoAutomovel grupo);
    Task Excluir(GrupoAutomovel grupo);
    Task<GrupoAutomovel?> BuscarPorId(Guid id);
    Task<GrupoAutomovel?> BuscarPorNome(string nome);
    Task<List<GrupoAutomovel>> SelecionarTodos();
}
