using LocadoraDeAutomoveis.Dominio.ModuloConfiguracao;

namespace LocadoraDeAutomoveis.Dominio.ModuloConfiguracao;

public interface IConfiguracaoRepository
{
    Task<Configuracao?> SelecionarAsync();
    Task AdicionarAsync(Configuracao configuracao);
    Task EditarAsync(Configuracao configuracao);
}
