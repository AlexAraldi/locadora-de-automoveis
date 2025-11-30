using LocadoraDeAutomoveis.Aplicacao.ModuloConfiguracao.DTOs;
using LocadoraDeAutomoveis.Dominio.ModuloConfiguracao;
using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloConfiguracao.Commands.Selecionar;

public class SelecionarConfiguracaoRequestHandler : IRequestHandler<SelecionarConfiguracaoRequest, object>
{
    private readonly IConfiguracaoRepository _repository;

    public SelecionarConfiguracaoRequestHandler(IConfiguracaoRepository repository)
    {
        _repository = repository;
    }

    public async Task<object> Handle(SelecionarConfiguracaoRequest request, CancellationToken cancellationToken)
    {
        var config = await _repository.SelecionarAsync();
        if (config == null)
            return ConfiguracaoErrorResults.ConfiguracaoNaoEncontrada;

        return new ConfiguracaoDto
        {
            Id = config.Id,
            PrecoGasolina = config.PrecoGasolina,
            PrecoGas = config.PrecoGas,
            PrecoDiesel = config.PrecoDiesel,
            PrecoAlcool = config.PrecoAlcool
        };
    }
}
