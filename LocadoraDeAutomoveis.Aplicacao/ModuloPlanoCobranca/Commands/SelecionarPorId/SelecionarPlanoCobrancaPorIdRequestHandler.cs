using LocadoraDeAutomoveis.Aplicacao.ModuloPlanoCobranca.DTOs;
using LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca;
namespace LocadoraDeAutomoveis.Aplicacao.ModuloPlanoCobranca.Commands.SelecionarPorId;

public class SelecionarPlanoCobrancaPorIdRequestHandler
{
    private readonly IPlanoCobrancaRepository _repository;

    public SelecionarPlanoCobrancaPorIdRequestHandler(IPlanoCobrancaRepository repository)
    {
        _repository = repository;
    }

    public async Task<object> Handle(SelecionarPlanoCobrancaPorIdRequest request)
    {
        var plano = await _repository.SelecionarPorIdAsync(request.Id);

        if (plano == null)
            return PlanoCobrancaErrorResults.PlanoNaoEncontrado;

        return new PlanoCobrancaDto
        {
            Id = plano.Id,
            GrupoAutomovelId = plano.GrupoAutomovelId,
            TipoPlano = plano.TipoPlano.ToString(),
            ValorDiaria = plano.ValorDiaria,
            ValorPorKm = plano.ValorPorKm,
            KmLivre = plano.KmLivre,
            KmControladoLimite = plano.KmControladoLimite,
            ValorExcedenteKm = plano.ValorExcedenteKm
        };
    }
}
