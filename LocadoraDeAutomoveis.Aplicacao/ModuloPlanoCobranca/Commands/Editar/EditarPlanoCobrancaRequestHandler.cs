using FluentValidation;
using LocadoraDeAutomoveis.Dominio.ModuloGrupoAutomovel;
using LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca;
using LocadoraDeAutomoveis.Aplicacao.ModuloPlanoCobranca.Validators;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloPlanoCobranca.Commands.Editar;

public class EditarPlanoCobrancaRequestHandler
{
    private readonly IPlanoCobrancaRepository _repository;
    private readonly IGrupoAutomovelRepository _grupoRepository;
    private readonly EditarPlanoCobrancaValidator _validator;

    public EditarPlanoCobrancaRequestHandler(
        IPlanoCobrancaRepository repository,
        IGrupoAutomovelRepository grupoRepository)
    {
        _repository = repository;
        _grupoRepository = grupoRepository;
        _validator = new EditarPlanoCobrancaValidator();
    }

    public async Task<object> Handle(EditarPlanoCobrancaRequest request)
    {
        var validation = _validator.Validate(request);
        if (!validation.IsValid)
            return validation.Errors.Select(x => x.ErrorMessage);

        var plano = await _repository.SelecionarPorId(request.Id);
        if (plano == null)
            return PlanoCobrancaErrorResults.PlanoNaoEncontrado;

        var grupo = await _grupoRepository.SelecionarPorId(request.GrupoAutomovelId);
        if (grupo == null)
            return PlanoCobrancaErrorResults.GrupoNaoEncontrado;

        var duplicado = await _repository.BuscarDuplicado(request.GrupoAutomovelId, request.TipoPlano);
        if (duplicado != null && duplicado.Id != request.Id)
            return PlanoCobrancaErrorResults.PlanoDuplicado;

        plano.Editar(
            request.GrupoAutomovelId,
            request.TipoPlano,
            request.ValorDiaria,
            request.ValorPorKm,
            request.KmLivre,
            request.KmControladoLimite,
            request.ValorExcedenteKm
        );

        await _repository.Atualizar(plano);

        return new { Mensagem = "Plano atualizado com sucesso." };
    }
}
