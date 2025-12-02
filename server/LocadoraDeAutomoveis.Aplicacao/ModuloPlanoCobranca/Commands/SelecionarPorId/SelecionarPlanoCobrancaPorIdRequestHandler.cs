using LocadoraDeAutomoveis.Aplicacao.ModuloPlanoCobranca.DTOs;
using LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca;
using MediatR;
namespace LocadoraDeAutomoveis.Aplicacao.ModuloPlanoCobranca.Commands.SelecionarPorId;

public class SelecionarPlanoCobrancaPorIdRequestHandler : IRequestHandler<SelecionarPlanoCobrancaPorIdRequest,object>
{
    private readonly IPlanoCobrancaRepository _repository;

    public SelecionarPlanoCobrancaPorIdRequestHandler(IPlanoCobrancaRepository repository)
    {
        _repository = repository;
    }

    public async Task<object> Handle(SelecionarPlanoCobrancaPorIdRequest request, CancellationToken cancellationToken)
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
