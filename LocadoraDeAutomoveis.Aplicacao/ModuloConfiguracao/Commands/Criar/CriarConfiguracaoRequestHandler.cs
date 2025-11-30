using LocadoraDeAutomoveis.Dominio.ModuloAutenticacao;
using LocadoraDeAutomoveis.Dominio.ModuloConfiguracao;
using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloConfiguracao.Commands.Criar;

public class CriarConfiguracaoRequestHandler : IRequestHandler<CriarConfiguracaoRequest, object>
{
    private readonly IConfiguracaoRepository _repository;
    private readonly ITenantProvider _tenantProvider;

    public CriarConfiguracaoRequestHandler(
        IConfiguracaoRepository repository,
        ITenantProvider tenantProvider)
    {
        _repository = repository;
        _tenantProvider = tenantProvider;
    }

    public async Task<object> Handle(CriarConfiguracaoRequest request, CancellationToken cancellationToken)
    {
        var existente = await _repository.SelecionarAsync();
        if (existente != null)
            return ConfiguracaoErrorResults.ConfiguracaoJaExiste;

        var nova = new Configuracao
        {
            PrecoGasolina = request.PrecoGasolina,
            PrecoGas = request.PrecoGas,
            PrecoAlcool = request.PrecoAlcool,
            PrecoDiesel = request.PrecoDiesel,
            EmpresaId = _tenantProvider.EmpresaId.GetValueOrDefault() 
        };


        await _repository.AdicionarAsync(nova);

        return new
        {
            Mensagem = "Configuração criada com sucesso.",
            Id = nova.Id
        };
    }
}
