using LocadoraDeAutomoveis.Aplicacao.ModuloGrupoAutomovel.Validators;
using LocadoraDeAutomoveis.Dominio.ModuloGrupoAutomovel;
using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloGrupoAutomovel.Commands.Criar;

public class CriarGrupoAutomovelRequestHandler : IRequestHandler<CriarGrupoAutomovelRequest, object>
{
    private readonly IGrupoAutomovelRepository _repository;
    private readonly CriarGrupoAutomovelValidator _validator;

    public CriarGrupoAutomovelRequestHandler(IGrupoAutomovelRepository repository)
    {
        _repository = repository;
        _validator = new CriarGrupoAutomovelValidator();
    }

    public async Task<object> Handle(CriarGrupoAutomovelRequest request, CancellationToken cancellationToken)
    {
        var validation = _validator.Validate(request);
        if (!validation.IsValid)
            return validation.Errors.Select(e => e.ErrorMessage);

        var existente = await _repository.BuscarPorNomeAsync(request.Nome);
        if (existente != null)
            return GrupoAutomovelErrorResults.NomeDuplicado;

        var grupo = new GrupoAutomovel(request.Nome);

        await _repository.AdicionarAsync(grupo);

        return new
        {
            Mensagem = "Grupo criado com sucesso.",
            Id = grupo.Id
        };
    }
}
