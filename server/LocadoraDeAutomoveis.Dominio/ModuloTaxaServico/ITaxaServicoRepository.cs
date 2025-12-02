namespace LocadoraDeAutomoveis.Dominio.ModuloTaxaServico
{
    public interface ITaxaServicoRepository
    {
        Task AdicionarAsync(TaxaServico taxaServico);
        Task AtualizarAsync(TaxaServico taxaServico);
        Task ExcluirAsync(TaxaServico taxaServico);

        Task<TaxaServico?> SelecionarPorIdAsync(Guid id);
        Task<List<TaxaServico>> SelecionarTodosAsync();
    }
}
