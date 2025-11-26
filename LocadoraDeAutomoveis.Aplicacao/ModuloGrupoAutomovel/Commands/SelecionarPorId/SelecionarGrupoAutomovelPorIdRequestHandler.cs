using LocadoraDeAutomoveis.Dominio.ModuloGrupoAutomovel;
using LocadoraDeAutomoveis.Aplicacao.ModuloGrupoAutomovel.DTOs;
using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloGrupoAutomovel.Commands.SelecionarPorId;

public class SelecionarGrupoAutomovelPorIdRequestHandler : IRequestHandler<SelecionarGrupoAutomovelPorIdRequest, object> 
{
    private readonly IGrupoAutomovelRepository _repository;

    public SelecionarGrupoAutomovelPorIdRequestHandler(IGrupoAutomovelRepository repository)
    {
        _repository = repository;
    }

    public async Task<object> Handle(SelecionarGrupoAutomovelPorIdRequest request, CancellationToken cancellationToken)
    {
        var grupo = await _repository.SelecionarPorIdAsync(request.Id);

        if (grupo == null)
            return GrupoAutomovelErrorResults.GrupoNaoEncontrado;

        return new GrupoAutomovelDto
        {
            Id = grupo.Id,
            Nome = grupo.Nome
        };
    }
}
