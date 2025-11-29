namespace LocadoraDeAutomoveis.Dominio.ModuloConfiguracao
{
    public interface IConfiguracaoRepository
    {
        Task<Configuracao> SelecionarAsync();
        Task AdicionarAsync(Configuracao configuracao);
        Task<bool> EditarAsync(Configuracao configuracao);
    }
}
