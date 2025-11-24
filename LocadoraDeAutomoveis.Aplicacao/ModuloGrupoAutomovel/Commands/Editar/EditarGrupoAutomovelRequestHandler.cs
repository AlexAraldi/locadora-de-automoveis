using LocadoraDeAutomoveis.Aplicacao.ModuloGrupoAutomovel.Validators;
using LocadoraDeAutomoveis.Dominio.ModuloGrupoAutomovel;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloGrupoAutomovel.Commands.Editar;

public class EditarGrupoAutomovelRequestHandler
{
    private readonly IGrupoAutomovelRepository _repository;
    private readonly EditarGrupoAutomovelValidator _validator;

    public EditarGrupoAutomovelRequestHandler(IGrupoAutomovelRepository repository)
    {
        _repository = repository;
        _validator = new EditarGrupoAutomovelValidator();
    }

    public async Task<object> Handle(EditarGrupoAutomovelRequest request)
    {
        var validation = _validator.Validate(request);
        if (!validation.IsValid)
            return validation.Errors.Select(x => x.ErrorMessage);

        var grupo = await _repository.SelecionarPorIdAsync(request.Id);
        if (grupo == null)
            return GrupoAutomovelErrorResults.GrupoNaoEncontrado;

        var duplicado = await _repository.BuscarPorNomeAsync(request.Nome);
        if (duplicado != null && duplicado.Id != request.Id)
            return GrupoAutomovelErrorResults.NomeDuplicado;

        grupo.Editar(request.Nome);

        await _repository.EditarAsync(grupo);

        return new
        {
            Mensagem = "Grupo atualizado com sucesso.",
            Id = grupo.Id,
            Nome = grupo.Nome
        };
    }
}
