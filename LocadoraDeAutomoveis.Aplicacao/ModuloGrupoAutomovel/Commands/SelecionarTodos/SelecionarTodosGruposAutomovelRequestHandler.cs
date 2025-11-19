using LocadoraDeAutomoveis.Dominio.ModuloGrupoAutomovel;
using LocadoraDeAutomoveis.Aplicacao.ModuloGrupoAutomovel.DTOs;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloGrupoAutomovel.Commands.SelecionarTodos;

public class SelecionarTodosGruposAutomovelRequestHandler
{
    private readonly IGrupoAutomovelRepository _repository;

    public SelecionarTodosGruposAutomovelRequestHandler(IGrupoAutomovelRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<GrupoAutomovelDto>> Handle(SelecionarTodosGruposAutomovelRequest request)
    {
        var lista = await _repository.SelecionarTodos();

        return lista.Select(g => new GrupoAutomovelDto
        {
            Id = g.Id,
            Nome = g.Nome
        });
    }
}
