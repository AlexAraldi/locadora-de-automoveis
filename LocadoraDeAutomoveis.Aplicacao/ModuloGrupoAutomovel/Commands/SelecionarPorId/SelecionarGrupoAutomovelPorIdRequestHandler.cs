using LocadoraDeAutomoveis.Dominio.ModuloGrupoAutomovel;
using LocadoraDeAutomoveis.Aplicacao.ModuloGrupoAutomovel.DTOs;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloGrupoAutomovel.Commands.SelecionarPorId;

public class SelecionarGrupoAutomovelPorIdRequestHandler
{
    private readonly IGrupoAutomovelRepository _repository;

    public SelecionarGrupoAutomovelPorIdRequestHandler(IGrupoAutomovelRepository repository)
    {
        _repository = repository;
    }

    public async Task<object> Handle(SelecionarGrupoAutomovelPorIdRequest request)
    {
        var grupo = await _repository.SelecionarPorId(request.Id);

        if (grupo == null)
            return GrupoAutomovelErrorResults.GrupoNaoEncontrado;

        return new GrupoAutomovelDto
        {
            Id = grupo.Id,
            Nome = grupo.Nome
        };
    }
}
