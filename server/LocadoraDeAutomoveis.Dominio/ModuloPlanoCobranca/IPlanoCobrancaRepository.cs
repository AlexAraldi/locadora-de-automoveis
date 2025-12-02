namespace LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca;

public interface IPlanoCobrancaRepository
{
    Task AdicionarAsync(PlanoCobranca plano);
    Task AtualizarAsync(PlanoCobranca plano);
    Task ExcluirAsync(PlanoCobranca plano);
    Task<PlanoCobranca?> SelecionarPorIdAsync(Guid id);
    Task<List<PlanoCobranca>> SelecionarTodosAsync();
    Task<List<PlanoCobranca>> SelecionarPorGrupoAsync(Guid grupoAutomovelId);
    Task<PlanoCobranca?> BuscarDuplicadoAsync(Guid grupoId, TipoPlano tipoPlano);
}
