using LocadoraDeAutomoveis.Dominio.ModuloGrupoAutomovel;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloGrupoAutomovel.Commands.Excluir;

public class ExcluirGrupoAutomovelRequestHandler
{
    private readonly IGrupoAutomovelRepository _repository;

    public ExcluirGrupoAutomovelRequestHandler(IGrupoAutomovelRepository repository)
    {
        _repository = repository;
    }

    public async Task<object> Handle(ExcluirGrupoAutomovelRequest request)
    {
        var grupo = await _repository.SelecionarPorId(request.Id);

        if (grupo == null)
            return GrupoAutomovelErrorResults.GrupoNaoEncontrado;

        await _repository.Excluir(grupo);

        return new { Mensagem = "Grupo excluído com sucesso." };
    }
}
