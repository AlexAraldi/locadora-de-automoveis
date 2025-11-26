using LocadoraDeAutomoveis.Dominio.ModuloGrupoAutomovel;
using LocadoraDeAutomoveis.Aplicacao.ModuloGrupoAutomovel.DTOs;
using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloGrupoAutomovel.Commands.SelecionarTodos;

public class SelecionarTodosGruposAutomovelRequestHandler : IRequestHandler<SelecionarTodosGruposAutomovelRequest, IEnumerable<GrupoAutomovelDto>>
{
    private readonly IGrupoAutomovelRepository _repository;

    public SelecionarTodosGruposAutomovelRequestHandler(IGrupoAutomovelRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<GrupoAutomovelDto>> Handle(SelecionarTodosGruposAutomovelRequest request, CancellationToken cancellationToken)
    {
        var lista = await _repository.SelecionarTodosAsync();

        return lista.Select(g => new GrupoAutomovelDto
        {
            Id = g.Id,
            Nome = g.Nome
        });
    }
}
