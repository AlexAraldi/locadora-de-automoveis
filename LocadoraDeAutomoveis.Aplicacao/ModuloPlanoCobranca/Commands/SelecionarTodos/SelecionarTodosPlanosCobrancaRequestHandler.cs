using LocadoraDeAutomoveis.Aplicacao.ModuloPlanoCobranca.DTOs;
using LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca;
using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloPlanoCobranca.Commands.SelecionarTodos;

public class SelecionarTodosPlanosCobrancaRequestHandler : IRequestHandler<SelecionarTodosPlanosCobrancaRequest, IEnumerable<PlanoCobrancaDto>>
{
    private readonly IPlanoCobrancaRepository _repository;

    public SelecionarTodosPlanosCobrancaRequestHandler(IPlanoCobrancaRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<PlanoCobrancaDto>> Handle(SelecionarTodosPlanosCobrancaRequest request, CancellationToken cancellationToken)
    {
        var planos = await _repository.SelecionarTodosAsync();

        return planos.Select(plano => new PlanoCobrancaDto
        {
            Id = plano.Id,
            GrupoAutomovelId = plano.GrupoAutomovelId,
            TipoPlano = plano.TipoPlano.ToString(),
            ValorDiaria = plano.ValorDiaria,
            ValorPorKm = plano.ValorPorKm,
            KmLivre = plano.KmLivre,
            KmControladoLimite = plano.KmControladoLimite,
            ValorExcedenteKm = plano.ValorExcedenteKm
        });
    }
}
