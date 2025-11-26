using LocadoraDeAutomoveis.Dominio.ModuloGrupoAutomovel;
using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloGrupoAutomovel.Commands.Excluir;

public class ExcluirGrupoAutomovelRequestHandler : IRequestHandler<ExcluirGrupoAutomovelRequest, object>
{
    private readonly IGrupoAutomovelRepository _repository;

    public ExcluirGrupoAutomovelRequestHandler(IGrupoAutomovelRepository repository)
    {
        _repository = repository;
    }

    public async Task<object> Handle(ExcluirGrupoAutomovelRequest request, CancellationToken cancellationToken)
    {
        var grupo = await _repository.SelecionarPorIdAsync(request.Id);

        if (grupo == null)
            return GrupoAutomovelErrorResults.GrupoNaoEncontrado;

        await _repository.ExcluirAsync(grupo);

        return new { Mensagem = "Grupo excluído com sucesso." };
    }
}
