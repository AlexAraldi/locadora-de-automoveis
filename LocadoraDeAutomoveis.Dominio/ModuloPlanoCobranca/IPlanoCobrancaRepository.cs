namespace LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca;

public interface IPlanoCobrancaRepository
{
    Task Adicionar(PlanoCobranca plano);
    Task Atualizar(PlanoCobranca plano);
    Task Excluir(PlanoCobranca plano);
    Task<PlanoCobranca?> BuscarPorId(Guid id);
    Task<List<PlanoCobranca>> SelecionarTodos();
    Task<List<PlanoCobranca>> SelecionarPorGrupo(Guid grupoAutomovelId);
    Task<PlanoCobranca?> BuscarDuplicado(Guid grupoId, TipoPlano tipoPlano);
}
